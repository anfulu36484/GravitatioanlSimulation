﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Video.FFMPEG;
using OpenTK;
using OpenTK.Graphics;


namespace GravitatioanlSimulation
{
    class RenderOpenTK:MyGameWindow
    {
        private readonly Model _model;
        private VideoFileWriter _videoFileWriterwriter;
       


        /// <summary>Creates a 1200x1000 window with the specified title.</summary>
        public RenderOpenTK(Model model)
            : base(1200, 1000, GraphicsMode.Default, "Gravitatioanl Simulation")
        {
            _model = model;
            _videoFileWriterwriter = new VideoFileWriter();

            


            _videoFileWriterwriter.Open("Simulation.avi", Width, Height, 25, VideoCodec.MPEG4, 100000000);
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
                var snapShotBmp = new Bitmap(Width, Height);
                BitmapData bmpData = snapShotBmp.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                GL.ReadPixels(0, 0, Width, Height, OpenTK.Graphics.PixelFormat.Bgr, PixelType.UnsignedByte, bmpData.Scan0);
                snapShotBmp.UnlockBits(bmpData);
                //snapShotBmp.Save(string.Format(@"D:\С_2015\GravitatioanlSimulation\GravitatioanlSimulation_VideoGenerator\GravitatioanlSimulation\GravitatioanlSimulation\bin\Release\result\image{0}.png",number));
                _videoFileWriterwriter.WriteVideoFrame(snapShotBmp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }


        public void Stop()
        {
            _videoFileWriterwriter.Close();
        }
    }
}