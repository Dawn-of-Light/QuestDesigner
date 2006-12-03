using Microsoft.DirectX.Direct3D;

namespace DOL.Tools.Mapping.DX.Meshes
{
    public class XMesh : IMesh
    {
        private Mesh m_Mesh;

        public Mesh Mesh
        {
            get { return m_Mesh; }
            set { m_Mesh = value; }
        }

        public XMesh(Mesh mesh)
        {
            m_Mesh = mesh;
        }

        public void Render()
        {
            m_Mesh.DrawSubset(0);
        }

        public void Dispose()
        {
            if (!m_Mesh.Disposed)
                m_Mesh.Dispose();
        }
    }
}