using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.GoombaMode.Goomba
{
    public class BlueGoombaSprite : AbstractAnimatedSprite
    {
        public BlueGoombaSprite() : base(2, 8) { }

        protected override Texture2D GetSpriteSheet() => Resources.GoombaMode;

        protected override Rectangle GetFirstFrame() => Resources.BlueGoomba;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float layer)
        {
            if (CurrentFrame != 0)
            {
                Rectangle frame = GetFirstFrame();
                spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position), frame, color, 0, Vector2.Zero,
                    SpriteEffects.FlipHorizontally, layer);
            }
            else base.Draw(spriteBatch, position, color, layer);
        }
    }
}
