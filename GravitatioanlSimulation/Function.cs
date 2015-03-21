using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitatioanlSimulation
{
    internal class Function
    {
        public double G = 6.6719199999999999e-10;

        private CelestialObject[] obj;

        private int dimensionOfSpace;

        public Function(CelestialObject[] obj, int dimensionOfSpace)
        {
            this.obj = obj;
            this.dimensionOfSpace = dimensionOfSpace;
            output = new double[obj.Length*dimensionOfSpace*2];
        }

        double GetRij(int i, int j, double[] y)
        {
            double outputRij = 0;
            for (int k = 0; k < dimensionOfSpace; k++)
            {
                outputRij+= Math.Pow(y[obj[j].IndexPosition[k]] - y[obj[i].IndexPosition[k]],2);
            }
            return Math.Sqrt(outputRij);
        }


        double CalcVelocity(int numberOfObject, int dimension, double[] y)
        {
            double velocity = 0;
            for (int j = 0; j < obj.Length; j++)
            {
                if(j==numberOfObject)
                    continue;
                double rij = GetRij(numberOfObject, j, y);
                velocity += obj[j].Mass * (y[obj[j].IndexPosition[dimension]] - y[obj[numberOfObject].IndexPosition[dimension]]) / Math.Pow(rij, 3);
            }
            return G*velocity;
        }

        private double[] output;

        public double[] Solve(double t, double[] y)
        {
            for (int numberOfObject = 0; numberOfObject < obj.Length; numberOfObject++)
            {
                for (int dimension = 0; dimension < dimensionOfSpace; dimension++)
                {
                    output[obj[numberOfObject].IndexPosition[dimension]] =
                        y[obj[numberOfObject].IndexVelocity[dimension]];
                    output[obj[numberOfObject].IndexVelocity[dimension]] = CalcVelocity(numberOfObject, dimension, y);
                }
            }
            return output;
        }
    }
}
