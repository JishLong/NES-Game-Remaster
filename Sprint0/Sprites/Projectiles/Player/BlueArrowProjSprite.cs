using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class BlueArrowProjSprite : StillSprite
    {
        private Types.Direction Direction;
        private Rectangle Drawbox;

        public BlueArrowProjSprite(Types.Direction direction)
        {
            Direction = direction;
            switch (direction)
            {
                case Types.Direction.DOWN:
                    xOffsetPixels = -5;
                    Drawbox = Resources.BlueArrowProjVert;
                    break;
                case Types.Direction.UP:
                    Drawbox = Resources.BlueArrowProjVert;
                    break;
                case Types.Direction.LEFT:
                    yOffsetPixels = -5;
                    Drawbox = Resources.BlueArrowProjHorz;
                    break;
                case Types.Direction.RIGHT:
                    Drawbox = Resources.BlueArrowProjHorz;
                    break;
                default:
                    break;
            }
        }

        protected override Texture2D GetSpriteSheet() => Resources.WeaponsAndProjSpriteSheet;

        protected override Rectangle GetFrame() => Drawbox;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            if (Direction == Types.Direction.LEFT) DrawFlippedHorz(spriteBatch, position, color);
            else if (Direction == Types.Direction.DOWN) DrawFlippedVert(spriteBatch, position, color);
            else base.Draw(spriteBatch, position, color);
        }
    }
}
