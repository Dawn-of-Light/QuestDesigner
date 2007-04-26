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
        private DOL.Tools.Mapping.DX.Meshes.Plane plane;

        private Dictionary<DataRow, GeometryObj> m_RowObjectMapping = new Dictionary<DataRow, GeometryObj>();

        private string name;

        private int width;

        private int height;

        public AbstractDataRowModule(string name)
            : this(name, 175, 175) { }
   
        public AbstractDataRowModule(string name,int width,int height) : base()
        {
            this.name = name;
            this.width = width;
            this.height = height;
        }
        
        public string Name
        {
            get { return name; }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }   

        public abstract void Load();

        public abstract void Unload();        

        public abstract void RegionLoad(RegionMgr.Region region);                

        public abstract void RegionUnload(RegionMgr.Region region);                

        public abstract void DXClick(MouseEventArgs e);        

        public abstract void ObjectMoved(GeometryObj obj);        

        public abstract GeometryObj GetObjectAt(int x, int y);

        public virtual ICollection<GeometryObj> GetObjects()
        {
            return m_RowObjectMapping.Values;
        }

        public abstract void ClearDirty();        

        public abstract void Filter();
        public abstract void Unfilter();

        
        protected DOL.Tools.Mapping.DX.Meshes.Plane Plane
        {
            get
            {
                if (plane == null || plane.Disposed)
                    plane = new DOL.Tools.Mapping.DX.Meshes.Plane(Common.Device, Width, Height, true);

                return plane;
            }
        }

        protected GeometryObj GetObjectForRow(DataRow row)
        {
            if (m_RowObjectMapping.ContainsKey(row))
            {
                return m_RowObjectMapping[row];
            }
            else
            {
                return null;
            }
        }

        protected DataRow GetRowForObject(GeometryObj obj)
        {
            foreach (DataRow row in m_RowObjectMapping.Keys)
            {
                if (m_RowObjectMapping[row] == obj)
                    return row;
            }
            return null;
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
