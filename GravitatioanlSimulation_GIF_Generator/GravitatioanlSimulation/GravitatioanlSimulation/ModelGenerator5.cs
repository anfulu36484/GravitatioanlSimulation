using System;
using System.Drawing;
using OpenTK;

namespace GravitatioanlSimulation
{
    class ModelGenerator5:IModelGenerator
    {
        public Model Generate()
        {
            int count = 1000;
            Vector3[] v = new Vector3[count];
            Vector3[] r = new Vector3[count];
            Random random = new Random();
            Color[] color = new Color[count];
            float[] m = new float[count];




            for (int i = 0; i < count; i++)
            {
                v[i] = new Vector3(0,
                    0,
                    0);
                /* r[i] = new Vector3((float)random.NextDouble() * 1,
                     (float)random.NextDouble() * 1,
                     (float)random.NextDouble() * 1);*/
                r[i] = new Vector3((float)random.NextDouble() ,
                                    (float)random.NextDouble() ,
                                    (float)random.NextDouble() );

                m[i] = random.Next(10, 100);
                color[i] = Color.FromArgb(random.Next(100, 200), random.Next(100, 200), random.Next(100, 200));
            }
            Model model = new Model(r, v, m, color);
            model.G = 0.1f;
            return model;
        }
    }
}
