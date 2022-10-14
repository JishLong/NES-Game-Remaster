using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class FlameProjSprite: AnimatedSprite
    {
        public FlameProjSprite() : base(2, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.WeaponsAndProjSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.FlameProj;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float rotation)
        {
            Rectangle frame = GetFirstFrame();
            SpriteEffects Effects = SpriteEffects.None;
            if (CurrentFrame != 0)
            {
                Effects = SpriteEffects.FlipHorizontally;
            }

            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position), frame, color, rotation, Vector2.Zero,
                Effects, 0);
        }
    }
}
