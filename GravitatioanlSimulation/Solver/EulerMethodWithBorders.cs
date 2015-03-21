using System;

namespace GravitatioanlSimulation.Solver
{
    class EulerMethodWithBorders :ISolver
    {
        private readonly Func<double, double[], double[]> _function;
        private double[] _values;
        private double _dt;
        private readonly double[] _limitsMax;
        private readonly double[] _limitsMin;
        private readonly CelestialObject[] _celestialObjects;

        public EulerMethodWithBorders(
            Func<double, double[], double[]> function,
            double[] values,
            double dt,
            double[] limitsMax,
            double[] limitsMin,
            CelestialObject[] celestialObjects)
        {
            _function = function;
            _values = values;
            _dt = dt;
            _limitsMax = limitsMax;
            _limitsMin = limitsMin;
            _celestialObjects = celestialObjects;
        }

        void ChangeSpeedOfBodiesWhichDepartedForBarrier()
        {
            for (int i = 0; i < _limitsMax.Length; i++)
            {
                for (int j = 0; j < _celestialObjects.Length; j++)
                {
                    if (_values[_celestialObjects[j].IndexPosition[i]] > _limitsMax[i])
                    {
                        if (_values[_celestialObjects[j].IndexPosition[i]] > 0)
                            _values[_celestialObjects[j].IndexVelocity[i]] *= -1;
                    }
                    if (_values[_celestialObjects[j].IndexPosition[i]] < _limitsMin[i])
                    {
                        if (_values[_celestialObjects[j].IndexPosition[i]] < 0)
                            _values[_celestialObjects[j].IndexVelocity[i]] *= -1;
                    }
                }
            }
        }

        public double[] Solve()
        {
            double[] result = _function(0,_values);
            for (int j = 0; j < _values.Length; j++)
            {
                _values[j]+= _dt * result[j];
            }
            ChangeSpeedOfBodiesWhichDepartedForBarrier();
            return _values;
        }
    }
}
