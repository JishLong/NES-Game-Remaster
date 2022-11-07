using Microsoft.Xna.Framework;

namespace Sprint0
{
    public static class Utils
    {
        // How big everything on the screen is - essentially used to "scale up" or "scale down" images
        public static float GameScale = 3;

        // Screen size
        public static int GameWidth = 256 * (int)GameScale;
        public static int GameHeight = 176 * (int)GameScale;

        // Sprite Layer Depths
        public static readonly float BlockLayerDepth = 1.0f;
        public static readonly float CharacterLayerDepth = 0.9f;
        public static readonly float ItemLayerDepth = 0.8f;
        public static readonly float PlayerLayerDepth = 0.5f;
        public static readonly float ProjectileLayerDepth = 0.4f;
        public static readonly float DoorWayLayerDepth = 1.0f; 
        public static readonly float DoorWallLayerDepth = 0.2f; // Needs to be drawn on top of the player.

        public static void UpdateWindowSize(GraphicsDeviceManager graphics) 
        {
            GameWidth = graphics.GraphicsDevice.Viewport.Width;
            GameHeight = graphics.GraphicsDevice.Viewport.Height;

            GameScale = (int)(GameWidth / 256);
            GameScale = (int)(GameHeight / 176);
        }

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
        public static Vector2 CenterRectangles(Rectangle hitbox, int centeredHitboxWidth, int centeredHitboxHeight) 
        {
            return new Vector2(hitbox.X + hitbox.Width / 2 - centeredHitboxWidth / 2, hitbox.Y + hitbox.Height / 2 - centeredHitboxHeight / 2);
        }

        /* Suppose we have two rectangles A and B. Also, suppose we have a point C that is the centerpoint of an edge on A.
         * Let's say we want to position rectangle B such that the centerpoint of its opposite edge lies on C. This method allows us to do that, 
         * by returning the point (as a Vector2) at which we would have to draw rectangle B for this to occur.
         * 
         * [hitbox]: analogous to rectangle A
         * [centeredHitbox]: analogous to rectangle B
         * [hitboxEdge]: the edge of A on which we want to line up rectangle B
         */
        public static Vector2 LineUpEdges(Rectangle hitbox, int linedUpHitboxWidth, int linedUpHitboxHeight, Types.Direction hitboxEdge) 
        {
            switch (hitboxEdge)
            {
                case Types.Direction.LEFT:
                    return new Vector2(hitbox.Left - linedUpHitboxWidth, hitbox.Y + hitbox.Height / 2 - linedUpHitboxHeight / 2);
                case Types.Direction.RIGHT:
                    return new Vector2(hitbox.Right, hitbox.Y + hitbox.Height / 2 - linedUpHitboxHeight / 2);
                case Types.Direction.UP:
                    return new Vector2(hitbox.X + hitbox.Width / 2 - linedUpHitboxWidth / 2, hitbox.Top - linedUpHitboxHeight);
                case Types.Direction.DOWN:
                    return new Vector2(hitbox.X + hitbox.Width / 2 - linedUpHitboxWidth / 2, hitbox.Bottom);
                case Types.Direction.UPLEFT:
                    return new Vector2(hitbox.X - linedUpHitboxWidth, hitbox.Y - linedUpHitboxHeight);
                case Types.Direction.UPRIGHT:
                    return new Vector2(hitbox.X + hitbox.Width, hitbox.Y - linedUpHitboxHeight);
                case Types.Direction.DOWNLEFT:
                    return new Vector2(hitbox.X - linedUpHitboxWidth, hitbox.Y + hitbox.Height);
                case Types.Direction.DOWNRIGHT:
                    return new Vector2(hitbox.X + hitbox.Width, hitbox.Y + hitbox.Height);
                default:
                    return new Vector2(0, 0);
            }
        }

        public static Vector2 AlignEdges(Rectangle hitbox, Rectangle alignedHitbox, Types.Direction hitboxEdge)
        {
            switch (hitboxEdge)
            {
                case Types.Direction.LEFT:
                    return new Vector2(hitbox.Left - alignedHitbox.Width, alignedHitbox.Y);
                case Types.Direction.RIGHT:
                    return new Vector2(hitbox.Right, alignedHitbox.Y);
                case Types.Direction.UP:
                    return new Vector2(alignedHitbox.X, hitbox.Top - alignedHitbox.Height);
                case Types.Direction.DOWN:
                    return new Vector2(alignedHitbox.X, hitbox.Bottom);
                case Types.Direction.UPLEFT:
                    return new Vector2(hitbox.X - alignedHitbox.Width, hitbox.Y - alignedHitbox.Height);
                case Types.Direction.UPRIGHT:
                    return new Vector2(hitbox.X + hitbox.Width, hitbox.Y - alignedHitbox.Height);
                case Types.Direction.DOWNLEFT:
                    return new Vector2(hitbox.X - alignedHitbox.Width, hitbox.Y + hitbox.Height);
                case Types.Direction.DOWNRIGHT:
                    return new Vector2(hitbox.X + hitbox.Width, hitbox.Y + hitbox.Height);
                default:
                    return new Vector2(0, 0);
            }
        }

        /* Returns the direction that opposes [direction] */
        public static Types.Direction GetOppositeDirection(Types.Direction direction)
        {
            switch (direction)
            {
                case Types.Direction.LEFT:
                    return Types.Direction.RIGHT;
                case Types.Direction.RIGHT:
                    return Types.Direction.LEFT;
                case Types.Direction.UP:
                    return Types.Direction.DOWN;
                case Types.Direction.DOWN:
                    return Types.Direction.UP;
                case Types.Direction.UPLEFT:
                    return Types.Direction.DOWNRIGHT;
                case Types.Direction.UPRIGHT:
                    return Types.Direction.DOWNLEFT;
                case Types.Direction.DOWNLEFT:
                    return Types.Direction.UPRIGHT;
                case Types.Direction.DOWNRIGHT:
                    return Types.Direction.UPLEFT;
                default:
                    return Types.Direction.NO_DIRECTION;
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

        public static Types.RoomTransition DirectionToRoomTransition(Types.Direction direction)
        {
            return direction switch
            {
                Types.Direction.LEFT => Types.RoomTransition.LEFT,
                Types.Direction.RIGHT => Types.RoomTransition.RIGHT,
                Types.Direction.UP => Types.RoomTransition.UP,
                Types.Direction.DOWN => Types.RoomTransition.DOWN,
                _ => Types.RoomTransition.SECRET,
            };
        }
    }
}
