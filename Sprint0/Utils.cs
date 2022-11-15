using Microsoft.Xna.Framework;
using System.Text;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    // Contains various important methods and values used throughout the code
    public static class Utils
    {
        // How big everything on the screen is - essentially used to "scale up" or "scale down" images
        public static float GameScale = 3;

        // Screen size
        public static int GameWidth = 256 * (int)GameScale;
        public static int GameHeight = 232 * (int)GameScale;

        // Sprite Layer Depths
        public static readonly float DoorWayLayerDepth = 1.0f;
        public static readonly float BlockLayerDepth = 1.0f;
        public static readonly float PushableBlockLayerDepth = 0.9f;
        public static readonly float WallLayerDepth = 0.8f;
        public static readonly float ItemLayerDepth = 0.7f;
        public static readonly float CharacterLayerDepth = 0.6f;
        public static readonly float PlayerLayerDepth = 0.5f;
        public static readonly float ProjectileLayerDepth = 0.4f;
        public static readonly float DoorWallLayerDepth = 0.2f; // Needs to be drawn on top of the player.
        public static readonly float HUDLayerDepth = 0.0f;

        // This will be used for Sprint 5 features
        public static void UpdateWindowSize(GraphicsDeviceManager graphics)
        {
            GameWidth = graphics.GraphicsDevice.Viewport.Width;
            GameHeight = graphics.GraphicsDevice.Viewport.Height;

            GameScale = GameWidth / 256;
            GameScale = GameHeight / 176;
        }

        // Returns a position for [centeredHitbox] such that the center points of [hitbox] and [centeredHitbox] fall on the same point
        public static Vector2 CenterRectangles(Rectangle hitbox, int centeredHitboxWidth, int centeredHitboxHeight)
        {
            return new Vector2(hitbox.X + hitbox.Width / 2 - centeredHitboxWidth / 2, hitbox.Y + hitbox.Height / 2 - centeredHitboxHeight / 2);
        }

        /* Returns a position for [linedUpHitbox] such that [hitboxEdge] of [hitbox] and the opposite edge of [linedUpHitbox] fall on
         * the same line
         */
        public static Vector2 LineUpEdges(Rectangle hitbox, Rectangle linedUpHitbox, Types.Direction hitboxEdge)
        {
            return hitboxEdge switch
            {
                Types.Direction.LEFT => new Vector2(hitbox.Left - linedUpHitbox.Width, linedUpHitbox.Y),
                Types.Direction.RIGHT => new Vector2(hitbox.Right, linedUpHitbox.Y),
                Types.Direction.UP => new Vector2(linedUpHitbox.X, hitbox.Top - linedUpHitbox.Height),
                Types.Direction.DOWN => new Vector2(linedUpHitbox.X, hitbox.Bottom),
                Types.Direction.UPLEFT => new Vector2(hitbox.X - linedUpHitbox.Width, hitbox.Y - linedUpHitbox.Height),
                Types.Direction.UPRIGHT => new Vector2(hitbox.X + hitbox.Width, hitbox.Y - linedUpHitbox.Height),
                Types.Direction.DOWNLEFT => new Vector2(hitbox.X - linedUpHitbox.Width, hitbox.Y + hitbox.Height),
                Types.Direction.DOWNRIGHT => new Vector2(hitbox.X + hitbox.Width, hitbox.Y + hitbox.Height),
                _ => new Vector2(0, 0),
            };
        }

        /* Returns a position for [alignedHitbox] such that [hitboxEdge] of [hitbox] and the opposite edge of [alignedHitbox] both fall on
         * the same line and have midpoints that fall on the same point
         */
        public static Vector2 AlignEdges(Rectangle hitbox, int alignedHitboxWidth, int alignedHitboxHeight, Types.Direction hitboxEdge)
        {
            return hitboxEdge switch
            {
                Types.Direction.LEFT => new Vector2(hitbox.Left - alignedHitboxWidth, hitbox.Y + hitbox.Height / 2 - alignedHitboxHeight / 2),
                Types.Direction.RIGHT => new Vector2(hitbox.Right, hitbox.Y + hitbox.Height / 2 - alignedHitboxHeight / 2),
                Types.Direction.UP => new Vector2(hitbox.X + hitbox.Width / 2 - alignedHitboxWidth / 2, hitbox.Top - alignedHitboxHeight),
                Types.Direction.DOWN => new Vector2(hitbox.X + hitbox.Width / 2 - alignedHitboxWidth / 2, hitbox.Bottom),
                Types.Direction.UPLEFT => new Vector2(hitbox.X - alignedHitboxWidth, hitbox.Y - alignedHitboxHeight),
                Types.Direction.UPRIGHT => new Vector2(hitbox.X + hitbox.Width, hitbox.Y - alignedHitboxHeight),
                Types.Direction.DOWNLEFT => new Vector2(hitbox.X - alignedHitboxWidth, hitbox.Y + hitbox.Height),
                Types.Direction.DOWNRIGHT => new Vector2(hitbox.X + hitbox.Width, hitbox.Y + hitbox.Height),
                _ => new Vector2(0, 0),
            };
        }

        // Returns a position for [centeredHitbox] such that its center point falls on the same point as the midpoint of [hitboxEdge] of [hitbox]
        public static Vector2 CenterOnEdge(Rectangle hitbox, int centeredHitboxWidth, int centeredHitboxHeight, Types.Direction hitboxEdge)
        {
            return hitboxEdge switch
            {
                Types.Direction.LEFT => new Vector2(hitbox.Left - centeredHitboxWidth / 2, hitbox.Y + hitbox.Height / 2 - centeredHitboxHeight / 2),
                Types.Direction.RIGHT => new Vector2(hitbox.Right - centeredHitboxWidth / 2, hitbox.Y + hitbox.Height / 2 - centeredHitboxHeight / 2),
                Types.Direction.UP => new Vector2(hitbox.X + hitbox.Width / 2 - centeredHitboxWidth / 2, hitbox.Top - centeredHitboxHeight / 2),
                Types.Direction.DOWN => new Vector2(hitbox.X + hitbox.Width / 2 - centeredHitboxWidth / 2, hitbox.Bottom - centeredHitboxHeight / 2),
                _ => new Vector2(0, 0),
            };
        }

        /* Returns the direction that opposes [direction] */
        public static Types.Direction GetOppositeDirection(Types.Direction direction)
        {
            return direction switch
            {
                Types.Direction.LEFT => Types.Direction.RIGHT,
                Types.Direction.RIGHT => Types.Direction.LEFT,
                Types.Direction.UP => Types.Direction.DOWN,
                Types.Direction.DOWN => Types.Direction.UP,
                Types.Direction.UPLEFT => Types.Direction.DOWNRIGHT,
                Types.Direction.UPRIGHT => Types.Direction.DOWNLEFT,
                Types.Direction.DOWNLEFT => Types.Direction.UPRIGHT,
                Types.Direction.DOWNRIGHT => Types.Direction.UPLEFT,
                _ => Types.Direction.NO_DIRECTION,
            };
        }

        public static Vector2 DirectionToVector(Types.Direction direction)
        {
            return direction switch
            {
                Types.Direction.LEFT => new Vector2(-1, 0),
                Types.Direction.RIGHT => new Vector2(1, 0),
                Types.Direction.UP => new Vector2(0, -1),
                Types.Direction.DOWN => new Vector2(0, 1),
                Types.Direction.UPLEFT => new Vector2(-1, -1),
                Types.Direction.UPRIGHT => new Vector2(1, -1),
                Types.Direction.DOWNRIGHT => new Vector2(1, 1),
                Types.Direction.DOWNLEFT => new Vector2(-1, 1),
                _ => new Vector2(0, 0),
            };
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

        /* Returns an array of words [Strings] such that each Strings[i] is as long as possible without going over [width]
         * if you were to draw each string in Strings[i] to the screen; each word is separated by a SPACE character
         */
        public static List<string> GetAlignedText(string longString, SpriteFont font, int width)
        {
            if (width <= 0)
                return null;

            List<string> Strings = new();
            StringBuilder line = new();
            int start = 0;
            int space = longString.IndexOf(' ');

            while (space != -1)
            {
                // If the next word will fit in the current Strings[i], then we'll add it
                if (font.MeasureString(longString[start..space] + line).X <= width)
                    line.Append(longString.AsSpan(start, space-start));
                // If not, we'll make a new Strings[i] and add it to that instead
                else if (line.ToString().Equals(""))
                    Strings.Add(longString[start..space]);
                else
                {
                    Strings.Add(line.ToString());
                    line = new StringBuilder(longString[start..space]);
                }
                start = space;
                space = longString.IndexOf(' ', start + 1);
            }

            // Now that there aren't any more spaces, we must be on the last word
            if (font.MeasureString(longString[start..] + line).X <= width)
                Strings.Add(line + longString[start..]);
            else
            {
                if (!line.ToString().Equals(""))
                    Strings.Add(line.ToString());
                Strings.Add(longString[start..]);
            }

            // Trim some of the extra space at the beginning and end of each Strings[i]
            /*for (int i = 0; i < Strings.Count; i++) 
            {
                Strings[i] = Strings[i].Trim();
            }*/

            return Strings;
        }
    }
}
