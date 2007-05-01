using System;
using System.Collections.Generic;
using System.Text;
using DOL.Tools.Mapping.Modules;
using DOL.Tools.Mapping.Map;
using System.Collections;
using System.Data;
using DOL.Tools.Mapping.DX;
using System.Windows.Forms;

namespace DOL.Tools.Mapping.Modules
{
    public abstract class AbstractDataRowModule : AbstractObjectModule<DataRow>
    {
       
        public AbstractDataRowModule(string name)
            : this(name, 175, 175) { }
   
        public AbstractDataRowModule(string name,int width,int height) : base(name,width,height)
        { }
                
    }
}
