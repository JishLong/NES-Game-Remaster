using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.RedGoriyaStates;

namespace Sprint0.Characters.Enemies
{
    public class RedGoriya : AbstractCharacter
    {
        private double AttackTimer = 0;
        private readonly double AttackDelay = 4000;  // Attack every this many milliseconds.
        private double DirectionTimer = 0;
        private readonly double DirectionDelay = 1500;    // Change direction every this many milliseconds.
        public RedGoriya(Vector2 position)
        {
            // State
            State = new RedGoriyaMovingState(this);

            // Combat
            Health = 3;
            Damage = 2;

            // Movement
            Position = position;
        }

        public override void Update(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            AttackTimer += elapsedTime;
            DirectionTimer += elapsedTime; 

            if((AttackTimer - AttackDelay) > 0)
            {
                AttackTimer = 0;
                State.Attack();
            }

            if ((DirectionTimer - DirectionDelay) > 0)
            {
                DirectionTimer = 0;
                State.ChangeDirection();
            }
            base.Update(gameTime);
        }   
    }
}
