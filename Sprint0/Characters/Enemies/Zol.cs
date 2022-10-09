using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States.ZolStates;

namespace Sprint0.Characters.Enemies
{
    public class Zol : AbstractEnemy
    {
        private double DirectionTimer = 0;
        private double DirectionDelay = 1000;    // Change direction every this many milliseconds.
        public float MovementSpeed { get; set; }
        public Zol(Vector2 position)
        {
            // State
            State = new ZolMovingUpState(this);
            // Combat
            Health = 1;

            // Movement
            Position = position;
            MovementSpeed = 1;
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
