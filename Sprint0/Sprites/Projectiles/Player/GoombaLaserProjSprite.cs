using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class GoombaLaserProjSprite : AbstractAnimatedSprite
    {
        private readonly Rectangle Drawbox;
        private static readonly Random RNG = new();

        public GoombaLaserProjSprite(Types.Direction direction) : base(4, RNG.Next(1, 9))
        {
            switch (direction)
            {
                case Types.Direction.DOWN:
                case Types.Direction.UP:
                    Drawbox = Resources.GoombaLaserVert;
                    break;
                case Types.Direction.LEFT:
                case Types.Direction.RIGHT:
                    Drawbox = Resources.GoombaLaserHorz;
                    break;
                default:
                    break;
            }
        }

        protected override Texture2D GetSpriteSheet() => Resources.GoombaMode;

        protected override Rectangle GetFirstFrame() => Drawbox;
    }
}
