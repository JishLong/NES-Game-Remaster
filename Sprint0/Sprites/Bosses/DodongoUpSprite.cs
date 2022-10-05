
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Bosses
{
    public class DodongoUpSprite : IBossSprite
    {
        private Texture2D Sheet;

        private int Width = 15;
        private int Height = 15;
        private int SpriteScale = 3;

        private Rectangle Target;
        private Rectangle Source;

        private Animation MovAnimation;
        private int AnimationSpd = 1;

        public DodongoUpSprite()
        {
            Sheet = Resources.BossEnemiesSpriteSheet;
            MovAnimation = new Animation(Width, Height, AnimationSpd);
            MovAnimation.AddFrame(35, 58);
            MovAnimation.AddFrame(35, 58);
        }
        public void Update(GameTime gameTime)
        {
            MovAnimation.Update(gameTime);
        }
        public void Draw(SpriteBatch sb, Vector2 position)
        {
            Target = new Rectangle((int)position.X, (int)position.Y, Width * SpriteScale, Height * SpriteScale);
            Source = MovAnimation.CurrentRect();
            Vector2 origin = new Vector2(0, 0);

            if (MovAnimation.CurrentFrame == 0)
            {
                SpriteEffects flip = SpriteEffects.FlipHorizontally;
                sb.Draw(Sheet, Target, Source, Color.White, 0f, origin, flip, 0f);
            }
            else
            {
                sb.Draw(Sheet, Target, Source, Color.White, 0f, origin, SpriteEffects.None, 0f);
            }
        }
    }
}