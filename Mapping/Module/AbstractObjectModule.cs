using System;
using System.Collections.Generic;
using System.Text;
using DOL.Tools.Mapping.Modules;
using DOL.Tools.Mapping.Map;
using System.Collections;
using System.Data;
using DOL.Tools.Mapping.DX;
using System.Windows.Forms;
using DOL.Tools.Mapping.Forms;

namespace DOL.Tools.Mapping.Modules
{
    public abstract class AbstractObjectModule<T> : IModul
    {
        private DOL.Tools.Mapping.DX.Meshes.Plane plane;

        private Dictionary<T, GeometryObj> m_RowObjectMapping = new Dictionary<T, GeometryObj>();

        private bool isFiltered = false;

        private string name;

        private int width;

        private int height;

        public AbstractObjectModule(string name)
            : this(name, 175, 175) { }

        public AbstractObjectModule(string name, int width, int height)
            : base()
        {
            this.name = name;
            this.width = width;
            this.height = height;
        }

        public bool IsFiltered
        {
            get { return isFiltered; }
            set { isFiltered = value; }
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
        public abstract String GetInfoText(GeometryObj obj);        

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

        public virtual void Filter()
        {
            isFiltered = true;
            foreach (GeometryObj obj in GetObjects())
            {
                DXControl.GeoObjects.Remove(obj);
            }
        }

        public virtual void Unfilter()
        {
            isFiltered = false;
            DXControl.GeoObjects.AddRange(GetObjects());
        }       

        
        protected DOL.Tools.Mapping.DX.Meshes.Plane Plane
        {
            get
            {
                if (plane == null || plane.Disposed)
                    plane = new DOL.Tools.Mapping.DX.Meshes.Plane(Common.Device, Width, Height, true);

                return plane;
            }
        }

        public GeometryObj GetGeometryObjectForDataObject(T row)
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

        public T GetDataObjectForGeometryObject(GeometryObj obj)
        {
            foreach (T row in m_RowObjectMapping.Keys)
            {
                if (m_RowObjectMapping[row] == obj)
                    return row;
            }
            return default(T);
        }

        protected void SetObjectForRow(T row, GeometryObj obj)
        {
            m_RowObjectMapping[row] = obj;
        }

        protected void RemoveObjectForRow(T row)
        {
            m_RowObjectMapping.Remove(row);
        }

        protected void ClearObjectRowMapping()
        {
            m_RowObjectMapping.Clear();
        } 
    }
}
