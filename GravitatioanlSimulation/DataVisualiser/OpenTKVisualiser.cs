using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;

namespace GravitatioanlSimulation.DataVisualiser
{
    abstract class OpenTKVisualiser:GameWindow
    {
        /// <summary>Creates a 800x600 window with the specified title.</summary>
        public OpenTKVisualiser()
            : base(1200, 1000, GraphicsMode.Default, "Gravitatioanl Simulation")
        {
            VSync = VSyncMode.On;
        }


        protected CelestialObject[] _celestialObjects;

        public void GetData(CelestialObject[] celestialObjects)
        {
            _celestialObjects = celestialObjects;
        }
    }
}
