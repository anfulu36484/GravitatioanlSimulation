using System.Drawing;

namespace GravitatioanlSimulation
{
    interface IWriter
    {
        void Initialization(string OutputFile,int Width,int  Height);

        void Write(Bitmap bitmap);

        void SaveResult();
    }
}
