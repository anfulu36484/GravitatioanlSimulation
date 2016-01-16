using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;

namespace GravitatioanlSimulation.DataVisualiser
{
    public static class FPSCounter
    {
        #region Timing

        private static double _time = 0.0;
        private static double _frames = 0.0;
        private static int _fps = 0;
        public static int FPS { get { return _fps; } }

        public static void Calculate(double time)
        {
            _time += time;

            if (_time < 1.0)
            {
                _frames++;
            }
            else
            {
                _fps = (int)_frames;
                _time = 0.0;
                _frames = 0.0;
            }
        }

        #endregion

        #region Display

        private static int fontHeight = 13;
        private static OpenTK.Graphics.TextPrinter textPrinter;
        private static Font font = new Font("Arial Black", fontHeight, FontStyle.Regular);

        public static void Initialize()
        {
            textPrinter = new OpenTK.Graphics.TextPrinter();
        }

        public static void Render(params string[] message)
        {
            textPrinter.Begin();

            foreach (string msg in message)
            {
                textPrinter.Print(msg, font, Color.Yellow);
                GL.Translate(0, fontHeight, 0);
            }

            textPrinter.End();
        }

        #endregion
    }
}
