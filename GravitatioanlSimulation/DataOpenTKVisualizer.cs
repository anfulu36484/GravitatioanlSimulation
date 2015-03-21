// Released to the public domain. Use, modify and relicense at will.

using System;
using System.Diagnostics;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using Tao.OpenGl;

namespace GravitatioanlSimulation
{
    class DataOpenTKVisualizer : GameWindow
    {
        private CelestialObject[] _celestialObjects;


        /// <summary>Creates a 800x600 window with the specified title.</summary>
        public DataOpenTKVisualizer()
            : base(1200, 1000, GraphicsMode.Default, "Gravitatioanl Simulation")
        {
            VSync = VSyncMode.On;
        }

        /// <summary>Load resources here.</summary>
        /// <param name="e">Not used.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Black);
            //GL.Enable(EnableCap.DepthTest);

            int w = Width;
            int h = Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, w, 0, h, -1, 1); // Верхний левый угол имеет кооординаты(0, 0)
            GL.Viewport(0, 0, w, h); // Использовать всю поверхность GLControl под рисование
            
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


        public void GetData(CelestialObject[] celestialObjects)
        {
            _celestialObjects = celestialObjects;
        }


        /// <summary>
        /// Called when it is time to render the next frame. Add your rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();


            GL.PointSize(3);
           


            GL.Begin(BeginMode.Points);

            //_celestialObjects.UpdatePositionOfObjects();


            


            if (_celestialObjects != null)
            {

                for (int i = 0; i < _celestialObjects.Length; i++)
                {
                    GL.Color3(_celestialObjects[i].Color);
                    GL.Vertex2(_celestialObjects[i].Position[0] + 600, _celestialObjects[i].Position[1] + 500);
                }
            }

            GL.End();
            


            SwapBuffers();
        }
    }
}