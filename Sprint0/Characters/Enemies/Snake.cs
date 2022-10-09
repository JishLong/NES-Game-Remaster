using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Enemies.States.SnakeStates;

namespace Sprint0.Characters.Enemies
{
    public class Snake : AbstractEnemy
    {
        private double DirectionTimer = 0;
        private double DirectionDelay = 2500;    // Change direction every this many milliseconds.
        public Snake(Vector2 position)
        {
            // State
            State = new SnakeFacingLeftMovingUpState(this);

            // Combat
            Health = 1;

            // Movement
            Position = position;
        }

        public override void Update(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            DirectionTimer += elapsedTime; 
            if ((DirectionTimer - DirectionDelay) > 0)
            {
                DirectionTimer = 0;
                State.ChangeDirection();
            }

            State.Update(gameTime);
        }

        public override void Draw(SpriteBatch sb)
        {
            State.Draw(sb, Position);
        }
    }
}
