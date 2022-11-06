using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class SwordFlameProjSprite : AbstractAnimatedSprite
    {
        private readonly Types.Direction Direction;
        private readonly Rectangle Drawbox;

        public SwordFlameProjSprite(Types.Direction direction) : base(2, 2)
        {
            Direction = direction;
            switch (direction)
            {
                case Types.Direction.UPLEFT:
                    Drawbox = Resources.SwordFlameProjUp;
                    break;
                case Types.Direction.UPRIGHT:
                    Drawbox = Resources.SwordFlameProjUp;
                    break;
                case Types.Direction.DOWNLEFT:
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

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float layer)
        {
            if (Direction == Types.Direction.UPRIGHT || Direction == Types.Direction.DOWNRIGHT) DrawFlippedHorz(spriteBatch, position, color, layer);
            else base.Draw(spriteBatch, position, color, layer);
        }
    }
}
