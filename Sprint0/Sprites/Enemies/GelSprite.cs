using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Sprites.Enemies
{
    public class GelSprite : IEnemySprite
    {
        private Texture2D Sheet;

        private int Width = 8;
        private int Height = 8;
        private Vector2 Origin;
        private int SpriteScale = 3;

        private Rectangle Target;
        private Rectangle Source;

        private Animation MovingAnim;
        private double AnimSpeed = 8;

        public GelSprite()
        {
            Sheet = Resources.DungeonEnemySpriteSheet;

            MovingAnim = new Animation(Width, Height, AnimSpeed);
            MovingAnim.AddFrame(1, 16, 8, 8);
            MovingAnim.AddFrame(11, 15, 6, 9);
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
            Origin.Y = Source.Height;

            sb.Draw(Sheet, Target, Source, Color.White, 0f, origin: Origin, effects: SpriteEffects.None, 0f);
        }
    }
}
