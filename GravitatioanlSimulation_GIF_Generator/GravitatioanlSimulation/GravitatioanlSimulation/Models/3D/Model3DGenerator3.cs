using System;
using System.Drawing;
using OpenTK;

namespace GravitatioanlSimulation.Models._3D
{
    class Model3DGenerator3:IModel3DGenerator
    {
        public Model3D Generate()
        {
            int count = 10;
            Vector3[] v = new Vector3[count];
            Vector3[] r = new Vector3[count];
            Random random = new Random();
            Color[] color = new Color[count];
            float[] m = new float[count];




            for (int i = 0; i < count; i++)
            {
                v[i] = new Vector3((float)random.NextDouble() * (random.NextDouble() > 0.5 ? 1 : -1),
                    (float)random.NextDouble() * (random.NextDouble() > 0.5 ? 1 : -1),
                    (float)random.NextDouble() * (random.NextDouble() > 0.5 ? 1 : -1));
                r[i] = new Vector3((float)random.NextDouble() * 100,
                    (float)random.NextDouble() * 100,
                    (float)random.NextDouble() * 100);
                m[i] = random.Next(1000000, 10000000);
                color[i] = Color.FromArgb(random.Next(100, 200), random.Next(100, 200), random.Next(100, 200));
            }
            Model3D model3D = new Model3D(r, v, m, color);
            model3D.G = 0.00001f;
            model3D.dt = 0.01f;
            return model3D;
        }
    }
}
