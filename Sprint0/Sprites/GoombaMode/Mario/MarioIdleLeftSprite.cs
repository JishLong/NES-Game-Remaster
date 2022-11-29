using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.GoombaMode.Mario
{
    public class MarioIdleLeftSprite : AbstractStillSprite
    {
        public MarioIdleLeftSprite() : base() { }

        protected override Texture2D GetSpriteSheet() => Resources.GoombaMode;

        protected override Rectangle GetFrame() => Resources.Mario;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float layer)
        {
            DrawFlippedHorz(spriteBatch, position, color, layer);
        }
    }
}
