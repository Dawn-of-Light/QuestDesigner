using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DOL.Tools.QuestDesigner.Util
{
	class Log
	{
        private static Boolean registered = false;

        private static List<LogEntry> messageQueue = new List<LogEntry>();

		public static void Info(string msg)
		{
			ShowMessage(msg, global::DOL.Tools.QuestDesigner.Properties.Resources.info);
		}

		public static void Warning(string msg)
		{
			ShowMessage(msg, global::DOL.Tools.QuestDesigner.Properties.Resources.warning);
		}

		public static void Error(string msg)
		{
			ShowMessage(msg, global::DOL.Tools.QuestDesigner.Properties.Resources.error);
		}

		public static void ShowMessage(string msg, Icon ico)
		{
			ShowMessage(msg, ico.ToBitmap());
		}

		public static void ShowMessage(string msg, Image img)
		{
            ShowMessage(new LogEntry(msg, img));            
		}

        public static void ShowMessage(LogEntry entry)
        {
            if (registered)
            {
                if (messageQueue.Count>0)
                    QuestDesignerMain.DesignerForm.ShowMessage(entry.Message + " (" + messageQueue.Count + " more)",entry.Image);
                else
                    QuestDesignerMain.DesignerForm.ShowMessage(entry.Message, entry.Image);
            }
            else
            {
                messageQueue.Add(entry);
            }
        }

        public static void register()
        {
            registered = true;
            pullMessageQueue();
        }

        public static void pullMessageQueue()
        {
            if (messageQueue.Count > 0)
            {
                LogEntry entry = messageQueue[messageQueue.Count - 1];
                messageQueue.Remove(entry);
                ShowMessage(entry);
            }
        }
	}

    class LogEntry {
                
        public LogEntry(String message,Image image) {
            this.Message = message;
            this.Image = image;
        }

        private Image image;

	    public Image Image
	    {
		    get { return image;}
		    set { image = value;}
	    }
    	
            private String message;

	    public String Message
	    {
		    get { return message;}
		    set { message = value;}
	    }
	

    }
}
