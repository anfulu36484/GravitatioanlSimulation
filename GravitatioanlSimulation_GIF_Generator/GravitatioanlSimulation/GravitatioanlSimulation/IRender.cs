using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitatioanlSimulation
{
    interface IRender
    {
        void Run();
        void Render();

        void Stop();
    }
}
