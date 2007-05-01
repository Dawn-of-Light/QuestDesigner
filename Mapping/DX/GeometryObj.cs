using Microsoft.DirectX;
using System;
using DOL.Tools.Mapping.Modules;
using Microsoft.DirectX.Direct3D;

namespace DOL.Tools.Mapping.DX
{
    /// <summary>
    /// Geometry Object
    /// Holds Model
    /// Holds World X,Y,Z
    /// Holds Yaw,Pitch,Roll
    /// </summary>
    public class GeometryObj : IComparable<GeometryObj>
    {
        private Model m_Model;
        private float m_X;
        private float m_Y;
        private float m_Z;
        private float m_Yaw;
        private float m_Pitch;
        private float m_Roll;
        private DrawLevel m_DrawLevel;
        private DetailLevel m_DetailLevel;
        private Vector3 m_ScaleVector;
        private IModul m_Modul;

        private bool m_IsMovable;
        private bool m_ShowHeading;
        

        public bool ShowHeading
        {
            get { return m_ShowHeading; }
            set { m_ShowHeading = value; }
        }
	

        /// <summary>
        /// The Model Object
        /// </summary>
        public Model Model
        {
            get { return m_Model; }
            set { m_Model = value; }
        }

        public IModul Modul
        {
            get { return m_Modul; }
            set { m_Modul = value; }
        }

        public bool IsMovable
        {
            get { return m_IsMovable; }
            set { m_IsMovable = value; }
        }

        public Vector3 ScaleVector
        {
            get { return m_ScaleVector; }
            set { m_ScaleVector = value; }
        }

        /// <summary>
        /// X
        /// </summary>
        public float X
        {
            get { return m_X; }
            set { m_X = value; }
        }

        /// <summary>
        /// Y
        /// </summary>
        public float Y
        {
            get { return m_Y; }
            set { m_Y = value; }
        }

        /// <summary>
        /// Z
        /// </summary>
        public float Z
        {
            get { return m_Z; }
            set { m_Z = value; }
        }

        /// <summary>
        /// Yaw
        /// </summary>
        public float Yaw
        {
            get { return m_Yaw; }
            set { m_Yaw = value; }
        }

        /// <summary>
        /// Pitch
        /// </summary>
        public float Pitch
        {
            get { return m_Pitch; }
            set { m_Pitch = value; }
        }

        /// <summary>
        /// Roll
        /// </summary>
        public float Roll
        {
            get { return m_Roll; }
            set { m_Roll = value; }
        }

        /// <summary>
        /// The Render Level of this object
        /// </summary>
        public DrawLevel DrawLevel
        {
            get { return m_DrawLevel; }
            set { m_DrawLevel = value; }
        }

        /// <summary>
        /// The Detail Level of this object
        /// </summary>
        public DetailLevel DetailLevel
        {
            get { return m_DetailLevel; }
            set { m_DetailLevel = value; }
        }

        public Matrix CreateWorldMatrix()
        {            
            return
                Matrix.Scaling(ScaleVector) * Matrix.Translation(X, -Y, Z);
        }
        public Matrix CreateWorldHeadingMatrix()
        {
            return
                Matrix.Scaling(ScaleVector) * Matrix.RotationYawPitchRoll(Yaw, Pitch, Roll) *
                Matrix.Translation(X, -Y, Z);
        }

        public int CompareTo(GeometryObj obj)
        {
            return this.DrawLevel - obj.DrawLevel;
        }


        /// <summary>
        /// Creates a new Geometry Object
        /// </summary>
        /// <param name="model">The Model</param>
        /// <param name="drawlevel">The Render Level</param>
        /// <param name="lvl">The Detail Level</param>
        /// <param name="x">World X</param>
        /// <param name="y">World Y</param>
        /// <param name="z">World Z</param>
        /// <param name="yaw">Yaw</param>
        /// <param name="pitch">Pitch</param>
        /// <param name="roll">Roll</param>
        public GeometryObj(IModul modul,Model model, DrawLevel drawlevel, DetailLevel lvl, float x, float y, float z, float yaw,
                           float pitch, float roll, Vector3 scale, bool isMovable,Boolean showHeading)
        {
            Modul = modul;
            Model = model;
            DrawLevel = drawlevel;
            DetailLevel = lvl;
            X = x;
            Y = y;
            Z = z;
            Yaw = yaw;
            Pitch = pitch;
            Roll = roll;
            ScaleVector = scale;
            IsMovable = isMovable;
            ShowHeading = showHeading;
        }

        public void Render()
        {       
            //World Matrix..            
            Common.Device.Transform.World = this.CreateWorldMatrix();

            //Texture
            Common.Device.SetTexture(0, this.Model.Texture);

            //Set Blend Texture
            if (this.Model.BlendTexture != null)
            {
                Common.Device.SetTexture(1, this.Model.BlendTexture);
                Common.Device.TextureState[1].ColorOperation = TextureOperation.Modulate;
                Common.Device.TextureState[1].ColorArgument1 = TextureArgument.TextureColor;
                Common.Device.TextureState[1].ColorArgument2 = TextureArgument.Current;
                Common.Device.TextureState[2].ColorOperation = TextureOperation.Disable;
            }
            else
                Common.Device.TextureState[1].ColorOperation = TextureOperation.Disable;

            //Rendern..
            this.Model.Mesh.Render();

            if (ShowHeading)
            {                
                Common.Device.Transform.World = this.CreateWorldHeadingMatrix();
                Common.Device.SetTexture(0, Textures.LoadMapObjectTexture("Heading"));
                this.Model.Mesh.Render();
            }
            
        }
    }

    public enum DrawLevel : int
    {
        NonRender = -1,
       
        Background = 0,
        Backer = 1,
        Middle = 2,
        Forer = 3,
        Foreground = 4        
    }

    public enum DetailLevel : byte
    {       
        Nondetailed = 0,
        Undetailed = 1,
        Middle = 2,
        Detailed = 3,
        MoreDetailed = 4,
        MostDetailed = 5      
    }
}