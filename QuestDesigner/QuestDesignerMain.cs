/*
 * DAWN OF LIGHT - The first free open source DAoC server emulator
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;
using System.Xml.Xsl;
using System.Xml;
using System.IO;
using System.Data;
using System.Threading;
using System.ComponentModel;
using System.Drawing;
using DOL.GS.Quests;
using DOL.Tools.QuestDesigner.Util;
using DOL.Database;
using System.Reflection;
using System.Deployment.Application;
using System.Net;
using ICSharpCode.SharpZipLib.Zip;

namespace DOL.Tools.QuestDesigner
{
    public static class QuestDesignerMain
    {		
        public static string XSL_PATH = QuestDesignerMain.WorkingDirectory + System.Configuration.ConfigurationManager.AppSettings["XLSFilePath"];        
		

        private static DOLDatabaseAdapter databaseAdapter = null;

		public static QuestDesignerForm qdForm;
		public static NPCLookupForm npcForm;
        public static ItemLookupForm itemForm;
		private static PositionConverterPopup posConvForm;

        private static BackgroundWorker databaseWorker = new BackgroundWorker();
       
        public static String WorkingDirectory;

		public static QuestDesignerForm DesignerForm
		{
			get {
				if (qdForm ==null)
					qdForm = new QuestDesignerForm();				
				return qdForm;
			}
		}

        public static string Version
        {
            get
            {
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                }
                else
                {
                    return Application.ProductVersion;
                }
            }
        }

        public static DOLDatabaseAdapter DatabaseAdapter
        {
            get
            {                                
                return databaseAdapter;
            }
        }

		public static PositionConverterPopup PositionConverter
		{
			get
			{
				if (posConvForm == null || posConvForm.IsDisposed)
					posConvForm = new PositionConverterPopup();
				return posConvForm;
			}
		}

        public static bool WaitForDatabase()
        {
            if (databaseWorker.IsBusy)
            {
                DesignerForm.Cursor = Cursors.WaitCursor;
                while (databaseWorker.IsBusy)
                    Application.DoEvents();
                DesignerForm.Cursor = Cursors.Default;
            }
            return true;
        }

		public static NPCLookupForm NPCLookupForm
		{
			get
			{
				if (npcForm == null)
				{
                    if (WaitForDatabase())
					    npcForm = new NPCLookupForm();
				}
				return npcForm;				 
			}
		}

        public static ItemLookupForm ItemLookupForm
        {
            get
            {
				if (itemForm == null)
				{
					if (WaitForDatabase())					
                        itemForm = new ItemLookupForm();
				}
                return itemForm;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //RELEASE MODE; ERROR DIALOG
            try
            {
                

                Form.CheckForIllegalCrossThreadCalls = false;            

                WorkingDirectory = Application.StartupPath+"\\";
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // check for file to load
                if (args.Length > 0 && File.Exists(args[0]))
                {
                    qdForm = new QuestDesignerForm(new FileInfo(args[0]));
                }

                Application.Run(DesignerForm);
                Environment.Exit(0);
            }            
            catch (Exception e)
            {
                new ErrorForm(e);
            }
        }

              

        public static bool DatabaseSupported
        {
            get { return databaseAdapter.isConnected(); }
        }

        public static bool DataSupported
        {
            get { return Directory.Exists(QuestDesignerMain.WorkingDirectory + "data"); }
        }		

        static void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
				HandleException(e.Error, "Database error: " + e.Error.Message, global::DOL.Tools.QuestDesigner.Properties.Resources.databaseError);                
                DesignerForm.SetDatabaseSupport(false);
            }            
            else
            {
                Log.ShowMessage("Database successfully initialized", global::DOL.Tools.QuestDesigner.Properties.Resources.databaseOk);
                DesignerForm.SetDatabaseSupport(true);
            }
            DesignerForm.StatusProgress.Value = DesignerForm.StatusProgress.Minimum;            
        }

		public static void HandleException(Exception e, string errorMsg, Image errorImg)
		{
			Log.ShowMessage(errorMsg, errorImg);
		}

        public static void HandleException(Exception e, string errorMsg)
        {
            Log.ShowMessage(errorMsg, global::DOL.Tools.QuestDesigner.Properties.Resources.error);
        }

        public static void HandleException(Exception e)
        {
            Log.Error(e.Message);
        }

        public static void InitDB()
        {
			try
			{
				databaseWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker_doWork);
				databaseWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
				databaseWorker.RunWorkerAsync();
			}
			catch (Exception e)
			{
				HandleException(e, "Database error: " + e.Message, global::DOL.Tools.QuestDesigner.Properties.Resources.databaseError);
			}
        }

        /// <summary>
        /// Initializes the database
        /// </summary>
        static void backgroundWorker_doWork(object sender, DoWorkEventArgs e)
        {
            databaseAdapter = new DOLDatabaseAdapter();
                        
            e.Result = databaseAdapter.isConnected();
        }

    }
}