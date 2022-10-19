using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Movement
{
    public class PlayerMovingLeft : AnimatedSprite
    {
        public PlayerMovingLeft() : base(2, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkSideways;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            DrawSideways(spriteBatch, position, color, 0);
        }
    }
}
