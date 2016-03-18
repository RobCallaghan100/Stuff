using System;

namespace ClassLibrary1
{
    public class Shuriken : IWeapon
    {
        public string Hit(string target)
        {
            return $"Pierced {target}'s armour";
        }
    }
}
