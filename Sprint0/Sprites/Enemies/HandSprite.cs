using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Enemies
{
    public class HandSprite : IEnemySprite
    {
        private Texture2D Sheet;

        private int Width = 16;
        private int Height = 16;
        private Vector2 Origin;
        private int SpriteScale = 3;

        private Rectangle Target;
        private Rectangle Source;

        private Animation MovingAnim;
        private int AnimSpeed = 1;
        public HandSprite()
        {
            Sheet = Resources.DungeonEnemySpriteSheet;

            MovingAnim = new Animation(Width, Height, AnimSpeed);
            MovingAnim.AddFrame(393, 11, 16, 16);
            MovingAnim.AddFrame(410, 12, 14, 15);
        }
        public void Update(GameTime gameTime)
        {
            MovingAnim.Update(gameTime);
        }

        public void Draw(SpriteBatch sb, Vector2 position)
        {

            Source = MovingAnim.CurrentRect();
            Target = new Rectangle((int)position.X, (int)position.Y, Source.Width * SpriteScale, Source.Height * SpriteScale);

            // Set origin
            Origin.X = Source.Width / 2;
            Origin.Y = Source.Height / 2;

            sb.Draw(Sheet, Target, Source, Color.White, 0f, origin: Origin, effects: SpriteEffects.None, 0f);
        }
    }
}
