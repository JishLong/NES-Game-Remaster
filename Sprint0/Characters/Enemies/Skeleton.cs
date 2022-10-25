using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States.SkeletonStates;

namespace Sprint0.Characters.Enemies
{
    public class Skeleton : AbstractCharacter
    {
        private double DirectionTimer = 0;
        private readonly double DirectionDelay = 1500;    // Change direction every this many milliseconds.
        public float MovementSpeed { get; set; }
        public Skeleton(Vector2 position)
        {
            // State
            State = new SkeletonMovingUpState(this);
            // Combat
            Health = 1;

            // Movement
            Position = position;
            MovementSpeed = 1.5f;
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
    }
}
