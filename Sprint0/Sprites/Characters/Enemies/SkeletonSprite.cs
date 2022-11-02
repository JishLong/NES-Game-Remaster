using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class SkeletonSprite : AbstractAnimatedSprite
    {
        public SkeletonSprite() : base(2, 16)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.Skeleton;

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
