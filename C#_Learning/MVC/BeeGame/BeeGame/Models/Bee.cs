namespace BeeGame.Models
{
    public abstract class Bee
    {
        protected int HitPoints;
            
        protected Bee(int lifeSpan)
        {
            LifeSpan = lifeSpan;
        }

        public int LifeSpan {  get; protected internal set; }

        public virtual void Hit()
        {
            LifeSpan -= HitPoints;
        }

        public bool IsAlive()
        {
            return LifeSpan > 0;
        }
    }
}