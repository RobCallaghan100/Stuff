namespace ClassLibrary1
{
    public class Dagger : IWeapon
    {
        public string Hit(string target)
        {
            return "Stab " + target + " ...";
        }
    }
}
