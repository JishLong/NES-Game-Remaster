using Microsoft.Xna.Framework;

namespace Sprint0
{
    public static class Utils
    {
        // How big everything on the screen is - essentially used to "scale up" or "scale down" images
        public static readonly float GameScale = 3;

        /* Suppose we have two rectangles A and B. Also, suppose we have a point C that is the centerpoint of an edge on A.
         * Let's say we want to center rectangle B on point C, such that B's origin lies on C. This method allows us to do that, by returning
         * the point (as a Vector2) at which we would have to draw rectangle B for this to occur.
         * 
         * [hitbox]: analogous to rectangle A
         * [centeredHitboxWidth]: analogous to rectangle B's width
         * [centeredHitboxHeight]: analogous to rectangle B's height
         * [hitboxEdge]: the edge of A on which we want to center rectangle B
         */
        public static Vector2 CenterOnEdge(Rectangle hitbox, int centeredHitboxWidth, int centeredHitboxHeight, Types.Direction hitboxEdge) 
        {
            switch (hitboxEdge) 
            {
                case Types.Direction.LEFT:
                    return new Vector2(hitbox.Left - centeredHitboxWidth / 2, hitbox.Y + hitbox.Height / 2 - centeredHitboxHeight / 2);
                case Types.Direction.RIGHT:
                    return new Vector2(hitbox.Right - centeredHitboxWidth / 2, hitbox.Y + hitbox.Height / 2 - centeredHitboxHeight / 2);
                case Types.Direction.UP:
                    return new Vector2(hitbox.X + hitbox.Width / 2 - centeredHitboxWidth / 2, hitbox.Top - centeredHitboxHeight / 2);
                case Types.Direction.DOWN:
                    return new Vector2(hitbox.X + hitbox.Width / 2 - centeredHitboxWidth / 2, hitbox.Bottom - centeredHitboxHeight / 2);
                default:
                    return new Vector2(0, 0);
            }
        }

        /* Suppose we have two rectangles A and B. Let's say we want to move rectangle B such that A's origin = B's origin. This method
         * allows us to to do that by returning the point (as a Vector2) at which we would have to draw rectangle B for this to occur.
         * 
         * [hitbox]: analogous to rectangle A
         * [centeredHitbox]: analogous to rectangle B
         */
        public static Vector2 CenterRectangles(Rectangle hitbox, Rectangle centeredHitbox) 
        {
            return new Vector2(hitbox.X + hitbox.Width / 2 - centeredHitbox.Width / 2, hitbox.Y + hitbox.Height / 2 - centeredHitbox.Height / 2);
        }

        /* Suppose we have two rectangles A and B. Also, suppose we have a point C that is the centerpoint of an edge on A.
         * Let's say we want to position rectangle B such that the centerpoint of its opposite edge lies on C. This method allows us to do that, 
         * by returning the point (as a Vector2) at which we would have to draw rectangle B for this to occur.
         * 
         * [hitbox]: analogous to rectangle A
         * [centeredHitbox]: analogous to rectangle B
         * [hitboxEdge]: the edge of A on which we want to line up rectangle B
         */
        public static Vector2 LineUpEdges(Rectangle hitbox, Rectangle linedUpHitbox, Types.Direction hitboxEdge) 
        {
            switch (hitboxEdge)
            {
                case Types.Direction.LEFT:
                    return new Vector2(hitbox.Left - linedUpHitbox.Width, hitbox.Y + hitbox.Height / 2 - linedUpHitbox.Height / 2);
                case Types.Direction.RIGHT:
                    return new Vector2(hitbox.Right, hitbox.Y + hitbox.Height / 2 - linedUpHitbox.Height / 2);
                case Types.Direction.UP:
                    return new Vector2(hitbox.X + hitbox.Width / 2 - linedUpHitbox.Width / 2, hitbox.Top - linedUpHitbox.Height);
                case Types.Direction.DOWN:
                    return new Vector2(hitbox.X + hitbox.Width / 2 - linedUpHitbox.Width / 2, hitbox.Bottom);
                default:
                    return new Vector2(0, 0);
            }
        }

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
