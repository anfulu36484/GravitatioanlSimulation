using System;
using System.Diagnostics;

namespace GravitatioanlSimulation
{
    class Program
    {
        static void Main(string[] args)
        {

            RenderOpenTK renderOpenTk = new RenderOpenTK(new ModelGenerator8().Generate());

            renderOpenTk.Run();
            Stopwatch sw = new Stopwatch();
            
            sw.Start();

            for (int i = 0; i < 500; i++)
            {

                renderOpenTk.Render(i);
                Console.WriteLine(i);
                
            }
            renderOpenTk.Stop();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds/1000f);

            Console.Read();
        }
    }
}
