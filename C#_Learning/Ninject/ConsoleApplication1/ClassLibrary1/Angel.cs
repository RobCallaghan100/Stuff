using System;

namespace ClassLibrary1
{
    public class Angel : IWeapon
    {
        public string Hit(string target)
        {
            return $"Brought {target} peace";
        }
    }
}
