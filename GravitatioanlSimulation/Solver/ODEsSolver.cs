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

    }
}
