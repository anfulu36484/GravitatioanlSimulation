using System;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;

namespace GravitatioanlSimulation
{
    class DataOpenTK_3DVisualiser : GameWindow

    {
        private IModelGenerator _modelGenerator;
        private Model _model;

        /// <summary>Creates a 1200x1000 window with the specified title.</summary>
        public DataOpenTK_3DVisualiser(IModelGenerator modelGenerator)
            : base(1200, 1000, GraphicsMode.Default, "Gravitatioanl Simulation")
        {
            VSync = VSyncMode.On;
            _modelGenerator = modelGenerator;
        }

        /// <summary>Load resources here.</summary>
        /// <param name="e">Not used.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FPSCounter.Initialize();
            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);


            _model = _modelGenerator.Generate();


            
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

            FPSCounter.Calculate(e.Time);

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

            GL.PointSize(2);

            GL.Begin(BeginMode.Points);


            for (int i = 0; i < _model.dimension; i++)
            {
                GL.Color3(_model.color[i]);
                GL.Vertex3(_model.r[i]);
            }
            _model.NextStep();
            



            GL.End();


            FPSCounter.Render(new string[] {
				"FPS   : " + FPSCounter.FPS,
				"Stars : " + _model.dimension
			});

            SwapBuffers();
        }


    }
}

