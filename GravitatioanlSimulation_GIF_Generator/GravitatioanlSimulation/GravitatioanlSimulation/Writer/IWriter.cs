using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GravitatioanlSimulation
{
    interface IWriter
    {
        void Initialization(string OutputFile,int Width,int  Height);

        void Write(Bitmap bitmap);

        void SaveResult();
    }
}
