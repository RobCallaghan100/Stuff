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
                command.Input(line);

            } while (line.ToUpper() != "X");

            Console.ReadLine();
        }
    }
}
