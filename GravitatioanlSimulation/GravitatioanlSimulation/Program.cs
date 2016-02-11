namespace GravitatioanlSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            DataOpenTK_3DVisualiser dataOpenTk_3DVisualiser = new DataOpenTK_3DVisualiser(new ModelGenerator1());
            dataOpenTk_3DVisualiser.Run(60);

        }

    }
}
