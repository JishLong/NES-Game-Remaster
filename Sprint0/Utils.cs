using Microsoft.Xna.Framework;

namespace Sprint0
{
    public static class Utils
    {
        // How big everything on the screen is - essentially used to "scale up" or "scale down" images
        public static readonly float GameScale = 3;

        public static Vector2 DirectionToVector(Types.Direction direction) 
        {
            switch (direction) 
            {
                case Types.Direction.LEFT:
                    return new Vector2(-1, 0);
                case Types.Direction.RIGHT:
                    return new Vector2(1, 0);
                case Types.Direction.UP:
                    return new Vector2(0, -1);
                case Types.Direction.DOWN:
                    return new Vector2(0, 1);
                default:
                    return new Vector2(0, 0);
            }
        }
    }
}
