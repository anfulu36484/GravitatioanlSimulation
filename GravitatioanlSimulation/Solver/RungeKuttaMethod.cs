using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNumerics.ODE;

namespace GravitatioanlSimulation.Solver
{
    class RungeKuttaMethod
    {
        private xBaseOdeRungeKutta _odeRungeKutta;

        public RungeKuttaMethod(OdeFunction odeFunction, double[] initialValues, double[] tauRange)
        {
            _odeRungeKutta = new OdeExplicitRungeKutta45();
            _odeRungeKutta.InitializeODEs(odeFunction, initialValues.Count());
        }

       /* public double[] SolveRungeKutta()
        {
            


            return _odeRungeKutta.Solve()
        }*/
    }
}
