using System;

namespace ClassLibrary1
{
    public class Sword : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine("Chopped {0} in half", target);
        }
    }
}
