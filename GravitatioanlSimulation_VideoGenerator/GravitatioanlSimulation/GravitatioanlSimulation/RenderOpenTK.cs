using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AForge.Video.FFMPEG;
using OpenTK;
using OpenTK.Graphics;
using PixelFormat = System.Drawing.Imaging.PixelFormat;


namespace GravitatioanlSimulation
{
    class RenderOpenTK:MyGameWindow
    {
        private readonly Model _model;
        private IWriter _writer;


        /// <summary>Creates a 1200x1000 window with the specified title.</summary>
        public RenderOpenTK(Model model, IWriter writer)
            : base(1200, 1000, GraphicsMode.Default, "Gravitatioanl Simulation")
        {
            _model = model;
            _writer = writer;
            _writer.Initialization("output.gif",Width,Height);

        }




        /// <summary>Load resources here.</summary>
        /// <param name="e">Not used.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 5000.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

        }



        public void Render(int number)
        {
            OnRenderFrame(new FrameEventArgs(1));
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            Matrix4 modelview = Matrix4.LookAt(1200, 1200, 1200, 0, 0, 0, 0, 1, 0);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            GL.PointSize(1);

            GL.Begin(BeginMode.Points);

            for (int i = 0; i < _model.dimension; i++)
            {
                GL.Color3(_model.color[i]);
                GL.Vertex3(_model.r[i]);
            }

            _model.NextStep();

            GL.End();

            GetSnapShot(number);
            SwapBuffers();
        }

        

        void GetSnapShot(int number)
        {
            try
            {
                //var snapShotBmp = new Bitmap(Width, Height);
                //BitmapData bmpData = snapShotBmp.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                byte[] array = new byte[Width * Height * 3];
                GCHandle bitsHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
                IntPtr pointer = bitsHandle.AddrOfPinnedObject();

                GL.ReadPixels(0, 0, Width, Height, OpenTK.Graphics.PixelFormat.Bgr, PixelType.UnsignedByte, pointer);

                Bitmap bitmap = new Bitmap(Width, Height, Width * 3, PixelFormat.Format24bppRgb, bitsHandle.AddrOfPinnedObject());

                //snapShotBmp.Save(string.Format(@"D:\С_2015\GravitatioanlSimulation\GravitatioanlSimulation_VideoGenerator\GravitatioanlSimulation\GravitatioanlSimulation\bin\Release\result\image{0}.png",number));
                _writer.Write(bitmap);

                bitsHandle.Free();
                bitmap.Dispose();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            

        }


        public void Stop()
        {
            _writer.SaveResult();
        }
    }
}
