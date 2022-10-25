using System;
using Microsoft.Xna.Framework;

namespace Sprint0.Characters.Utils
{
    public static class CharacterUtils
    {
        private readonly static Random RNG = new Random();

        // Only being used by hand, will probably create a new movement behavior and axe this.
        public static Vector2 RotateByAngle(Vector2 vector, float angle)
        {
            angle = MathHelper.ToRadians(angle);
            Matrix rotationMatrix = Matrix.CreateRotationZ(angle);
            return Vector2.Transform(vector, rotationMatrix);
        }

        /// <summary>
        /// Picks a random orthogonal direction other than the one passed as a parameter.
        /// </summary>
        /// <param name="direction">Enumerated direction.</param>
        /// <returns>A random direction.</returns>
        public static Types.Direction RandOrthogDirection(Types.Direction direction)
        {
            Types.Direction newDirection = direction;
            while (newDirection == direction)
            {
                newDirection = (Types.Direction)RNG.Next(0, 4);
            }
            return newDirection;
        }

        /// <summary>
        /// Picks a random direction other than the one passed as a parameter
        /// </summary>
        /// <param name="direction">Enumerated direction.</param>
        /// <returns>A random direction.</returns>
        public static Types.Direction RandOmniDirection(Types.Direction direction)
        {
            Types.Direction newDirection = direction;
            while (newDirection == direction)
            {
                newDirection = (Types.Direction)RNG.Next(0, 8);
            }
            return newDirection;
        }
    }
}
