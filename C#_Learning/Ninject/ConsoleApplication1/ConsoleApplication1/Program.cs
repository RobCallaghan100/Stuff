using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    using ClassLibrary1;
    using Ninject;
    using Ninject.Modules;

    class Program
    {
        static void Main(string[] args)
        {
//            IKernel kernel = new StandardKernel(new WarrriorModule(), new PeaceModule());
            var useMeleeWeapons = true;
            IKernel kernel = new StandardKernel(new WeaponsModule(useMeleeWeapons));
            Samurai warrior = kernel.Get<Samurai>();
            warrior.Attack("The evildoers");

            var w2 = kernel.Get<Samurai>();
            w2.Attack("dsdsds");

            Console.ReadLine();
        }
    }

    internal class WeaponsModule2 : NinjectModule
    {
        public override void Load()
        {
            Bind<IWeapon>().To<Shuriken>().Named("Strong");
            Bind<IWeapon>().To<Dagger>().Named("Weak");
        }
    }

    internal class WeaponsModule : NinjectModule
    {
        private readonly bool _useMeleeWeapons;

        public WeaponsModule(bool useMeleeWeapons)
        {
            _useMeleeWeapons = useMeleeWeapons;
        }

        public override void Load()
        {
            if (_useMeleeWeapons)
            {
                Bind<IWeapon>().To<Sword>();
            }
            else
            {
                Bind<IWeapon>().To<Shuriken>();
            }
        }
    }

    internal class PeaceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWeapon>().To<Angel>();
            Bind<IWeapon>().ToMethod(c => new Sword()
            {
                x =10
            });
        }
    }

    internal class WarrriorModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWeapon>().To<Sword>();
            Bind<Samurai>().ToSelf().InSingletonScope();
        }
    }
}
