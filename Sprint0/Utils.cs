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
                case Types.Direction.UPLEFT:
                    return new Vector2(-1, -1);
                case Types.Direction.UPRIGHT:
                    return new Vector2(1, -1);
                case Types.Direction.DOWNLEFT:
                    return new Vector2(-1, 1);
                case Types.Direction.DOWNRIGHT:
                    return new Vector2(1, 1);
                default:
                    return new Vector2(0, 0);
            }
        }

        public static float DirectionToRadians(Types.Direction direction) 
        {
            switch (direction)
            {
                case Types.Direction.LEFT:
                    return MathHelper.ToRadians(270);
                case Types.Direction.RIGHT:
                    return MathHelper.ToRadians(90);
                case Types.Direction.UP:
                    return 0;
                case Types.Direction.DOWN:
                    return MathHelper.ToRadians(180);
                case Types.Direction.UPLEFT:
                    return MathHelper.ToRadians(315);
                case Types.Direction.UPRIGHT:
                    return MathHelper.ToRadians(45);
                case Types.Direction.DOWNLEFT:
                    return MathHelper.ToRadians(225);
                case Types.Direction.DOWNRIGHT:
                    return MathHelper.ToRadians(135);
                default:
                    return -1;
            }
        }
    }
}
