using System;

namespace ClassLibrary1
{
    public class Sword : IWeapon
    {
        public string Hit(string target)
        {
            return $"Chopped {target} in half";
        }
    }
}
