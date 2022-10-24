using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class SwordProjSprite : AnimatedSprite
    {
        private Types.Direction Direction;
        private Rectangle Drawbox;

        public SwordProjSprite(Types.Direction direction) : base(2, 2)
        {
            Direction = direction;
            switch (direction)
            {
                case Types.Direction.DOWN:
                    xOffsetPixels = 0;
                    Drawbox = Resources.SwordProjVert;
                    break;
                case Types.Direction.UP:
                    Drawbox = Resources.SwordProjVert;
                    break;
                case Types.Direction.LEFT:
                    yOffsetPixels = 0;
                    Drawbox = Resources.SwordProjHorz;
                    break;
                case Types.Direction.RIGHT:
                    Drawbox = Resources.SwordProjHorz;
                    break;
                default:
                    break;
            }
        }

        protected override Texture2D GetSpriteSheet() => Resources.WeaponsAndProjSpriteSheet;

        protected override Rectangle GetFirstFrame() => Drawbox;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            if (Direction == Types.Direction.LEFT) DrawFlippedHorz(spriteBatch, position, color);
            else if (Direction == Types.Direction.DOWN) DrawFlippedVert(spriteBatch, position, color);
            else base.Draw(spriteBatch, position, color);
        }
    }
}
