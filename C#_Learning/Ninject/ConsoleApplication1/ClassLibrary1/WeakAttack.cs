namespace ClassLibrary1
{
    using System;
    using Ninject;

    public class WeakAttack
    {
        private readonly IWeapon _weapon;

        public WeakAttack([Named("Weak")]IWeapon weapon)
        {
            _weapon = weapon;
        }

        public void Attack(string victim)
        {
            Console.WriteLine(_weapon.Hit(victim));
        }
    }
}
