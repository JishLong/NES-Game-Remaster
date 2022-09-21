using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    public class AnimatedSprite : ISprite
    {
        private Texture2D spriteSheet;
        private Rectangle[] frames;
        protected int speed;
        private int currentFrame, timer;

        public AnimatedSprite(Texture2D spriteSheet, int numFrames)
        {
            this.spriteSheet = spriteSheet;
            CreateFrames(spriteSheet, numFrames);
            currentFrame = 0;
            speed = 0;
            timer = 0;
        }

        private void CreateFrames(Texture2D spriteSheet, int numFrames)
        {
            int SsWidth = spriteSheet.Width;
            int SsHeight = spriteSheet.Height;

            frames = new Rectangle[numFrames];

            for (int i = 0; i < numFrames; i++)
            {
                frames[i] = new Rectangle(i * SsWidth / numFrames, 0, SsWidth / numFrames, SsHeight);
            }
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y, int w, int h)
        {
            spriteBatch.Draw(spriteSheet, new Rectangle(x, y, w, h), frames[currentFrame], Color.White);
        }

        public void Update()
        {
            timer++;
            if (timer >= speed)
            {
                timer = 0;
                currentFrame++;
                if (currentFrame >= frames.Length)
                {
                    currentFrame = 0;
                }
            }
        }
    }
}
