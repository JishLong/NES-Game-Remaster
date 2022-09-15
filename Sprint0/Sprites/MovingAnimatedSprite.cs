using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    public class MovingAnimatedSprite : ISprite
    {
        /* [sizeModifier]: Changes the scale of this sprite; lower number = bigger sprite
         * [moveSpeed]: Changes the speed at which this sprite moves left and right; lower number = faster
         * [x]: The x coordinate of this sprite
         * [direction]: The direction this sprite is moving in; 0 = left, 1 = right
         * [animSpeed]: Changes the speed at which this sprite cycles through its animation; lower number = faster
         * [frame]: The current animation frame this sprite is on in its cycle
         * [timer]: Used to determine when to advance to the next animation frame */
        private int sizeModifier, moveSpeed, x, direction, animSpeed, frame, timer;

        public MovingAnimatedSprite()
        {
            sizeModifier = 8;
            moveSpeed = 5;
            x = 0;
            direction = 1; 
            animSpeed = 3;
            frame = 0;
            timer = 0;
        }

        public void Update(int screenW, int screenH)
        {
            // Needed to ensure the sprite doesn't clip out of the screen
            int Size = screenW / sizeModifier;

            // Update the movement
            if (direction == 1)
            {
                x += moveSpeed;
                if (x > screenW - Size)
                {
                    x = screenW - Size;
                    direction--;
                }
            }
            else
            {
                x -= moveSpeed;
                if (x < 0)
                {
                    x = 0;
                    direction++;
                }
            }

            // Update the animation
            timer++;
            if (timer == animSpeed)
            {
                timer = 0;
                frame++;
                if (frame == 4)
                {
                    frame = 0;
                }
            }
        }

        public void Draw(SpriteBatch sb, int screenW, int screenH)
        {
            int Size = screenW / sizeModifier;

            sb.Draw(Resources.mario,
                new Rectangle(x, (screenH - Size) / 2, Size, Size),
                new Rectangle(frame * 16, direction * 16, 16, 16),
                Color.White);
        }
    }
}
