using Microsoft.DirectX.Direct3D;

namespace DOL.Tools.Mapping.DX.Meshes
{
    /// <summary>
    /// A abstract Mesh object
    /// Contains a Render mechanism
    /// and a Device
    /// </summary>
    public abstract class AbstractMesh
    {
        protected Device m_Device;
        private VertexBuffer m_VB = null;
        private IndexBuffer m_IB = null;
        protected bool m_Disposed = false;

        public Device Device
        {
            get { return m_Device; }
        }

        public VertexBuffer VB
        {
            get { return m_VB; }
            set { m_VB = value; }
        }

        public IndexBuffer IB
        {
            get { return m_IB; }
            set { m_IB = value; }
        }

        public bool Disposed
        {
            get { return m_Disposed; }
        }


        public AbstractMesh(Device device)
        {
            m_Device = device;
        }
    }
}