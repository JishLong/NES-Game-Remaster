using System;

namespace Sprint0.Characters.Utils
{
    public static class CharacterUtils
    {
        private readonly static Random RNG = new();

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

        public static Types.Direction GetNextClockwiseDirection(Types.Direction direction)
        {
            return direction switch
            {
                Types.Direction.LEFT => Types.Direction.UP,
                Types.Direction.RIGHT => Types.Direction.DOWN,
                Types.Direction.UP => Types.Direction.RIGHT,
                Types.Direction.DOWN => Types.Direction.LEFT,
                Types.Direction.UPLEFT => Types.Direction.UPRIGHT,
                Types.Direction.UPRIGHT => Types.Direction.DOWNRIGHT,
                Types.Direction.DOWNLEFT => Types.Direction.UPLEFT,
                Types.Direction.DOWNRIGHT => Types.Direction.DOWNLEFT,
                _ => Types.Direction.NO_DIRECTION,
            };
        }
    }
}
