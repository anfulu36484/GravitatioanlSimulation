using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GravitatioanlSimulation.Writer;

namespace GravitatioanlSimulation.Models._2D
{
    class _2DRendrer:IRender
    {
        private Model2D model2d;

        private int Wigth = 1000;
        private int Height = 1000;

        private int halfWigth;
        private int halfHeight;

        private Color[,] background;
        private FastBitmapCreator fastBitmapCreator;
        private IWriter writer;

        public _2DRendrer(Model2D model2d, IWriter writer)
        {
            this.model2d = model2d;
            this.writer = writer;
            fastBitmapCreator = new FastBitmapCreator();

            halfHeight = Height/2;
            halfWigth = Wigth/2;
        }

        void FillBackground(Color color)
        {
            background = new Color[Height,Wigth];
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Wigth; j++)
                    background[i, j] = color;
        }

        public void Run()
        {
            writer.Initialization("output2d.gif", Wigth, Height);
            FillBackground(Color.Blue);
        }



        public void Render()
        {
            
            Color[,] frame = new Color[background.GetLength(0), background.GetLength(1)];
            Array.Copy(background,0,frame,0,background.Length);

            for (int i = 0; i < model2d.dimension; i++)
            {
                if (model2d.r[i].X > -halfWigth+1  &&
                    model2d.r[i].X < halfWigth-1  &&
                    model2d.r[i].Y > -halfHeight+1  &&
                    model2d.r[i].Y < halfHeight-1 )
                {
                    int x = Convert.ToInt16(model2d.r[i].X + halfWigth);
                    int y = Convert.ToInt16(model2d.r[i].Y + halfHeight);

                    frame[x, y] = model2d.color[i];
                }
    
            }

            Bitmap bitmap = fastBitmapCreator.Create(frame);

            writer.Write(bitmap);

            model2d.NextStep();



        }

        public void Stop()
        {
            writer.SaveResult();
        }
    }
}
