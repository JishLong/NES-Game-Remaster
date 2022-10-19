using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Stationary
{
    public class PlayerFacingLeft : StillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFrame() => Resources.LinkSideways;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            DrawSideways(spriteBatch, position, color, 0);
        }
    }
}
