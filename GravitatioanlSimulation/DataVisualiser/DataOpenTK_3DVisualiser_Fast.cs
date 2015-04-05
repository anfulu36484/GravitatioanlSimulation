using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GravitatioanlSimulation.DataVisualiser;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;

namespace GravitatioanlSimulation
{
    class DataOpenTK_3DVisualiser_Fast : GameWindow

    {
        /// <summary>Creates a 1200x1000 window with the specified title.</summary>
        public DataOpenTK_3DVisualiser_Fast()
            : base(1200, 1000, GraphicsMode.Default, "Gravitatioanl Simulation")
        {
            VSync = VSyncMode.On;
        }

        private FastFunction _fastFunction;

        public void GetData(FastFunction fastFunction)
        {
            _fastFunction = fastFunction;
        }


        /// <summary>Load resources here.</summary>
        /// <param name="e">Not used.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);
        }

        /// <summary>
        /// Called when your window is resized. Set your viewport here. It is also
        /// a good place to set up your projection matrix (which probably changes
        /// along when the aspect ratio of your window).
        /// </summary>
        /// <param name="e">Not used.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 5000.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        /// <summary>
        /// Called when it is time to setup the next frame. Add you game logic here.
        /// </summary>
        /// <param name="e">Contains timing information for framerate independent logic.</param>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (Keyboard[Key.Escape])
                Exit();
        }

        /// <summary>
        /// Called when it is time to render the next frame. Add your rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            Matrix4 modelview = Matrix4.LookAt(1200, 1200, 1200, 0, 0, 0, 0, 1, 0);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            GL.PointSize(1);

            GL.Begin(BeginMode.Points);



            if (_fastFunction != null)
            {

                for (int i = 0; i < _fastFunction.length; i++)
                {
                    GL.Color3(_fastFunction.color[i]);
                    GL.Vertex3(
                        _fastFunction.position_x[i] /*+ 600*/,
                        _fastFunction.position_y[i] /*+ 600*/,
                        _fastFunction.position_z[i] /*+ 600*/);
                   // Debug.WriteLine(_celestialObjects[i].Position[0]);
                }
            }


            GL.End();


           /* GL.Color3(Color.White);
            GL.Begin(BeginMode.Lines);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(1500, 0, 0);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 1500, 0);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 1500);
            GL.End();

            */
            SwapBuffers();
        }


    }
}

