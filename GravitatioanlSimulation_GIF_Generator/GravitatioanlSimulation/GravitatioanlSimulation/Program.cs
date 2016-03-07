using System;
using System.Diagnostics;
using GravitatioanlSimulation.Models._2D;
using GravitatioanlSimulation.Models._3D;
using GravitatioanlSimulation.Writer;

namespace GravitatioanlSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            //IRender render = new RenderOpenTK(new Model3DGenerator1().Generate(),new GifWriter());
            IRender render = new _2DRendrer(new Model2DGenerator1().Generate(), new GifWriter());
            
            render.Run();
            Stopwatch sw = new Stopwatch();
            
            sw.Start();

            for (int i = 0; i < 100; i++)
            {

                render.Render();
                Console.WriteLine(i);
                
            }
            render.Stop();
            sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds/1000f);

            Console.Read();
        }
    }
}
