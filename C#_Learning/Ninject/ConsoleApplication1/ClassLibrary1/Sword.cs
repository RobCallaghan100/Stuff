namespace ClassLibrary1
{
    using Ninject.Activation;

    public class Sword : IWeapon
    {
        public string Hit(string target)
        {
            return $"Chopped {target} in half";
        }

        public int x { get; set; }
    }
}
