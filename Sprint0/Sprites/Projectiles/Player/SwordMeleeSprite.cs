using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class SwordMeleeSprite : AbstractStillSprite
    {
        private Rectangle Drawbox;

        public SwordMeleeSprite(Types.Direction direction)
        {
            switch (direction)
            {
                case Types.Direction.DOWN:
                case Types.Direction.UP:
                    Drawbox = Resources.SwordMeleeVert;
                    break;
                case Types.Direction.LEFT:
                case Types.Direction.RIGHT:
                    Drawbox = Resources.SwordMeleeHorz;
                    break;
                default:
                    break;
            }
        }

        protected override Texture2D GetSpriteSheet() => Resources.WeaponsAndProjSpriteSheet;

        protected override Rectangle GetFrame() => Drawbox;
    }
}
