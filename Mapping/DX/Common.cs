using Microsoft.DirectX.Direct3D;
using DOL.Tools.QuestDesigner;
using System.ComponentModel;
using System.Timers;
using System;

namespace DOL.Tools.Mapping.DX
{
    public class Common
    {
        private static Device m_Device = null;
        private static bool DeviceReady = false;

        public static Device Device
        {
            get
            {
                if (m_Device == null)
                {
                    PresentParameters paras = new PresentParameters();
                    paras.Windowed = true; //Windowed
                    paras.SwapEffect = SwapEffect.Discard; //Normal Buffer

                    //Maybe switch to hardware?
                    m_Device = new Device(0, DeviceType.Hardware, QuestDesignerMain.DesignerForm.DXControl, CreateFlags.HardwareVertexProcessing, paras);
                    m_Device.DeviceResizing += new CancelEventHandler(DXResize);
                    m_Device.DeviceReset += new EventHandler(DXReset);
                    m_Device.DeviceLost += new EventHandler(m_Device_DeviceLost);
                    m_Device.Reset(paras);

                    System.Timers.Timer timer = new Timer(750);
                    timer.Elapsed += new ElapsedEventHandler(DXFinishedInitialize);
                    timer.AutoReset = false;
                    timer.Start();
                }
                return m_Device;
            }
        }

        static void m_Device_DeviceLost(object sender, EventArgs e)
        {
            Textures.Reset();
        }

        public void DXInitialize()
        {
            Device device = Device;
        }
        

        private static void DXFinishedInitialize(object sender, ElapsedEventArgs e)
        {
            //DAMN DIRECTX!
            DeviceReady = true;
        }

        private static void DXResize(object sender, CancelEventArgs e)
        {
            if (DeviceReady)
                e.Cancel = true;

            // -> unsmooth!
            //e.Cancel = true;
        }

        private static void DXReset(object sender, EventArgs e)
        {
            Device.RenderState.CullMode = Cull.None;
            Device.RenderState.Lighting = false;

            Device.RenderState.SourceBlend = Blend.SourceAlpha;
            Device.RenderState.DestinationBlend = Blend.InvSourceAlpha;
            Device.RenderState.AlphaBlendEnable = true;
            Device.RenderState.AlphaBlendOperation = BlendOperation.Add;

            Device.SamplerState[0].MagFilter = TextureFilter.Anisotropic;
            Device.SamplerState[0].MinFilter = TextureFilter.Anisotropic;
            Device.SamplerState[0].MipFilter = TextureFilter.Anisotropic;
        }
    }
}