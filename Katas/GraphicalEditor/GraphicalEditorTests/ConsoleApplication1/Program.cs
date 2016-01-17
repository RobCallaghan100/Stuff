using System;
using GraphicalEditor;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = new Command();
            string line = "";

            do
            {
                line = Console.ReadLine();

                try
                {
                    command.Input(line);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (line.ToUpper() != "X");
        }
    }
}
