using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Sprites.Characters.Npcs
{
    public class FlameSprite : AbstractAnimatedSprite
    {
        public FlameSprite() : base(2, 8) { }

        protected override Texture2D GetSpriteSheet() => Resources.CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.Flame;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float layerDepth)
        {
            if (CurrentFrame != 0)
            {
                Rectangle frame = GetFirstFrame();
                spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position), frame, color, 0, Vector2.Zero,
                    SpriteEffects.FlipHorizontally, layerDepth);
            }
            else base.Draw(spriteBatch, position, color, layerDepth);
        }
    }
}
