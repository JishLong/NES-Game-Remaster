using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.RedGoriyaStates;

namespace Sprint0.Characters.Enemies
{
    public class RedGoriya : AbstractCharacter
    {
        private double AttackTimer = 0;
        private double AttackDelay = 4000;  // Attack every this many milliseconds.
        private double DirectionTimer = 0;
        private double DirectionDelay = 1500;    // Change direction every this many milliseconds.
        public RedGoriya(Vector2 position)
        {
            // State
            State = new RedGoriyaMovingRightState(this);

            // Combat
            Health = 1;

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
            State.Update(gameTime);
        }

        public void Freeze()
        {
           State.Freeze();
        }
    }
}
