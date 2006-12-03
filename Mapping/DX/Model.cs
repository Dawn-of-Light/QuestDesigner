using Microsoft.DirectX.Direct3D;
using DOL.Tools.Mapping.DX.Meshes;

namespace DOL.Tools.Mapping.DX
{
    /// <summary>
    /// Model object
    /// Holds needed data for rendering
    /// </summary>
    public class Model
    {
        private IMesh m_Mesh;
        private Texture m_Texture = null;
        private Texture m_BlendTexture = null;

        /// <summary>
        /// Gets/Sets the Mesh of this object
        /// </summary>
        public IMesh Mesh
        {
            get { return m_Mesh; }
            set { m_Mesh = value; }
        }

        /// <summary>
        /// Gets/Sets the Texture of this object
        /// </summary>
        public Texture Texture
        {
            get { return m_Texture; }
            set { m_Texture = value; }
        }

        /// <summary>
        /// Gets/Sets the blend texture for this object
        /// </summary>
        public Texture BlendTexture
        {
            get { return m_BlendTexture; }
            set { m_BlendTexture = value; }
        }

        /// <summary>
        /// Creates a new model
        /// </summary>
        /// <param name="mesh">The Mesh</param>
        /// <param name="tex">The Texture</param>
        public Model(IMesh mesh, Texture tex)
        {
            Mesh = mesh;
            Texture = tex;
        }

        public Model(IMesh mesh, Texture tex, Texture blendtex)
        {
            Mesh = mesh;
            Texture = tex;
            BlendTexture = blendtex;
        }
    }
}