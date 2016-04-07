namespace BeeGame.Models
{
    public class DroneBee : Bee
    {
        public DroneBee(int lifeSpan) : base(lifeSpan)
        {
            HitPoints = 12;
        }
    }
}