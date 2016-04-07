namespace BeeGame.Models
{
    public class WorkerBee : Bee
    {
        public WorkerBee(int lifeSpan) : base(lifeSpan)
        {
            HitPoints = 10;
        }
    }
}