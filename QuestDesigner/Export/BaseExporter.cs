using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DOL.Tools.QuestDesigner.Export
{
    class BaseExporter : Exporter
    {
        public BaseExporter(DOL.Tools.QuestDesigner.QuestDesignerConfiguration.Transformator transformator)
            : base(transformator) {
        }

        protected override bool ValidateData(DataSet dataSet)
        {
            return true;
        }
    }
}
