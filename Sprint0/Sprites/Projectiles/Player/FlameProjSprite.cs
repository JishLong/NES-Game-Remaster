using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class FlameProjSprite: AbstractAnimatedSprite
    {
        public FlameProjSprite() : base(2, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.WeaponsAndProjSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.FlameProj;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float layer)
        {         
            if (CurrentFrame != 0)
            {
                Rectangle frame = GetFirstFrame();
                spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position + Camera.GetOffset()), frame, color, 0, Vector2.Zero,
                SpriteEffects.FlipHorizontally, layer);
            }
            else base.Draw(spriteBatch, position, color, layer); 
        }
    }
}
