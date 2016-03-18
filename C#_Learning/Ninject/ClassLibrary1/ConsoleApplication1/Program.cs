using System;
using ClassLibrary1;

namespace ConsoleApplication1
{
    using System.Collections;
    using System.Collections.Generic;
    using Ninject;

    class Program
    {
        static void Main(string[] args)
        {
//            Example1();
//            Example2();

            IKernel kernel = new StandardKernel(new TestModule());

            IEnumerable<IWeapon> weapons = kernel.GetAll<IWeapon>();

            foreach (var weapon in weapons)
            {
                Console.WriteLine(weapon.Hit("the evil doeers"));
            }

            Console.ReadLine();
        }

        private static void Example2()
        {
            IKernel kernel = new StandardKernel(new TestModule());

            var samurai = kernel.Get<Samurai>();
            samurai.Attack("your enemy");
        }

        private static void Example1()
        {
            var warrior1 = new Samurai(new IWeapon[] {new Shuriken()});
            var warrior2 = new Samurai(new IWeapon[] { new Sword()});
            warrior1.Attack("the evil doers!");
            warrior2.Attack("the evil doers!");
        }
    }
}
