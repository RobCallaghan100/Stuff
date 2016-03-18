using System;
using ClassLibrary1;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var warrior1 = new Samurai(new Shuriken());
            var warrior2 = new Samurai(new Sword());

            warrior1.Attack("the evil doers!");
            warrior2.Attack("the evil doers!");

            Console.ReadLine();
        }
    }
}
