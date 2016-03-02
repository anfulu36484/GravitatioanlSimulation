using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    abstract class Model :Descriptor
    {

        public abstract void NextStep();
    }
}
