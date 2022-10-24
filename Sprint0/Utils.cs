﻿using Microsoft.Xna.Framework;

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
         * [centeredHitbox]: analogous to rectangle B
         * [direction]: the edge of A on which we want to center rectangle B
         */        
        public static Vector2 CenterOnEdge(Rectangle hitbox, Rectangle centeredHitbox, Types.Direction direction) 
        {
            switch (direction) 
            {
                case Types.Direction.LEFT:
                    return new Vector2(hitbox.Left - centeredHitbox.Width / 2, hitbox.Y + hitbox.Height / 2 - centeredHitbox.Height / 2);
                case Types.Direction.RIGHT:
                    return new Vector2(hitbox.Right - centeredHitbox.Width / 2, hitbox.Y + hitbox.Height / 2 - centeredHitbox.Height / 2);
                case Types.Direction.UP:
                    return new Vector2(hitbox.X + hitbox.Width / 2 - centeredHitbox.Width / 2, hitbox.Top - centeredHitbox.Height / 2);
                case Types.Direction.DOWN:
                    return new Vector2(hitbox.X + hitbox.Width / 2 - centeredHitbox.Width / 2, hitbox.Bottom - centeredHitbox.Height / 2);
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
