using System;
using GraphicalEditor;

namespace ConsoleApplication1
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var command = new Command();
            string line;

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

            } while (line != null && line.ToUpper() != "X");
        }
    }
}
