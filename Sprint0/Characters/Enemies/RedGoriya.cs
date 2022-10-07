using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Enemies.RedGoriyaStates;

namespace Sprint0.Characters.Enemies
{
    public class RedGoriya : AbstractEnemy
    {
        private double AttackTimer = 0;
        private double AttackDelay = 5000;  // Attack every 5 seconds.
        private double MoveTimer = 0;
        private double MoveDelay = 2000;    // Move every 3 seconds.
        public RedGoriya(Vector2 position)
        {
            Position = position;
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
            MoveTimer += elapsedTime; 

            if((AttackTimer - AttackDelay) > 0)
            {
                AttackTimer = 0;
                State.Attack();
            }

            if ((MoveTimer - MoveDelay) > 0)
            {
                MoveTimer = 0;
                State.ChangeDirection();
            }
            State.Update(gameTime);
        }

        public void Freeze()
        {
           State.Freeze();
        }
        public override void Draw(SpriteBatch sb)
        {
            State.Draw(sb, Position);
        }
    }
}
