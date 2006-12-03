using System.Collections;
using System.Drawing;
using System.IO;
using System.Reflection;
using DOL.Tools.Mapping.Resource;
using System.Windows.Forms;
/// <summary>
/// Provides Functions for the DAoC Mapping/Coordinate system
/// Uthgard Map Editor
/// © 2005 Uthgard / Metty
/// </summary>
/// 
namespace DOL.Tools.Mapping
{
    public class DAoCMapping
    {
        /// <summary>
        /// List for all Zones
        /// </summary>
        private static Hashtable m_Zones = new Hashtable();
        /// <summary>
        /// Gets the Z from zone locs (x,y,zoneID)
        /// </summary>
        /// <param name="zoneX">Zone X</param>
        /// <param name="zoneY">Zone Y</param>
        /// <param name="zoneid">ZoneID</param>
        /// <returns>Z</returns>
        public static int GetZByZoneLocs(int zoneX, int zoneY, int zoneid)
        {
            const int div = 256;

            Zone zone = GetZone(zoneid);

            int z = 0;

            #region Get Points
            //Lets get our points!
            Point[] points = new Point[4];

            int subX = (zoneX / div) - 1;
            int subY = (zoneY / div) - 1;

            points[0] = new Point(subX, subY); //Topper left
            points[1] = new Point(subX + 1, subY); //Topper right
            points[2] = new Point(subX, subY + 1); //Bottom left
            points[3] = new Point(subX + 1, subY + 1); //Bottom right

            //Check for invalid points
            foreach (Point pnt in points)
            {
                if (pnt.X < 0)
                    pnt.X = 0;

                if (pnt.X > 255)
                    pnt.X = 255;

                if (pnt.Y < 0)
                    pnt.Y = 0;

                if (pnt.Y > 255)
                    pnt.Y = 255;
            }

            int relX = zoneX - ((subX + 1) * div);
            int relY = zoneY - ((subY + 1) * div);

            double scrollX = (double)relX / div;
            double scrollY = (double)relY / div;

            #endregion

            if (zone.Terrain != null)
            {
                double col = GetInterlacedColor(zone.Terrain, points[0], points[1], points[2], points[3], scrollX, scrollY);
                z += (int)(col * zone.TerrainFactor);
            }

            if (zone.Offset != null)
            {
                double col = GetInterlacedColor(zone.Offset, points[0], points[1], points[2], points[3], scrollX, scrollY);
                z += (int)(col * zone.OffsetFactor);
            }

            return z;
        }

        /// <summary>
        /// This class represents a point on the height map
        /// </summary>
        private class Point
        {
            private int m_X;

            public int X
            {
                get { return m_X; }
                set { m_X = value; }
            }

            private int m_Y;

            public int Y
            {
                get { return m_Y; }
                set { m_Y = value; }
            }

            public Point(int x, int y)
            {
                m_X = x;
                m_Y = y;
            }
        }
        /// <summary>
        /// Gets (and creates if neccessary) a zone by the zoneid
        /// </summary>
        /// <param name="num">ZoneID</param>
        /// <returns>Zone</returns>
        private static Zone GetZone(int num)
        {
            #region Create new Zone
            if (m_Zones[num] == null)
            {
                Zone zone = new Zone(num);

                #region Height Maps                

                
                zone.Terrain = LoadBitmap(string.Format(terrainFormat, num));                
                zone.Offset = LoadBitmap(string.Format(offsetFormat, num));
                #endregion

                #region Factors
                int terfac = 0;
                int offfac = 0;

                

                if (File.Exists(Application.StartupPath+"\\"+ string.Format(factorFormat, num)))
                {
                    StreamReader rdr = new StreamReader(Application.StartupPath+"\\"+ string.Format(factorFormat, num));
                    string txt = rdr.ReadToEnd();
                    rdr.Close();

                    string[] content = txt.Split(';');

                    if (content.Length == 2)
                    {
                        terfac = int.Parse(content[0]);
                        offfac = int.Parse(content[1]);
                    }
                }

                zone.TerrainFactor = terfac;
                zone.OffsetFactor = offfac;
                #endregion

                m_Zones[num] = zone;
            }
            #endregion

            return (Zone)m_Zones[num];
        }
        /// <summary>
        /// This class represents a Zone with heightmap and factors
        /// </summary>
        private class Zone
        {
            public Zone(int zoneID)
            {
                m_ZoneID = zoneID;
            }

            private int m_ZoneID;

            public int ZoneID
            {
                get { return m_ZoneID; }
            }

            private Bitmap m_Terrain;

            public Bitmap Terrain
            {
                get { return m_Terrain; }
                set { m_Terrain = value; }
            }

            private Bitmap m_Offset;

            public Bitmap Offset
            {
                get { return m_Offset; }
                set { m_Offset = value; }
            }

            private int m_TerrainFactor;

            public int TerrainFactor
            {
                get { return m_TerrainFactor; }
                set { m_TerrainFactor = value; }
            }

            private int m_OffsetFactor;

            public int OffsetFactor
            {
                get { return m_OffsetFactor; }
                set { m_OffsetFactor = value; }
            }
        }

        public static void PrecacheZones()
        {
            if (m_Zones.Count > 0)
                return;

            for (int a = 0; a <= 1024; a++)
                GetZone(a);
        }

        private static Bitmap LoadBitmap(string file)
        {
            file = Application.StartupPath + "\\" + file;

            if (!File.Exists(file))
                return null;

            return (Bitmap) Bitmap.FromFile(file);
        }

        private static double GetInterlacedColor(Bitmap bmp, Point topleft, Point topright, Point bottomleft, Point bottomright, double xScroll, double yScroll)
        {
            Color cTL = bmp.GetPixel(topleft.X, topleft.Y);
            Color cTR = bmp.GetPixel(topright.X, topright.Y);
            Color cBL = bmp.GetPixel(bottomleft.X, bottomleft.Y);
            Color cBR = bmp.GetPixel(bottomright.X, bottomright.Y);

            //Height Map
            /*
                ____________________
                | \                |
                |   \              |
                |     \            |
                |       \          |
                |         \        |
                |           \      |
                |             \    |
                |               \  |
                |__________________|
            
                Area is divided into two seperate triangles
                if one triangle is selected, the other is ignored
            */
            //Get Triangle
            double seperator = xScroll; //As it is a Quader, y=x
            //double seperator = -xScroll; //Line inverted;
            Color basePnt;
            Color xPnt;
            Color yPnt;

            if (yScroll >= seperator)
            {
                //Upper right triangle
                basePnt = cTR;
                xPnt = cTL;
                yPnt = cBR;
                xScroll = 1.0 - xScroll;

                //Top left
                /*
                basePnt = cTL;
                xPnt = cTR;
                yPnt = cBL;*/

            }
            else
            {

                //Lower left triangle
                basePnt = cBL;
                xPnt = cBR;
                yPnt = cTL;
                yScroll = 1.0 - yScroll;

                //Bottom right
                /*
                basePnt = cBR;
                xPnt = cBL;
                yPnt = cTR;
                xScroll = 1.0 - xScroll;
                yScroll = 1.0 - yScroll;*/
            }

            /*
                yPnt
                | \
                |   \
                |     \
                |       \
                |         \
                |___________\
             basePnt        xPnt

            */

            //Formula:
            // Z = baseZ        +   xDiff   *   (xZ     -    baseZ)     +   yDiff *     (yZ     -   baseZ)
            double grey = (int)(basePnt.R + xScroll * (xPnt.R - basePnt.R) + yScroll * (yPnt.R - basePnt.R));

            return grey;
        }

        //Strings for loading files
        private static readonly string terrainFormat = "data\\terrain\\{0}_terrain.jpg";
        private static readonly string offsetFormat = "data\\offset\\{0}_offset.jpg";
        private static readonly string factorFormat = "data\\factor\\{0}_factor.txt";
        
    }
}