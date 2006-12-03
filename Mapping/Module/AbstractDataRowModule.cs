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
    public abstract class AbstractDataRowModule : IModul
    {

        private Hashtable m_RowObjectMapping = new Hashtable();

        public abstract void Load();

        public abstract void Unload();

        public abstract void Activate();        
        
        public abstract void Deactivate();                

        public abstract void RegionLoad(RegionMgr.Region region);                

        public abstract void RegionUnload(RegionMgr.Region region);                

        public abstract void DXClick(MouseEventArgs e);        

        public abstract void ObjectMoved(IMapObject obj);        

        public abstract IMapObject GetObjectAt(int x, int y);

        public virtual ArrayList GetObjects()
        {
            return new ArrayList(m_RowObjectMapping.Values);
        }

        public abstract void ClearDirty();

        public abstract Form GetPropertyForm();

        public abstract void Filter(ModulMgr.ModulObj mod);
        public abstract void Unfilter(ModulMgr.ModulObj mod);

        private static DOL.Tools.Mapping.DX.Meshes.Plane plane;

        protected static DOL.Tools.Mapping.DX.Meshes.Plane Plane
        {
            get
            {
                if (plane == null || plane.Disposed)
                    plane = new DOL.Tools.Mapping.DX.Meshes.Plane(Common.Device, 175, 175, true);

                return plane;
            }
        }

        protected GeometryObj GetObjectForRow(DataRow row)
        {
            return (GeometryObj)m_RowObjectMapping[row];
        }

        protected void SetObjectForRow(DataRow row, GeometryObj obj)
        {
            m_RowObjectMapping[row] = obj;
        }

        protected void RemoveObjectForRow(DataRow row)
        {
            m_RowObjectMapping.Remove(row);
        }

        protected void ClearObjectRowMapping()
        {
            m_RowObjectMapping.Clear();
        }



        
    }
}
