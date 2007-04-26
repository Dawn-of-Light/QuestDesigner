using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.DirectX.Direct3D;
using InvalidDataException=Microsoft.DirectX.Direct3D.InvalidDataException;
using System.Windows.Forms;
using DOL.Tools.QuestDesigner;

namespace DOL.Tools.Mapping.DX
{
    /// <summary>
    /// Contains some needed Textures
    /// </summary>
    public class Textures
    {
        //Textures..
        private static Hashtable m_Textures = new Hashtable();
        private static Hashtable m_ColorTextures = new Hashtable();

        private static Texture m_Null;
        private static Texture m_Mob;
        private static Texture m_NPC;
        private static Texture m_Path;
        private static Texture m_AreaSquare;
        private static Texture m_AreaCircle;
       
        public static Texture Null
        {
            get
            {
                if (m_Null == null || m_Null.Disposed)
                {
                    m_Null = Texture.FromBitmap(Common.Device, DOL.Tools.QuestDesigner.Properties.Resources.empty, Usage.None, Pool.Managed);
                    //Texture.FromStream(Common.Device, ResourceMgr.GetStream("Resource.null.bmp"), Usage.None, Pool.Managed);
                }
                return m_Null;
            }
            set { m_Null = null; }
        }

        public static Texture AreaSquare
        {
            get
            {
                if (m_AreaSquare == null || m_AreaSquare.Disposed)
                {
                    m_AreaSquare = Texture.FromBitmap(Common.Device, DOL.Tools.QuestDesigner.Properties.Resources.areaSquare, Usage.None, Pool.Managed);
                    //Texture.FromStream(Common.Device, ResourceMgr.GetStream("Resource.null.bmp"), Usage.None, Pool.Managed);
                }
                return m_AreaSquare;
            }
            set { m_AreaSquare = null; }
        }

        public static Texture AreaCircle
        {
            get
            {
                if (m_AreaCircle == null || m_AreaCircle.Disposed)
                {
                    m_AreaCircle = Texture.FromBitmap(Common.Device, DOL.Tools.QuestDesigner.Properties.Resources.areaCircle, Usage.None, Pool.Managed);
                    //Texture.FromStream(Common.Device, ResourceMgr.GetStream("Resource.null.bmp"), Usage.None, Pool.Managed);
                }
                return m_AreaCircle;
            }
            set { m_AreaCircle = null; }
        }

        public static Texture Mob
        {
            get
            {
                if (m_Mob == null || m_Mob.Disposed)
                    m_Mob = Texture.FromBitmap(Common.Device, DOL.Tools.QuestDesigner.Properties.Resources.mob32, Usage.Dynamic, Pool.Default);
                        //Texture.FromStream(Common.Device, ResourceMgr.GetStream("data.textures.mob.png"), Usage.None, Pool.Managed);
                        //LoadTexture("data\\textures\\mob.png");

                return m_Mob;
            }
            set { m_Mob = null; }
        }

        public static Texture NPC
        {
            get
            {
                if (m_NPC == null || m_NPC.Disposed)
                    m_NPC = Texture.FromBitmap(Common.Device, DOL.Tools.QuestDesigner.Properties.Resources.npc32, Usage.Dynamic, Pool.Default);
                //Texture.FromStream(Common.Device, ResourceMgr.GetStream("data.textures.mob.png"), Usage.None, Pool.Managed);
                //LoadTexture("data\\textures\\mob.png");

                return m_NPC;
            }
            set { m_NPC = null; }
        }

        public static Texture Path
        {
            get
            {
                if (m_Path == null || m_Path.Disposed)
                    m_Path = Texture.FromBitmap(Common.Device, DOL.Tools.QuestDesigner.Properties.Resources.path, Usage.Dynamic, Pool.Default);
                        //Texture.FromStream(Common.Device, ResourceMgr.GetStream("data.textures.path.png"), Usage.None, Pool.Managed);
                        //LoadTexture("data\\textures\\path.png");

                return m_Path;
            }
            set { m_Path = null; }
        }

        

        /// <summary>
        /// Deletes all current textures
        /// </summary>
        public static void Reset()
        {
            
            //Texs
            foreach (DictionaryEntry ent in m_ColorTextures)
            {
                if (ent.Value != null)
                {
                    Texture tex = (Texture) ent.Value;
                    tex.Dispose();
                    tex = null;
                }
            }

            foreach (DictionaryEntry ent in m_Textures)
            {
                if (ent.Value != null)
                {
                    Texture tex = (Texture) ent.Value;
                    tex.Dispose();
                    tex = null;
                }
            }

            if (m_NPC != null)
            {
                NPC.Dispose();
                NPC = null;
            }
            if (m_Null != null)
            {
                Null.Dispose();
                Null = null;
            }
            if (m_Mob != null)
            {
                Mob.Dispose();
                Mob = null;
            }

            if (m_Path != null)
            {
                Path.Dispose();
                Path = null;
            }

            if (m_AreaCircle != null)
            {
                AreaCircle.Dispose();
                AreaCircle = null;
            }

            if (m_AreaSquare != null)
            {
                AreaSquare.Dispose();
                AreaSquare = null;
            }

            m_ColorTextures.Clear();
            m_Textures.Clear();
            GC.Collect();
        }

        /// <summary>
        /// Creates a new one-pixel texture
        /// </summary>
        /// <param name="color">Color of the texture</param>
        /// <returns>Texture</returns>
        public static Texture Generator(Color color)
        {
            if (m_ColorTextures[color] == null)
            {
                Bitmap bmp = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
                bmp.SetPixel(0, 0, color);
                Texture tex = Texture.FromBitmap(Common.Device, bmp, Usage.Dynamic, Pool.Default);
                m_ColorTextures.Add(color, tex);
            }
            return (Texture) m_ColorTextures[color];
        }

        /// <summary>
        /// Loads an texture from a file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static Texture LoadTexture(string file)
        {
            Texture tex = null;
            string fileName = file;
            file = Application.StartupPath + "\\" + file;

            if (m_Textures.ContainsKey(file))
                return (Texture) m_Textures[file];

            if (!File.Exists(file))
                return Null;

            // search for cached file version in dds format
            string cacheFilename = fileName.Substring(0,fileName.LastIndexOf('.'))+".dds";
            FileInfo cacheFile = new FileInfo(QuestDesignerMain.WorkingDirectory + "cache\\" + cacheFilename);
           
            try
            {

                unchecked
                {

                    if (File.Exists(cacheFile.FullName))
                    {
                        //tex = TextureLoader.FromFile(Common.Device, file,0,0,1,Usage.None,Format.Unknown,Pool.Managed,Filter.None,Filter.None,System.Drawing.Color.Violet.ToArgb());
                        tex = TextureLoader.FromFile(Common.Device, cacheFile.FullName, 0, 0, 1, Usage.None, Format.Dxt5, Pool.Default, Filter.None, Filter.None, (int)0xFFFFFF00);
                    }
                    else
                    {
                        tex = TextureLoader.FromFile(Common.Device, file, 0, 0, 1, Usage.None, Format.Dxt5, Pool.Managed, Filter.None, Filter.None, (int)0xFFFFFF00);
                        Directory.CreateDirectory(cacheFile.DirectoryName);
                        TextureLoader.Save(cacheFile.FullName, ImageFileFormat.Dds, tex);
                    }
                }
                if (!m_Textures.ContainsKey(file))
                    m_Textures.Add(file, tex);
            }
            catch (InvalidDataException)
            {
                tex = Null;
            }

            return tex;
        }

        /// <summary>
        /// Creates an (nearly) unique color from the string using hash
        /// </summary>
        /// <param name="strg"></param>
        /// <returns></returns>
        public static Color GenerateColorFromString(string strg)
        {
            //Get hash & interval
            string hash = strg.GetHashCode().ToString();
            int charint = hash.Length/3;

            //Get parts
            string first = hash.Substring(charint*0, charint);
            string secnd = hash.Substring(charint*1, charint);
            string third = hash.Substring(charint*2, charint);

            //Set RGB
            int r = 0;
            int g = 0;
            int b = 0;

            if (first != null && first != "")
                r = int.Parse(first);
            if (secnd != null && secnd != "")
                g = int.Parse(secnd);
            if (third != null && third != "")
                b = int.Parse(third);

            r = Math.Abs(r);
            g = Math.Abs(r);
            b = Math.Abs(r);

            r -= (r / 255) * 255;
            g -= (g / 255) * 255;
            b -= (b / 255) * 255;
            
            //Get Color
            return Color.FromArgb(0, r, g, b);
        }
    }
}