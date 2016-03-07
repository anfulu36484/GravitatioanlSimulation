using System;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK;
using OpenTK.Graphics;

namespace GravitatioanlSimulation.Models._3D
{
    class RenderOpenTK:MyGameWindow, IRender
    {
        private readonly Model3D _model3D;
        private IWriter _writer;


        /// <summary>Creates a 1200x1000 window with the specified title.</summary>
        public RenderOpenTK(Model3D model3D, IWriter writer)
            : base(1200, 1000, GraphicsMode.Default, "Gravitatioanl Simulation")
        {
            _model3D = model3D;
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



        public void Render()
        {
            OnRenderFrame(new FrameEventArgs(1));
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            Matrix4 modelview = Matrix4.LookAt(1200, 1200, 1200, 0, 0, 0, 0, 1, 0);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            GL.PointSize(1);

            GL.Begin(BeginMode.Points);

            for (int i = 0; i < _model3D.dimension; i++)
            {
                GL.Color3(_model3D.color[i]);
                GL.Vertex3(_model3D.r[i]);
            }

            _model3D.NextStep();

            GL.End();

            GetSnapShot();
            SwapBuffers();
        }

        /*private double size2 = 0;
        void GetSizeImageinBytes(object bitmap)
        {
            long size = 0;

            using (Stream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, bitmap);
                //Console.WriteLine((float)stream.Length/1024);
                size2 += (double)stream.Length/(1024.0*1024.0);
                Console.WriteLine(size2);
            }
        }*/

        //Image[] bitmaps = new Image[300];
        //private int index = 0;

        void GetSnapShot()
        {
            try
            {
                var snapShotBmp = new Bitmap(Width, Height);
                BitmapData bmpData = snapShotBmp.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                GL.ReadPixels(0, 0, Width, Height, OpenTK.Graphics.PixelFormat.Bgr, PixelType.UnsignedByte, bmpData.Scan0);
                snapShotBmp.UnlockBits(bmpData);
                //snapShotBmp.Save(string.Format(@"D:\С_2015\GravitatioanlSimulation\GravitatioanlSimulation_VideoGenerator\GravitatioanlSimulation 2\GravitatioanlSimulation\bin\x64\Release\result\image{0}.png", number));

                //GetSizeImageinBytes(bmpData);

                //bitmaps[index] = (Image)snapShotBmp.Clone();
                //index++;
                

                _writer.Write(snapShotBmp);
                //snapShotBmp.Dispose();

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
