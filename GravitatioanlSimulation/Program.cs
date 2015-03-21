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
            Test5();
    
            Console.Read();
        }
      /*  
        private static void Test1()
        {*/
/*CelestialObject earth = new CelestialObject(5.972E24, new double[] { 2E7, 1E7 }, new double[] { 100, 200 });
            CelestialObject sun = new CelestialObject(1.98892E30, new double[] { 0.0001, 0.0001 }, new double[] { 0, 0 });
            //CelestialObject earth2 = new CelestialObject(5.972E24, new double[] { 15E7, 0.1 }, new double[] { 0.01, 0.01 });*/


          /*  CelestialObject earth = new CelestialObject(100, new double[] {5, 0}, new double[] {-0.01, 0.18});
            CelestialObject sun = new CelestialObject(500000000, new double[] {0.0001, 0.0001}, new double[] {0, 0});
            CelestialObject earth2 = new CelestialObject(200, new double[] {0.3, 0.4}, new double[] {0.05, 0.06});

            
            PoolOfSelectialObject pool = new PoolOfSelectialObject();
            pool.Add(earth);
            pool.Add(sun);
            pool.Add(earth2);

            Function function = new Function(pool.Objects, 2);

            ODEsSolver solver = new ODEsSolver();

            double[,] result = solver.SolveRungeKutta(function.Solve, pool._initialValues.ToArray(),
                new double[] {0, 1, 2, 30, 100, 200, 300, 500, 800, 1000, 3000, 5000, 10000, 11000, 15000, 16000});


            /*double[,] result = solver.SolveEuler(function.Solve, pool._initialValues.ToArray(), 20, 0.1);*/

            /*for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {

                    Console.Write(result[i,j]+" ");
                }
                Console.WriteLine();
            }*/
/*
            Console.WriteLine("Позиция земли");
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < earth2.IndexPosition.Length; j++)
                {
                    Console.Write(result[i, earth.IndexPosition[j] + 1] + " ");
                    Debug.Write(result[i, earth.IndexPosition[j] + 1] + ";");
                }
                Debug.WriteLine("");
                Console.WriteLine();
            }

            Console.WriteLine("Скорость земли");
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < earth.IndexPosition.Length; j++)
                {
                    Console.Write(result[i, earth.IndexVelocity[j] + 1] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Позиция солнца");
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < sun.IndexPosition.Length; j++)
                {
                    Console.Write(result[i, sun.IndexPosition[j] + 1] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Скорость солнца");
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < sun.IndexPosition.Length; j++)
                {
                    Console.Write(result[i, sun.IndexVelocity[j] + 1] + " ");
                }
                Console.WriteLine();
            }
        }*/

        static void Test2()
        {
            CelestialObject earth = new CelestialObject(100, new double[] { 5, 0 }, new double[] { -0.01, 0.18 },Color.Brown);
            CelestialObject sun = new CelestialObject(500000000, new double[] { 0.0001, 0.0001 }, new double[] { 0, 0 }, Color.OrangeRed);
            CelestialObject earth2 = new CelestialObject(200, new double[] { 6, 7 }, new double[] { -0.05, 0.20 }, Color.Green);
            CelestialObject earth3 = new CelestialObject(200, new double[] { 20, 30 }, new double[] { -0.5, 1.5 }, Color.Olive);
            CelestialObject sun2 = new CelestialObject(500000000, new double[] { 10, 30 }, new double[] { 0, 0 }, Color.OrangeRed);

            PoolOfSelectialObject pool = new PoolOfSelectialObject();
            pool.Add(earth);
            pool.Add(sun);
            pool.Add(earth2);
            pool.Add(earth3);
            pool.Add(sun2);

            Function function = new Function(pool.Objects, 2);

            SystemOfBodies systemOfBodies = new SystemOfBodies(pool.Objects,new EulerMethod(function.Solve,pool._initialValues.ToArray(),0.1));

            //DataOpenTKVisualizer dataOpenTkVisualizer = new DataOpenTKVisualizer(systemOfBodies);
            //dataOpenTkVisualizer.Run(30);
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
                    }, Color.Snow));
            }
            pool.Add(sun);
            //pool.Add(sun2);
            //pool.Add(sun3);

            Function function = new Function(pool.Objects, 2);

            SystemOfBodies systemOfBodies = new SystemOfBodies(pool.Objects, new EulerMethod(function.Solve, pool._initialValues.ToArray(), 0.1));

            DataOpenTKVisualizer dataOpenTkVisualizer = new DataOpenTKVisualizer();

            systemOfBodies.action = dataOpenTkVisualizer.GetData;
            //systemOfBodies.action = GetData;
            systemOfBodies.UpdatePositionOfObjects();
            dataOpenTkVisualizer.Run(50);
            
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

            DataOpenTKVisualizer dataOpenTkVisualizer = new DataOpenTKVisualizer();

            systemOfBodies.action = dataOpenTkVisualizer.GetData;
            //systemOfBodies.action = GetData;
            systemOfBodies.UpdatePositionOfObjects();
            dataOpenTkVisualizer.Run(50);

        }

        //2d
        static void Test5()
        {
            CelestialObject sun = new CelestialObject(5E10, new double[] { 0.0001, 0.0001 }, new double[] { 0, 0 }, Color.OrangeRed);
            CelestialObject sun2 = new CelestialObject(10000000, new double[] { 100, 100 }, new double[] { -1, 1 }, Color.OrangeRed);
            CelestialObject sun3 = new CelestialObject(10000000, new double[] { 10, 10 }, new double[] { -1, 1 }, Color.OrangeRed);

            PoolOfSelectialObject pool = new PoolOfSelectialObject();

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                pool.Add(new CelestialObject(random.Next(50000000, 600000000),
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
            //pool.Add(sun);
            //pool.Add(sun2);
            //pool.Add(sun3);

            Function function = new Function(pool.Objects, 2);

            SystemOfBodies systemOfBodies = new SystemOfBodies(pool.Objects, new EulerMethod(function.Solve, pool._initialValues.ToArray(), 0.1));

            DataOpenTKVisualizer dataOpenTkVisualizer = new DataOpenTKVisualizer();

            systemOfBodies.action = dataOpenTkVisualizer.GetData;
            //systemOfBodies.action = GetData;
            systemOfBodies.UpdatePositionOfObjects();
            dataOpenTkVisualizer.Run(50);

        }
    }
}
