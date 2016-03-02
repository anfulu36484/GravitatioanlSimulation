using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    abstract class ModelGenerator :Descriptor
    {
        public abstract Model Generate();

    }
}
