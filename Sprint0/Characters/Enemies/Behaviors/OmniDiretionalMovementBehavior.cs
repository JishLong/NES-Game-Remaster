using System;
using Sprint0.Enemies.Interfaces;
using Microsoft.Xna.Framework;
using static Sprint0.Enemies.Utils.EnemyUtils;

namespace Sprint0.Enemies.Behaviors
{
    public class OmniDirectionalMovementBehavior : IMovementBehavior
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
        public OmniDirectionalMovementBehavior(float movementSpeed, Direction direction, float directionChangeFreq = 1000)
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
        /// Moves in a random direction.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <returns>A change in position.</returns>
        public Vector2 Move(GameTime gameTime)
        {
            ElapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if ((ElapsedTime - UpdateTimer) > 0)
            {
                ElapsedTime = 0;
                Direction = RandOmniDirection(Direction);
                DirectionVector = ToVector(Direction);
            }

            return DirectionVector * MovementSpeed;
        }
    }
}
