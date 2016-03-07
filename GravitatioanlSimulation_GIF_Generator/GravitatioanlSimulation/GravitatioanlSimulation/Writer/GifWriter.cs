using System.Drawing;
using System.IO;

namespace GravitatioanlSimulation.Writer
{
    class GifWriter:IWriter
    {
        private Gif gif;

        private string _outputFile;

        public void Initialization(string OutputFile, int Width, int Height)
        {
            gif = new Gif();
            _outputFile = OutputFile;
            
        }

        public void Write(Bitmap bitmap)
        {
            gif.AddFrame(bitmap);
        }

        public void SaveResult()
        {
            using (FileStream fs = new FileStream(_outputFile, FileMode.Create))
            {
                gif.Save(fs);
            }
        }
    }
}
