using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    public class StillSprite : ISprite
    {
        // Changes the scale of this sprite; lower number = bigger sprite
        private int sizeModifier;

        public StillSprite() 
        {
            sizeModifier = 8;
        }

        public void Update(int screenW, int screenH)
        {
            // Nothing needed here
        }

        public void Draw(SpriteBatch sb, int screenW, int screenH)
        {
            int Size = screenW / sizeModifier;

            sb.Draw(Resources.mario,
                new Rectangle((screenW - Size) / 2, (screenH - Size) / 2, Size, Size),
                new Rectangle(0, 0, 16, 16),
                Color.White);
        }
    }
}
