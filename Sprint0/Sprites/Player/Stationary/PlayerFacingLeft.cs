using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Stationary
{
    public class PlayerFacingLeft : AbstractStillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFrame() => Resources.LinkSideways;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            DrawFlippedHorz(spriteBatch, position, color);
        }
    }
}
