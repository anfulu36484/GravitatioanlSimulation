using System;
using System.Drawing;
using OpenTK;

namespace GravitatioanlSimulation.Models._3D
{
    class Model3DGenerator2:IModel3DGenerator
    {
        public Model3D Generate()
        {
            int count = 1000;
            Vector3[] v = new Vector3[count];
            Vector3[] r = new Vector3[count];
            Random random = new Random();
            Color[] color = new Color[count];
            float[] m = new float[count];


            v[0] = new Vector3(0,
                    0,
                    0);
            r[0] = new Vector3(0,
                0,
                0);
            m[0] = 1000000000;
            color[0] = Color.FromArgb(random.Next(100, 200), random.Next(100, 200), random.Next(100, 200));

            for (int i = 1; i < count; i++)
            {
                v[i] = new Vector3((float)random.NextDouble() * (random.NextDouble() > 0.5 ? 1 : -1),
                    (float)random.NextDouble() * (random.NextDouble() > 0.5 ? 1 : -1),
                    (float)random.NextDouble() * (random.NextDouble() > 0.5 ? 1 : -1));
                r[i] = new Vector3((float)random.NextDouble() * 100,
                    (float)random.NextDouble() * 100,
                    (float)random.NextDouble() * 100);
                m[i] = random.Next(10000, 100000);
                color[i] = Color.FromArgb(random.Next(100, 200), random.Next(100, 200), random.Next(100, 200));
            }
            Model3D model3D = new Model3D(r, v, m, color);
            model3D.G = 0.00001f;
            model3D.dt = 0.01f;
            return model3D;
        }
    }
}
