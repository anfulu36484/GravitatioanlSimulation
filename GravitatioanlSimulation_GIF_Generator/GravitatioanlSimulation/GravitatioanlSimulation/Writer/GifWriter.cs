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
    class GifWriter:IWriter
    {
        private GifBitmapEncoder _gifBitmapEncoder;

        private string _outputFile;

        public void Initialization(string OutputFile, int Width, int Height)
        {
            _gifBitmapEncoder = new GifBitmapEncoder();
            _outputFile = OutputFile;
        }

        public void Write(Bitmap bitmap)
        {
            var src = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
            bitmap.GetHbitmap(),
            IntPtr.Zero,
            Int32Rect.Empty,
            BitmapSizeOptions.FromEmptyOptions());
            _gifBitmapEncoder.Frames.Add(BitmapFrame.Create(src));
        }

        public void SaveResult()
        {
            using (FileStream fs = new FileStream(_outputFile, FileMode.Create))
            {
                _gifBitmapEncoder.Save(fs);
            }
        }
    }
}
