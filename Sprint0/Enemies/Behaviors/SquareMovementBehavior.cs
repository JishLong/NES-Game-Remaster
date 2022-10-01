using Sprint0.Enemies.Interfaces;
using Microsoft.Xna.Framework;
using static Sprint0.Enemies.Utils.EnemyUtils;
using System.Collections.Generic;

namespace Sprint0.Enemies.Behaviors
{
    public class SquareMovementBehavior: IMovementBehavior
    {
        private double ElapsedTime;
        private double UpdateTimer;
        private Direction Direction;
        private Vector2 DirectionVector;
        private float MovementSpeed;
        private int CurrentDirectionIndex;
        private List<Direction> DirectionSequence = new List<Direction> { Direction.Up, Direction.Right, Direction.Down, Direction.Left };

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="directionChangeFreq">A direction change will after this many milliseconds.</param>
        public SquareMovementBehavior(float movementSpeed, Direction direction, float directionChangeFreq = 1000)
        {
            Direction = direction;
            DirectionVector = ToVector(Direction);
            CurrentDirectionIndex = DirectionSequence.IndexOf(Direction);
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
                CurrentDirectionIndex = (CurrentDirectionIndex + 1) % DirectionSequence.Count;
                Direction = DirectionSequence[CurrentDirectionIndex];
                DirectionVector = ToVector(Direction);
            }
            return DirectionVector * MovementSpeed; 
        }
    }
}
