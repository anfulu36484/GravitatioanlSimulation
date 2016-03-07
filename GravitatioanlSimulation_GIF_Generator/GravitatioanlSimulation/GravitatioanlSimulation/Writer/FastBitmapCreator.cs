using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace GravitatioanlSimulation.Writer
{
    class FastBitmapCreator
    {
        public Bitmap Create(Color[,] data)
        {
            int width = data.GetLength(0);
            int height = data.GetLength(1);

            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData bmData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);


            int stride = bmData.Stride;

            byte[] array = new byte[stride * height];

            int index = 0;

            for (int y = height - 1; y >= 0; y--)
            {
                for (int x = 0; x < width; x++)
                {
                    array[index++] = data[x, y].B;
                    array[index++] = data[x, y].G;
                    array[index++] = data[x, y].R;
                }
            }

            IntPtr scan0 = bmData.Scan0;
            Marshal.Copy(array, 0, scan0, stride * bitmap.Height);
            bitmap.UnlockBits(bmData);

            return bitmap;
        }
    }
}
