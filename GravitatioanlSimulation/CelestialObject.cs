using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitatioanlSimulation
{
    class CelestialObject
    {
        public double Mass { get; set; }
        public double[] Position { get; set; }
        public double[] Velocity { get; set; }

        public int[] IndexPosition;
        public int[] IndexVelocity;

        public Color Color;

        public CelestialObject(double mass, double[] position, double[] velocity, Color color)
        {
            Mass = mass;
            Position = position;
            Velocity = velocity;
            IndexPosition = new int[position.Length];
            IndexVelocity = new int[position.Length];
            Color = color;
        }

        public void UpdatePosition(double[] data)
        {
            for (int i = 0; i < Position.Length; i++)
            {
                Position[i] = data[IndexPosition[i]];
            }
        }
    }
}
