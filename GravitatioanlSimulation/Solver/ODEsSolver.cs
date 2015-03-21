using System;
using System.Linq;
using DotNumerics.ODE;

namespace GravitatioanlSimulation
{
    class ODEsSolver
    {
        private xBaseOdeRungeKutta _odeRungeKutta;

        public ODEsSolver()
        {
            _odeRungeKutta = new OdeExplicitRungeKutta45();
        }

        public double[,] SolveRungeKutta(OdeFunction odeFunction, double[] initialValues, double[] tauRange)
        {
            _odeRungeKutta.InitializeODEs(odeFunction, initialValues.Count());


            return _odeRungeKutta.Solve(initialValues,tauRange);
        }

        public double[,] SolveEuler(OdeFunction odeFunction, double[] initialValues, int countOfStep, double dt)
        {
            double[] x = initialValues;
            double[,] data = new double[countOfStep+1,initialValues.Count()];

            for (int i = 0; i < data.GetLength(1); i++)
            {
                data[0, i] = initialValues[i];
            }


            for (int i = 0; i < countOfStep; i++)
            {
                double[] result = odeFunction(0, x);
                for (int j = 0; j < initialValues.Length; j++)
                {
                    x[j] = x[j] + dt*result[j];
                    data[i+1, j] = x[j];
                }

            }

            return data;
        }





        

    }
}
