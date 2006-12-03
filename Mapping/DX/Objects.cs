using System;
using System.Collections;
using Microsoft.DirectX;
using DOL.Tools.QuestDesigner;

namespace DOL.Tools.Mapping.DX
{
    public class Objects
    {
        private static ArrayList m_Objects = new ArrayList();

        public static bool Add(GeometryObj obj)
        {
            lock (m_Objects)
            {
                if (m_Objects.Contains(obj))
                    return false;

                m_Objects.Add(obj);

                return true;
            }
        }

        public static bool Remove(GeometryObj obj)
        {
            lock (m_Objects)
            {
                if (!m_Objects.Contains(obj))
                    return false;

                m_Objects.Remove(obj);

                return true;
            }
        }

        public static Matrix CreateWorldMatrix(GeometryObj obj)
        {
            return
                Matrix.Scaling(obj.ScaleVector)*Matrix.RotationYawPitchRoll(obj.Yaw, obj.Pitch, obj.Roll)*
                Matrix.Translation(obj.X, -obj.Y, obj.Z);
        }

        public static bool Clear()
        {
            if (m_Objects.Count <= 0)
                return false;

            m_Objects.Clear();
            QuestDesignerMain.DesignerForm.DXControl.Invalidate();

            return true;
        }

        public static Array ToArray()
        {
            return m_Objects.ToArray(typeof (GeometryObj));
        }

        public static void Render()
        {
            QuestDesignerMain.DesignerForm.DXControl.Invalidate();
        }
    }
}