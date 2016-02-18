using OpenTK;
using System.Drawing;

namespace GravitatioanlSimulation
{
    class Model
    {
        public Vector3[] r;
        public Vector3[] v;

        public Vector3[] r_temp;
        public Vector3[] v_temp;

        public float[] m;
        public Color[] color;

        public float G = (float)6.67e-10;
        public float dt = 0.1f;

        public int dimension;

        public Model(Vector3[] r, Vector3[] v, float[] m, Color[] color)
        {
            this.r = r;
            this.v = v;
            this.m = m;
            this.color = color;
            dimension = r.Length;
            r_temp = new Vector3[dimension];
            v_temp = new Vector3[dimension];
        }


        public void NextStep()
        {
            for (int i = 0; i < dimension; i++)
            {
                Vector3 sum=new Vector3();
                for (int j = 0; j < dimension; j++)
                {
                    if(i!=j)
                    {
                        Vector3 rij = r[j] - r[i];
                        sum += (m[j]/rij.Length)*rij;
                    }
                }
                v_temp[i] = v[i] + G*dt*sum;
                r_temp[i] = r[i] + v[i]*dt;
            }

            for (int i = 0; i < dimension; i++)
            {
                v[i] = v_temp[i];
                r[i] = r_temp[i];
            }
        }
    }
}
