using System;
using System.Drawing;
using OpenTK;

namespace GravitatioanlSimulation.Models._3D
{
    class Model3DGenerator9:IModel3DGenerator
    {
        private Random random;



        public Model3DGenerator9()
        {
            random = new Random();
        }

        float GetRandom(float min, float max)
        {
            return (float)random.NextDouble() * (max - min) + min;
        }

        /// <summary>
        /// Перевод в радианы
        /// </summary>
        /// <param name="valueInDegrees">Значение угла в градусах</param>
        /// <returns>Значение угла в радианах</returns>
        float TransferToRadians(float valueInDegrees)
        {
            return valueInDegrees * (float)Math.PI / 180;
        }

        Vector3 GetRandomObjectPosition(float maxRadius)
        {
            //https://ru.wikipedia.org/wiki/%D1%F4%E5%F0%E8%F7%E5%F1%EA%E0%FF_%F1%E8%F1%F2%E5%EC%E0_%EA%EE%EE%F0%E4%E8%ED%E0%F2
            //Позиция объекта в сферических координатах
            float r = GetRandom(0, maxRadius);//r - расстояние от начала координат
            float θ = TransferToRadians(GetRandom(0, 180)); //Зенитный угол
            float φ = TransferToRadians(GetRandom(0, 359)); //Азимутный угол
                                                            //Переход к декартовой системе координат
            return new Vector3(r * (float)(Math.Sin(θ) * Math.Cos(φ)),
                               r * (float)(Math.Sin(θ) * Math.Sin(φ)),
                               r * (float)Math.Cos(θ));
        }

        public Model3D Generate()
        {
            int count = 1000;
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
                r[i] = GetRandomObjectPosition(100);
                m[i] = random.Next(10000, 100000);
                color[i] = Color.FromArgb(random.Next(100, 200), random.Next(100, 200), random.Next(100, 200));
            }
            Model3D model3D = new Model3D(r, v, m, color);
            model3D.G = 0.00001f;

            return model3D;
        }
    }
}
