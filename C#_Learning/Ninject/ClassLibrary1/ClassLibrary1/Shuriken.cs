using System;

namespace ClassLibrary1
{
    public class Shuriken : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine("Pierced {0}'s armour", target);
        }
    }
}
