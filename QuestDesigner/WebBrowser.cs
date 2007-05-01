using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DOL.Tools.QuestDesigner.QuestDesigner
{
    public partial class WebBrowser : UserControl
    {
        
        public WebBrowser()
        {
            InitializeComponent();
        }

        public void Init()
        {
            if (this.webBrowser1.Url==null|| this.webBrowser1.Url.AbsolutePath=="blank")
                GoHome();
        }

        public void GoHome()
        {
            this.webBrowser1.Url =new Uri(System.Configuration.ConfigurationManager.AppSettings["DOLModelPreviewUrl"]);
        }
    }
}
