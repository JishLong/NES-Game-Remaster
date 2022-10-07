using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Sprint0.Characters.Enemies.Utils
{
    public static class EnemyUtils
    {
        public enum Direction
        {
            Up,
            Down,
            Right,
            Left,
            UpRight,
            UpLeft,
            DownLeft,
            DownRight
        }

        private static Dictionary<Direction, Vector2> DirectionVectors = new Dictionary<Direction, Vector2>()
        {
            {Direction.Up, new Vector2(0,-1)},
            {Direction.UpRight, new Vector2(1,-1)},
            {Direction.Right, new Vector2(1,0)},
            {Direction.DownRight, new Vector2(1,1)},
            {Direction.Down, new Vector2(0,1) },
            {Direction.DownLeft, new Vector2(-1,1) },
            {Direction.Left, new Vector2(-1,0) },
            {Direction.UpLeft, new Vector2(-1,-1) },
        };

        public static Random RNG = new Random();

        // Only being used by hand, will probably create a new movement behavior and axe this.
        public static Vector2 RotateByAngle(Vector2 vector, float angle)
        {
            angle = MathHelper.ToRadians(angle);
            Matrix rotationMatrix = Matrix.CreateRotationZ(angle);
            return Vector2.Transform(vector, rotationMatrix);
        }

        public static Vector2 ToVector(Direction direction)
        {
            return DirectionVectors[direction];
        }
        /// <summary>
        /// Picks a random orthogonal direction other than the one passed as a parameter.
        /// </summary>
        /// <param name="direction">Enumerated direction.</param>
        /// <returns>A random direction.</returns>
        public static Direction RandOrthogDirection(Direction direction)
        {
            Direction newDirection = direction;
            while (newDirection == direction)
            {
                newDirection = (Direction)RNG.Next(0, 4);
            }
            return newDirection;
        }

        /// <summary>
        /// Picks a random direction other than the one passed as a parameter
        /// </summary>
        /// <param name="direction">Enumerated direction.</param>
        /// <returns>A random direction.</returns>
        public static Direction RandOmniDirection(Direction direction)
        {
            Direction newDirection = direction;
            while (newDirection == direction)
            {
                newDirection = (Direction)RNG.Next(0, 8);
            }
            return newDirection;
        }
    }
}
