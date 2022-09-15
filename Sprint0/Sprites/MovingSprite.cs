using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    public class MovingSprite : ISprite
    {
        /* [sizeModifier]: Changes the scale of this sprite; lower number = bigger sprite
         * [speed]: Changes the speed at which this sprite moves up and down; lower number = faster
         * [y]: The y coordinate of this sprite */
        private int sizeModifier, speed, y;

        // Whether or not this sprite is moving downwards
        private bool movingDown;

        public MovingSprite() 
        {
            sizeModifier = 8;
            speed = 5;
            y = 0;
            movingDown = false;
        }

        public void Update(int screenW, int screenH)
        {
            // Needed to ensure the sprite doesn't clip out of the screen
            int Size = screenW / sizeModifier;

            if (movingDown)
            {
                y += speed;
                if (y > screenH - Size) 
                {
                    y = screenH - Size;
                    movingDown = false;
                }
            }
            else 
            {
                y -= speed;
                if (y < 0)
                {
                    y = 0;
                    movingDown = true;
                }
            }
        }

        public void Draw(SpriteBatch sb, int screenW, int screenH)
        {
            int Size = screenW / sizeModifier;

            sb.Draw(Resources.mario,
                new Rectangle((screenW - Size) / 2, y, Size, Size),
                new Rectangle(0, 0, 16, 16),
                Color.White);
        }
    }
}
