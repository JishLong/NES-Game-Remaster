using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class SwordFlameProjSprite : AnimatedSprite
    {
        private Types.Direction Direction;
        private Rectangle Drawbox;

        public SwordFlameProjSprite(Types.Direction direction) : base(2, 2)
        {
            Direction = direction;
            switch (direction)
            {
                case Types.Direction.UPLEFT:
                    xOffsetPixels = -8;
                    Drawbox = Resources.SwordFlameProjUp;
                    break;
                case Types.Direction.UPRIGHT:
                    Drawbox = Resources.SwordFlameProjUp;
                    break;
                case Types.Direction.DOWNLEFT:
                    xOffsetPixels = -8;
                    Drawbox = Resources.SwordFlameProjDown;
                    break;
                case Types.Direction.DOWNRIGHT:
                    Drawbox = Resources.SwordFlameProjDown;
                    break;
                default:
                    break;
            }
        }

        protected override Texture2D GetSpriteSheet() => Resources.WeaponsAndProjSpriteSheet;

        protected override Rectangle GetFirstFrame() => Drawbox;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            if (Direction == Types.Direction.UPRIGHT || Direction == Types.Direction.DOWNRIGHT) DrawFlippedHorz(spriteBatch, position, color);
            else base.Draw(spriteBatch, position, color);
        }
    }
}
