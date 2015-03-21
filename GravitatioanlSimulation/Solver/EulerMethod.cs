using System;

namespace GravitatioanlSimulation.Solver
{
    class EulerMethod :ISolver
    {
        private readonly Func<double, double[], double[]> _function;
        private double[] _values;
        private double _dt;

        public EulerMethod(Func<double,double[],double[]> function, double[] values, double dt)
        {
            _function = function;
            _values = values;
            _dt = dt;
        }

        public double[] Solve()
        {
            double[] result = _function(0,_values);
            for (int j = 0; j < _values.Length; j++)
            {
                _values[j]+= _dt * result[j];
            }
            return _values;
        }
    }
}
