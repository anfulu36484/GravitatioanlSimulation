using System;
using System.Drawing;
using OpenTK;

namespace GravitatioanlSimulation
{
    class ModelGenerator3:IModelGenerator
    {
        public Model Generate()
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
            Model model = new Model(r, v, m, color);
            model.G = 0.00001f;
            model.dt = 0.01f;
            return model;
        }
    }
}
