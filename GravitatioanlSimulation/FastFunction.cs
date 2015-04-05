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
        public float[] velocity_x;
        public float[] velocity_y;
        public float[] velocity_z;

        public float[] position_x;
        public float[] position_y;
        public float[] position_z;


        public float[] temp_velocity_x;
        public float[] temp_velocity_y;
        public float[] temp_velocity_z;

        public float[] temp_position_x;
        public float[] temp_position_y;
        public float[] temp_position_z;


        private readonly float[] mass;
        public readonly Color[] color;
        private readonly float G;
        public readonly int length;

        private float dt;

        public FastFunction(float[] velocity_x,
            float[] velocity_y,
            float[] velocity_z,
            float[] position_x,
            float[] position_y,
            float[] position_z,
            float[] mass,
            Color[] color,
            float G,
            float dt)
        {
            this.velocity_x = velocity_x;
            this.velocity_y = velocity_y;
            this.velocity_z = velocity_z;
            this.position_x = position_x;
            this.position_y = position_y;
            this.position_z = position_z;
            this.mass = mass;
            this.color = color;
            this.G = G;
            this.dt = dt;
            length = velocity_x.Length;


            temp_position_x = new float[length];
            temp_position_y = new float[length];
            temp_position_z = new float[length];

            temp_velocity_x = new float[length];
            temp_velocity_y = new float[length];
            temp_velocity_z = new float[length];

        }


        float GetRij(int i, int j)
        {
            double outputRij = 0;

            outputRij += Math.Pow(position_x[j] - position_x[i], 2);
            outputRij += Math.Pow(position_y[j] - position_y[i], 2);
            outputRij += Math.Pow(position_z[j] - position_z[i], 2);

            float temp = (float) Math.Sqrt(outputRij);
            if( Double.IsNaN(temp))
                throw new Exception();

            return (float)Math.Sqrt(outputRij);
        }

        float CalcVelocity_x(int numberOfObject)
        {
            float velocity = 0;
            for (int j = 0; j < length; j++)
            {
                if (j == numberOfObject)
                    continue;
                float rij = GetRij(numberOfObject, j);
                velocity += mass[j] * (position_x[j] - position_x[numberOfObject]) / (float)Math.Pow(rij, 3);
            }

            return G * velocity;
        }

        float CalcVelocity_y(int numberOfObject)
        {
            float velocity = 0;
            for (int j = 0; j < length; j++)
            {
                if (j == numberOfObject)
                    continue;
                float rij = GetRij(numberOfObject, j);

                if (Double.IsNaN(position_y[j] - position_y[numberOfObject]))
                    throw new Exception();
                if (Double.IsNaN(mass[j] * (position_y[j] - position_y[numberOfObject]) / (float)Math.Pow(rij, 3)))
                    throw new Exception();
                velocity += mass[j] * (position_y[j] - position_y[numberOfObject]) / (float)Math.Pow(rij, 3);
            }
            if ((Double.IsNaN(G * velocity)))
                throw new Exception();
            return G * velocity;
        }

        float CalcVelocity_z(int numberOfObject)
        {
            float velocity = 0;
            for (int j = 0; j < length; j++)
            {
                if (j == numberOfObject)
                    continue;
                float rij = GetRij(numberOfObject, j);
                velocity += mass[j] * (position_z[j] - position_z[numberOfObject]) / (float)Math.Pow(rij, 3);
            }
            return G * velocity;
        }

        public Action<FastFunction> action;






        void Solve()
        {


            for (int numberOfObject = 0; numberOfObject < length; numberOfObject++)
            {

                temp_position_x[numberOfObject] = velocity_x[numberOfObject];
                if (Double.IsNaN(position_x[numberOfObject]))
                    throw new Exception();
               
                temp_position_y[numberOfObject] = velocity_y[numberOfObject];
                temp_position_z[numberOfObject] = velocity_z[numberOfObject];

                if (Double.IsNaN(position_y[numberOfObject]))
                    throw new Exception();
                if (Double.IsNaN(position_z[numberOfObject]))
                    throw new Exception();

                temp_velocity_x[numberOfObject] = CalcVelocity_x(numberOfObject);
                temp_velocity_y[numberOfObject] = CalcVelocity_y(numberOfObject);
                temp_velocity_z[numberOfObject] = CalcVelocity_z(numberOfObject);

                if (Double.IsNaN(position_y[numberOfObject]))
                    throw new Exception();
                if (Double.IsNaN(position_z[numberOfObject]))
                    throw new Exception();

            }

            
            temp_velocity_x.CopyTo(velocity_x, 0);
            temp_velocity_y.CopyTo(velocity_y,0);
            temp_velocity_z.CopyTo(velocity_z,0);

            temp_position_x.CopyTo(position_x,0);
            temp_position_y.CopyTo(position_y,0);
            temp_position_z.CopyTo(position_z,0);
        }

        public void EulerMethodRun()
        {
            while (true)
            {
                //action(this);
                Thread.Sleep(2);

                Solve();

                for (int numberOfObject = 0; numberOfObject < length; numberOfObject++)
                {
                    position_x[numberOfObject] *= dt;
                    if (Double.IsNaN(position_x[numberOfObject]))
                        throw new Exception();
                    position_y[numberOfObject] *= dt;
                    if (Double.IsNaN(position_y[numberOfObject]))
                        throw new Exception();
                    position_z[numberOfObject] *= dt;

                    velocity_x[numberOfObject] *= dt;
                    velocity_y[numberOfObject] *= dt;
                    velocity_z[numberOfObject] *= dt;
                }
            }
            
        }

        

    }
}
