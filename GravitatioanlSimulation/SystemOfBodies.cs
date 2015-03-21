using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GravitatioanlSimulation.Solver;

namespace GravitatioanlSimulation
{
    class SystemOfBodies
    {
        private readonly CelestialObject[] _celestialObjects;
        private readonly ISolver _solver;


        public SystemOfBodies(CelestialObject[] celestialObjects, ISolver solver)
        {
            _celestialObjects = celestialObjects;
            _solver = solver;
        }


        public Action<CelestialObject[]> action;

        public void UpdatePositionOfObjects()
        {
            Thread task = new Thread(Update);
            task.Start();
        }

        private void Update()
        {
            if (action != null)
            {
                while (true)
                {
                    Thread.Sleep(2);
                    double[] data = _solver.Solve();
                    for (int i = 0; i < _celestialObjects.Length; i++)
                    {
                        _celestialObjects[i].UpdatePosition(data);
                    }
                    action(_celestialObjects);
                }
            }
        }


        public CelestialObject this[int index]
        {
            get { return _celestialObjects[index]; }
        }

        public int Count()
        {
            return _celestialObjects.Count();
        }
    }
}
