using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;

namespace DOL.Tools.QuestDesigner
{
    public class QuestDesignerConfiguration
    {

        XmlDocument configDocument = new XmlDocument();

        public QuestDesignerConfiguration(string path)
        {
            configDocument.PreserveWhitespace = false;             
            configDocument.Load(path);

        }

        public List<Transformator> getTransformators() {

            XmlNode export = configDocument.SelectSingleNode("/QuestDesignerConfiguration/Export");

            List<Transformator> transformators = new List<Transformator>();

            for (int i = 0; i < export.ChildNodes.Count; i++)
            {
                XmlNode transformatorNode = export.ChildNodes.Item(i);

                Transformator transformator = new Transformator(transformatorNode.Attributes["xls"].Value, transformatorNode.Attributes["extension"].Value, transformatorNode.Attributes["name"].Value, transformatorNode.Attributes["description"].Value, transformatorNode.Attributes["exporterClass"].Value, Boolean.Parse(transformatorNode.Attributes["enabled"].Value));
                transformators.Add(transformator);
            }

            return transformators;
        }



        public class Transformator
        {
            public Transformator(String xls, String extension, String name, String description, String exporterClass, Boolean enabled)
            {
                this.xlsPath = QuestDesignerMain.WorkingDirectory + xls;
                this.extension = extension;
                this.name = name;
                this.description = description;
                this.enabled = enabled;

                if (exporterClass==null || exporterClass.Length > 0)
                    this.exporterClass = Type.GetType(exporterClass);
                else
                    this.exporterClass = typeof(DOL.Tools.QuestDesigner.Export.BaseExporter);
            }

            private String xlsPath;
            public String XlsPath
            {
                get { return xlsPath; }
            }

            private String extension;
            public String Extension
            {
                get { return extension; }
            }
            private String name;
            public String Name
            {
                get { return name; }
            }
            private String description;
            public String Description
            {
                get { return description; }
            }
            private Boolean enabled;
            public Boolean Enabled
            {
                get { return enabled; }
            }

            private Type exporterClass;
            public Type ExporterClass
            {
                get { return exporterClass; }
            }
	
	
        }
    }
}
