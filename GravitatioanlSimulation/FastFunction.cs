using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GravitatioanlSimulation
{
    class FastFunction
    {
        //velocity  i
        float[] Vx_1; 
        float[] Vy_1;
        float[] Vz_1;

        //position i
        public float[] Rx_1; 
        public float[] Ry_1;
        public float[] Rz_1;

        //velocity i + 1
        float[] Vx_2;
        float[] Vy_2;
        float[] Vz_2;

        //position i + 1
        float[] Rx_2; 
        float[] Ry_2;
        float[] Rz_2;

        /// <summary>
        /// Безразмерная величина, показывающая во сколько раз масса объекта отличается от массы солнца
        /// </summary>
        readonly float[] k;

        public readonly Color[] color;

        /// <summary>
        /// S = масса солнца  * гравитационную постоянную (G)
        /// </summary>
        private readonly float S;

        public readonly int CountOfObjects;

        private float dt;

        public FastFunction(float[] velocity_x,
            float[] velocity_y,
            float[] velocity_z,
            float[] position_x,
            float[] position_y,
            float[] position_z,
            float[] k,
            Color[] color,
            float S,
            float dt)
        {
            Vx_1 = velocity_x;
            Vy_1 = velocity_y;
            Vz_1 = velocity_z;
            Rx_1 = position_x;
            Ry_1 = position_y;
            Rz_1 = position_z;
            this.k = k;
            this.color = color;
            this.S = S;
            this.dt = dt;
            CountOfObjects = velocity_x.Length;


            Rx_2 = new float[CountOfObjects];
            Ry_2 = new float[CountOfObjects];
            Rz_2 = new float[CountOfObjects];

            Vx_2 = new float[CountOfObjects];
            Vy_2 = new float[CountOfObjects];
            Vz_2 = new float[CountOfObjects];

        }


        void SolvePosition(int i)
        {
            Rx_2[i] = Rx_1[i] + Vx_2[i]*dt;
            Ry_2[i] = Ry_1[i] + Vy_2[i]*dt;
            Rz_2[i] = Rz_1[i] + Vz_2[i]*dt;
        }


        void SolveVelocity(int i)
        {
            float sumX = 0, sumY = 0, sumZ = 0;

            for (int j = 0; j < CountOfObjects; j++)
            {
                if (i != j)
                {
                    float Rx_ij = Rx_1[j] - Rx_1[i];
                    float Ry_ij = Ry_1[j] - Ry_1[i];
                    float Rz_ij = Rz_1[j] - Rz_1[i];

                    float denominator = (float) Math.Pow(Rx_ij*Rx_ij + Ry_ij*Ry_ij + Rz_ij*Rz_ij, 1.5);

                    sumX += k[j] * Rx_ij / denominator;
                    sumY += k[j] * Ry_ij / denominator;
                    sumZ += k[j] * Rz_ij / denominator;
                }
            }
            Vx_2[i] = Vx_1[i] + S*sumX;
            Vy_2[i] = Vy_2[i] + S*sumY;
            Vz_2[i] = Vz_2[i] + S*sumZ;

        }

  
        public Action<FastFunction> Update;


        void Solve()
        {

            for (int i = 0; i < CountOfObjects; i++)
            {
                SolveVelocity(i);
                SolvePosition(i);
            }

        }

        public void EulerMethodRun()
        {
            int x = 0;
            while (true)
            {
                Update(this);
                //Thread.Sleep(2);

                Solve();

                Vx_2.CopyTo(Vx_1, 0);
                Vy_2.CopyTo(Vy_1, 0);
                Vz_2.CopyTo(Vz_1, 0);

                Rx_2.CopyTo(Rx_1, 0);
                Ry_2.CopyTo(Ry_1, 0);
                Rz_2.CopyTo(Rz_1, 0);
                Console.WriteLine(Vx_1[5]);
                x++;
            }
  
        }

    }
}
