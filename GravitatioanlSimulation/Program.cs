using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNumerics.ODE;
using DotNumerics.ODE.Radau5;
using GravitatioanlSimulation.Solver;

namespace GravitatioanlSimulation
{
    class Program
    {

        static void Main(string[] args)
        {
            Test10();
    
            Console.Read();
        }
      
  


        static int RandomSumbol(Random random)
        {
            return random.Next(1, 3) == 1 ? -1 : 1;
        }

        //2d
        static void Test3()
        {
            CelestialObject sun = new CelestialObject( 5E10, new double[] { 0.0001, 0.0001 }, new double[] { 0, 0 }, Color.OrangeRed);
            CelestialObject sun2 = new CelestialObject(10000000, new double[] { 100, 100}, new double[] { -1, 1 }, Color.OrangeRed);
            CelestialObject sun3 = new CelestialObject(10000000, new double[] { 10, 10}, new double[] { -1, 1 }, Color.OrangeRed);

            PoolOfSelectialObject pool = new PoolOfSelectialObject();

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                pool.Add(new CelestialObject(random.Next(1, 300),
                    new double[]
                    { 
                    RandomSumbol(random) * random.Next(1, 300),
                    RandomSumbol(random) * random.Next(1, 300) 
                    },
                    new double[]
                    {
                        0,//RandomSumbol(random) * random.NextDouble(), 
                        0//RandomSumbol(random) * random.NextDouble()
                    }, GetRandomColor(random)));
            }
            pool.Add(sun);
            //pool.Add(sun2);
            //pool.Add(sun3);

            Function function = new Function(pool.Objects, 2);

            SystemOfBodies systemOfBodies = new SystemOfBodies(pool.Objects, new EulerMethod(function.Solve, pool._initialValues.ToArray(), 0.1));

            DataOpenTK_2DVisualizer dataOpenTk_2DVisualizer = new DataOpenTK_2DVisualizer();

            systemOfBodies.action = dataOpenTk_2DVisualizer.GetData;
            //systemOfBodies.action = GetData;
            systemOfBodies.UpdatePositionOfObjects();
            dataOpenTk_2DVisualizer.Run(50);
            
        }

        static void GetData(CelestialObject[] celestialObjects)
        {
            Console.WriteLine("\n\nNew");
            for (int i = 0; i < celestialObjects.Length; i++)
            {
                Console.WriteLine(celestialObjects[i].Position[0]+" "+celestialObjects[i].Position[1]);
                
            }

        }

        //3d
        static void Test4()
        {
            CelestialObject sun = new CelestialObject(5E10, new double[] { 0.0001, 0.0001,0.0001 }, new double[] { 0, 0,0 }, Color.OrangeRed);


            PoolOfSelectialObject pool = new PoolOfSelectialObject();

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                pool.Add(new CelestialObject(random.Next(1, 300),
                    new double[]
                    { 
                    RandomSumbol(random) * random.Next(1, 300),
                    RandomSumbol(random) * random.Next(1, 300) ,
                    RandomSumbol(random) * random.Next(1, 300) 
                    },
                    new double[]
                    {
                        RandomSumbol(random) * random.NextDouble(), 
                        RandomSumbol(random) * random.NextDouble(),
                        RandomSumbol(random) * random.NextDouble()
                    }, Color.Snow));
            }
            pool.Add(sun);
            //pool.Add(sun2);
            //pool.Add(sun3);

            Function function = new Function(pool.Objects, 3);

            SystemOfBodies systemOfBodies = new SystemOfBodies(pool.Objects, new EulerMethod(function.Solve, pool._initialValues.ToArray(), 0.1));

            DataOpenTK_2DVisualizer dataOpenTk_2DVisualizer = new DataOpenTK_2DVisualizer();

            systemOfBodies.action = dataOpenTk_2DVisualizer.GetData;
            //systemOfBodies.action = GetData;
            systemOfBodies.UpdatePositionOfObjects();
            dataOpenTk_2DVisualizer.Run(50);

        }

        static Color GetRandomColor(Random random)
        {
            return Color.FromArgb(random.Next(100, 200), random.Next(100, 200), random.Next(100, 200));
        }



        //2d
        static void Test5()
        {

            PoolOfSelectialObject pool = new PoolOfSelectialObject();

            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                pool.Add(new CelestialObject(random.Next(500000000, 600000000),
                    new double[]
                    { 
                    RandomSumbol(random) * random.Next(1, 300),
                    RandomSumbol(random) * random.Next(1, 300) 
                    },
                    new double[]
                    {
                        0,//RandomSumbol(random) * random.NextDouble(), 
                        0//RandomSumbol(random) * random.NextDouble()
                    },GetRandomColor(random)));
            }


            Function function = new Function(pool.Objects, 2);

            SystemOfBodies systemOfBodies = new SystemOfBodies(pool.Objects, new EulerMethod(function.Solve, pool._initialValues.ToArray(), 0.1));

            DataOpenTK_2DVisualizer dataOpenTk_2DVisualizer = new DataOpenTK_2DVisualizer();

            systemOfBodies.action = dataOpenTk_2DVisualizer.GetData;
            //systemOfBodies.action = GetData;
            systemOfBodies.UpdatePositionOfObjects();
            dataOpenTk_2DVisualizer.Run(50);

        }

        //2d Одиноковые массы
        static void Test5_1()
        {

            PoolOfSelectialObject pool = new PoolOfSelectialObject();

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                pool.Add(new CelestialObject(500000000,
                    new double[]
                    { 
                    RandomSumbol(random) * random.Next(1, 300),
                    RandomSumbol(random) * random.Next(1, 300) 
                    },
                    new double[]
                    {
                        0,//RandomSumbol(random) * random.NextDouble(), 
                        0//RandomSumbol(random) * random.NextDouble()
                    }, Color.Snow));
            }


            Function function = new Function(pool.Objects, 2);

            SystemOfBodies systemOfBodies = new SystemOfBodies(pool.Objects, new EulerMethod(function.Solve, pool._initialValues.ToArray(), 0.1));

            DataOpenTK_2DVisualizer dataOpenTk_2DVisualizer = new DataOpenTK_2DVisualizer();

            systemOfBodies.action = dataOpenTk_2DVisualizer.GetData;
            //systemOfBodies.action = GetData;
            systemOfBodies.UpdatePositionOfObjects();
            dataOpenTk_2DVisualizer.Run(50);

        }


        //3d
        static void Test5_2()
        {

            PoolOfSelectialObject pool = new PoolOfSelectialObject();

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                pool.Add(new CelestialObject(random.Next(500000000, 600000000),
                    new double[]
                    { 
                    RandomSumbol(random) * random.Next(1, 300),
                    RandomSumbol(random) * random.Next(1, 300),
                    RandomSumbol(random) * random.Next(1, 300) 
                    },
                    new double[]
                    {
                        0,//RandomSumbol(random) * random.NextDouble(), 
                        0,//RandomSumbol(random) * random.NextDouble()
                        0
                    }, GetRandomColor(random)));
            }


            Function function = new Function(pool.Objects, 3);

            SystemOfBodies systemOfBodies = new SystemOfBodies(pool.Objects, new EulerMethod(function.Solve, pool._initialValues.ToArray(), 0.1));

            DataOpenTK_3DVisualiser dataOpenTk_3DVisualizer = new DataOpenTK_3DVisualiser();

            systemOfBodies.action = dataOpenTk_3DVisualizer.GetData;

            systemOfBodies.UpdatePositionOfObjects();
            dataOpenTk_3DVisualizer.Run(50);

        }



        //Солнечная система
        static void Test6()
        {

            double massOfSun = 1.98892E30;

            CelestialObject sun = new CelestialObject(massOfSun/massOfSun, new double[] { 0, 0 }, new double[] { 0, 0 }, Color.OrangeRed);
            CelestialObject earth = new CelestialObject(
                5.972E24/massOfSun,
                new double[] { 149500000/massOfSun, 0 },
                new double[] { -Math.Pow(30000 / (2*massOfSun), 0.5), Math.Pow(30000 / (2*massOfSun), 0.5) },
                Color.DarkCyan);

            PoolOfSelectialObject pool = new PoolOfSelectialObject();

    
            pool.Add(sun);
            pool.Add(earth);
            //pool.Add(sun3);

            Function function = new Function(pool.Objects, 2);

            SystemOfBodies systemOfBodies = new SystemOfBodies(pool.Objects, new EulerMethod(function.Solve, pool._initialValues.ToArray(), 0.1));

            DataOpenTK_2DVisualizer dataOpenTk_2DVisualizer = new DataOpenTK_2DVisualizer();

            systemOfBodies.action = dataOpenTk_2DVisualizer.GetData;
            //systemOfBodies.action = GetData;
            systemOfBodies.UpdatePositionOfObjects();
            dataOpenTk_2DVisualizer.Run(50);

        }


        //3d
        static void Test7()
        {
            CelestialObject sun = new CelestialObject(5E12, new double[] { 0, 0, 0}, new double[] { 0, 0, 0 }, Color.OrangeRed);
            PoolOfSelectialObject pool = new PoolOfSelectialObject();

            pool.Add(sun);

            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                pool.Add(new CelestialObject(random.Next(50, 100),
                    new double[]
                    { 
                    RandomSumbol(random) * random.Next(1, 300),
                    RandomSumbol(random) * random.Next(1, 300),
                    RandomSumbol(random) * random.Next(1, 300) 
                    },
                    new double[]
                    {
                        RandomSumbol(random) * random.NextDouble(), 
                        RandomSumbol(random) * random.NextDouble(),
                        RandomSumbol(random) * random.NextDouble()
                    }, GetRandomColor(random)));
            }


            Function function = new Function(pool.Objects, 3);

            SystemOfBodies systemOfBodies = new SystemOfBodies(pool.Objects, new EulerMethod(function.Solve, pool._initialValues.ToArray(), 0.1));

            DataOpenTK_3DVisualiser dataOpenTk_3DVisualizer = new DataOpenTK_3DVisualiser();

            systemOfBodies.action = dataOpenTk_3DVisualizer.GetData;
            //systemOfBodies.action = GetData;
            systemOfBodies.UpdatePositionOfObjects();
            dataOpenTk_3DVisualizer.Run(50);

        }

        //3d
        static void Test8()
        {
            CelestialObject sun = new CelestialObject(5E8, new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 }, Color.OrangeRed);
            PoolOfSelectialObject pool = new PoolOfSelectialObject();

            pool.Add(sun);

            Random random = new Random();




            for (int i = 0; i < 20; i++)
            {

                double velocity = random.NextDouble();

                pool.Add(new CelestialObject(random.Next(50, 100),
                    new double[]
                    { 
                    RandomSumbol(random) * random.Next(1, 300),
                    RandomSumbol(random) * random.Next(1, 300),
                    RandomSumbol(random) * random.Next(1, 300) 
                    },
                    new double[]
                    {
                        -1 *velocity, 
                        velocity,
                        RandomSumbol(random) * velocity
                    }, GetRandomColor(random)));
            }


            Function function = new Function(pool.Objects, 3);

            SystemOfBodies systemOfBodies = new SystemOfBodies(pool.Objects, new EulerMethod(function.Solve, pool._initialValues.ToArray(), 0.1));

            DataOpenTK_3DVisualiser dataOpenTk_3DVisualizer = new DataOpenTK_3DVisualiser();

            systemOfBodies.action = dataOpenTk_3DVisualizer.GetData;
            //systemOfBodies.action = GetData;
            systemOfBodies.UpdatePositionOfObjects();
            dataOpenTk_3DVisualizer.Run(50);

        }


        //3d + барьер
        static void Test9()
        {
            CelestialObject sun = new CelestialObject(5E12, new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 }, Color.OrangeRed);
            PoolOfSelectialObject pool = new PoolOfSelectialObject();

            pool.Add(sun);

            Random random = new Random();




            for (int i = 0; i < 20; i++)
            {

                pool.Add(new CelestialObject(random.Next(50, 100),
                    new double[]
                    { 
                    RandomSumbol(random) * random.Next(1, 300),
                    RandomSumbol(random) * random.Next(1, 300),
                    RandomSumbol(random) * random.Next(1, 300) 
                    },
                    new double[]
                    {
                        RandomSumbol(random) * random.NextDouble(), 
                        RandomSumbol(random) * random.NextDouble(),
                        RandomSumbol(random) * random.NextDouble()
                    }, GetRandomColor(random)));
            }


            Function function = new Function(pool.Objects, 3);

            SystemOfBodies systemOfBodies = new SystemOfBodies(pool.Objects, 
                new EulerMethodWithBorders(
                    function.Solve, pool._initialValues.ToArray(), 0.1, new double[] { 500, 500, 500 },
                    new double[] { -500, -500, -500 }, pool.Objects)
                );

            DataOpenTK_3DVisualiser dataOpenTk_3DVisualizer = new DataOpenTK_3DVisualiser();

            systemOfBodies.action = dataOpenTk_3DVisualizer.GetData;
            //systemOfBodies.action = GetData;
            systemOfBodies.UpdatePositionOfObjects();
            dataOpenTk_3DVisualizer.Run(50);

        }

        //3d + барьер увеличена масса частиц
        static void Test10()
        {

            CelestialObject sun = new CelestialObject(5E15, new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 }, Color.OrangeRed);
            PoolOfSelectialObject pool = new PoolOfSelectialObject();

            pool.Add(sun);

            Random random = new Random();




            for (int i = 0; i < 2; i++)
            {

                pool.Add(new CelestialObject(random.Next(1, 30)*1E11,
                    new double[]
                    { 
                    RandomSumbol(random) * random.Next(1, 300),
                    RandomSumbol(random) * random.Next(1, 300),
                    RandomSumbol(random) * random.Next(1, 300) 
                    },
                    new double[]
                    {
                        0,//RandomSumbol(random) * random.NextDouble(), 
                        0,//RandomSumbol(random) * random.NextDouble(),
                        0,//RandomSumbol(random) * random.NextDouble()
                    }, GetRandomColor(random)));
            }

            for (int i = 0; i < 10; i++)
            {

                pool.Add(new CelestialObject(random.Next(200, 1000) ,
                    new double[]
                    { 
                    RandomSumbol(random) * random.Next(1, 300),
                    RandomSumbol(random) * random.Next(1, 300),
                    RandomSumbol(random) * random.Next(1, 300) 
                    },
                    new double[]
                    {
                        0,//RandomSumbol(random) * random.NextDouble(), 
                        0,//RandomSumbol(random) * random.NextDouble(),
                        0//RandomSumbol(random) * random.NextDouble()
                    }, Color.White));
            }


            Function function = new Function(pool.Objects, 3);

            SystemOfBodies systemOfBodies = new SystemOfBodies(pool.Objects,
                new EulerMethodWithBorders(
                    function.Solve, pool._initialValues.ToArray(), 0.1, new double[] { 500, 500, 500 },
                    new double[] { -500, -500, -500 }, pool.Objects)
                );

            DataOpenTK_3DVisualiser dataOpenTk_3DVisualizer = new DataOpenTK_3DVisualiser();

            systemOfBodies.action = dataOpenTk_3DVisualizer.GetData;
            //systemOfBodies.action = GetData;
            systemOfBodies.UpdatePositionOfObjects();
            dataOpenTk_3DVisualizer.Run(50);

        }
    }
}
