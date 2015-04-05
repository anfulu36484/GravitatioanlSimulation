using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitatioanlSimulation
{
    class PoolOfSelectialObject
    {
        private List<CelestialObject> _objects = new List<CelestialObject>();

        public CelestialObject[] Objects
        {
            get { return _objects.ToArray(); }
        }

        private int _index;

        public List<double> _initialValues = new List<double>(); 

        public void Add(CelestialObject celestialObject)
        {
            for (int i = 0; i < celestialObject.Position.Count(); i++)
            {
                celestialObject.IndexPosition[i] = _index;
                _initialValues.Add(celestialObject.Position[i]);
                _index++;

                celestialObject.IndexVelocity[i] = _index;
                _initialValues.Add(celestialObject.Velocity[i]);
                _index++;
            }
            _objects.Add(celestialObject);
        }



    }
}
