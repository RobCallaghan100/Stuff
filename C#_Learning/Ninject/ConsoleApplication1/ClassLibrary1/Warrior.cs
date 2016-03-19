namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;

    public class Warrior
    {
        private readonly IEnumerable<IWeapon> _weapons;

        public Warrior(IEnumerable<IWeapon> weapons)
        {
            _weapons = weapons;
        }

        public void Attack(string victim)
        {
            foreach (var weapon in _weapons)
            {
                Console.WriteLine(weapon.Hit(victim));
            }
        }
    }
}
