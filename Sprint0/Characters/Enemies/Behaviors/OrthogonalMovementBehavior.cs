using Sprint0.Enemies.Interfaces;
using Microsoft.Xna.Framework;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Enemies.Behaviors
{
    public class OrthogonalMovementBehavior : IMovementBehavior
    {
        private double ElapsedTime;
        private double UpdateTimer;
        private Direction Direction;
        private Vector2 DirectionVector;
        private float MovementSpeed;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="directionChangeFreq">A direction change will after this many milliseconds.</param>
        public OrthogonalMovementBehavior(float movementSpeed, Direction direction, float directionChangeFreq = 1000)
        {
            Direction = direction;
            DirectionVector = ToVector(Direction);
            UpdateTimer = directionChangeFreq;
            MovementSpeed = movementSpeed;
        }

        public Direction GetDirection()
        {
            return Direction;
        }

        /// <summary>
        /// Moves in a random orthogonal direction. Returns the new position.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <returns></returns>
        public Vector2 Move(GameTime gameTime)
        {
            ElapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if ((ElapsedTime - UpdateTimer) > 0)
            {
                ElapsedTime = 0;
                Direction = RandOrthogDirection(Direction);
                DirectionVector = ToVector(Direction);
            }
            return DirectionVector * MovementSpeed; 
        }
    }
}
