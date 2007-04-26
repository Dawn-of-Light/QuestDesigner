using System.Collections;
using System.Windows.Forms;
using DOL.Tools.Mapping.Map;
using DOL.Tools.Mapping.DX;
using System.Collections.Generic;

namespace DOL.Tools.Mapping.Modules
{
    public interface IModul
    {

        string Name { get;}
        /// <summary>
        /// Loads the given module, called by Modulmanager during intialization
        /// </summary>
        void Load();
        /// <summary>
        /// Unloads the given module, called by Modulmanager during termination
        /// </summary>
        void Unload();                
        /// <summary>
        /// Called whenever a new region is loaded, displayed
        /// </summary>
        /// <param name="region">New region to display</param>
        void RegionLoad(RegionMgr.Region region);
        /// <summary>
        /// Called whenever a region is unloaded (was displayed and is now replaced by another one)
        /// </summary>
        /// <param name="region">Region that gets unloaded</param>
        void RegionUnload(RegionMgr.Region region);
        /// <summary>
        /// Event whenever a click on the mapü occured
        /// </summary>
        /// <param name="e"></param>
        void DXClick(MouseEventArgs e);
        /// <summary>
        /// Ab Object is moved by the user via drag&drop
        /// </summary>
        /// <param name="obj"></param>
        void ObjectMoved(GeometryObj obj);
        /// <summary>
        /// Searches for an object at the given coordinates and returns it, or null if nothing is found
        /// </summary>
        /// <param name="x">x coordinate on map</param>
        /// <param name="y">y coordinate on map</param>
        /// <returns></returns>
        GeometryObj GetObjectAt(int x, int y);
        void Filter();
        void Unfilter();
        void ClearDirty();
        /// <summary>
        /// Returns the list of geometry objects that should be displayed on the map
        /// </summary>
        /// <returns>List of Geometry objects to be displayed on the map</returns>
        ICollection<GeometryObj> GetObjects();        
    }
}