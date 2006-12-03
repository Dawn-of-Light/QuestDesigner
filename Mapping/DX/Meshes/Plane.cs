using System;
using Microsoft.DirectX.Direct3D;

namespace DOL.Tools.Mapping.DX.Meshes
{
    public class Plane : AbstractMesh, IMesh
    {
        private float m_Width;
        private float m_Height;
        private bool m_Centered = false;

        //Indicies are constant and shouldn't be editet--
        private static readonly short[] indices = {
                                                      0, 1, 3, // Top Left
                                                      2, 3, 1 // BottomRight	
                                                  };


        public float Width
        {
            get { return m_Width; }
            set
            {
                m_Width = value;
                FillVB(VB, null);
            }
        }

        public float Height
        {
            get { return m_Height; }
            set
            {
                m_Height = value;
                FillVB(VB, null);
            }
        }

        public bool Centered
        {
            get { return m_Centered; }
            set { m_Centered = value; }
        }


        public Plane(Device device, float width, float height, bool center) : base(device)
        {
            m_Width = width;
            m_Height = height;

            m_Centered = center;

            VB =
                new VertexBuffer(typeof (CustomVertex.PositionTextured), 4, Device, Usage.Dynamic | Usage.WriteOnly,
                                 CustomVertex.PositionTextured.Format, Pool.Default);
            IB = new IndexBuffer(typeof (short), 6, device, Usage.WriteOnly, Pool.Default);

            VB.Created += new EventHandler(FillVB);
            IB.Created += new EventHandler(FillIB);

            FillVB(VB, null);
            FillIB(IB, null);
        }


        public void Render()
        {
            Device.SetStreamSource(0, VB, 0);
            Device.Indices = IB;
            Device.VertexFormat = CustomVertex.PositionTextured.Format;
            Device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 4, 0, 2);
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                VB.Dispose();
                IB.Dispose();
                m_Disposed = true;
            }
        }

        private void FillVB(object sender, EventArgs e)
        {
            lock (sender)
            {
                CustomVertex.PositionTextured[] verts = new CustomVertex.PositionTextured[4];

                if (!Centered)
                {
                    verts[0] = new CustomVertex.PositionTextured(0.0f, -Height, 0.0f, 0.0f, 1.0f);
                    //Top left // 0 0 // 0 1 // 0 0
                    verts[1] = new CustomVertex.PositionTextured(0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
                    //Bottom left // 1 0 // 0 0 // 0 1
                    verts[2] = new CustomVertex.PositionTextured(Width, 0.0f, 0.0f, 1.0f, 0.0f);
                    //Bottom right // 1 1 // 1 0 // 1 1
                    verts[3] = new CustomVertex.PositionTextured(Width, -Height, 0.0f, 1.0f, 1.0f);
                    //Top right  // 0 0 // 1 1 // 1 0
                }
                else
                {
                    verts[0] = new CustomVertex.PositionTextured(-(Width/2), -(Height/2), 0.0f, 0.0f, 1.0f);
                    //Top left // 0 0 // 0 1 // 0 0
                    verts[1] = new CustomVertex.PositionTextured(-(Width/2), (Height/2), 0.0f, 0.0f, 0.0f);
                    //Bottom left // 1 0 // 0 0 // 0 1
                    verts[2] = new CustomVertex.PositionTextured((Width/2), (Height/2), 0.0f, 1.0f, 0.0f);
                    //Bottom right // 1 1 // 1 0 // 1 1
                    verts[3] = new CustomVertex.PositionTextured((Width/2), -(Height/2), 0.0f, 1.0f, 1.0f);
                    //Top right  // 0 0 // 1 1 // 1 0	
                }
                ((VertexBuffer) sender).SetData(verts, 0, LockFlags.None);
            }
        }

        private void FillIB(object sender, EventArgs e)
        {
            lock (sender)
            {
                ((IndexBuffer) sender).SetData(indices, 0, LockFlags.None);
            }
        }
    }
}