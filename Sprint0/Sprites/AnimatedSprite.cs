using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    public class AnimatedSprite : ISprite
    {
        /* [sizeModifier]: Changes the scale of this sprite; lower number = bigger sprite
         * [speed]: Changes the speed at which this sprite cycles through its animation; lower number = faster
         * [frame]: The current animation frame this sprite is on in its cycle
         * [timer]: Used to determine when to advance to the next animation frame */
        private int sizeModifier, speed, frame, timer;

        public AnimatedSprite()
        {
            sizeModifier = 8;
            speed = 3;
            frame = 0;
            timer = 0;
        }

        public void Update(int screenW, int screenH)
        {
            timer++;
            if (timer == speed)
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
                new Rectangle((screenW - Size) / 2, (screenH - Size) / 2, Size, Size),
                new Rectangle(frame * 16, 0, 16, 16),
                Color.White);
        }
    }
}
