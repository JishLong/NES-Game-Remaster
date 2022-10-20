using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Sprint0.Types;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class SwordMeleeSprite : StillSprite
    {
        private Rectangle Drawbox;

        public SwordMeleeSprite(Types.Direction direction)
        {
            switch (direction)
            {
                case Types.Direction.DOWN:
                case Types.Direction.UP:
                    Drawbox = Resources.ArrowProjVert;
                    break;
                case Types.Direction.LEFT:
                case Types.Direction.RIGHT:
                    Drawbox = Resources.ArrowProjHorz;
                    break;
                default:
                    break;
            }
        }

        protected override Texture2D GetSpriteSheet() => Resources.WeaponsAndProjSpriteSheet;

        protected override Rectangle GetFrame() => Resources.SwordMeleeHorz;
    }
}
