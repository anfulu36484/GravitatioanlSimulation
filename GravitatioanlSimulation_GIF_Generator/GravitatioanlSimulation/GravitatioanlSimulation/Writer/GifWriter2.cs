using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GravitatioanlSimulation.Writer
{
    class GifWriter2:IWriter
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
