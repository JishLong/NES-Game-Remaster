using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class Clock : IItem
    {
        // Sprite
        private ISprite sprite;

        // Coordinates and dimensions
        private int x, y, w, h;

        public Clock(int x, int y)
        {
            sprite = new ClockSprite();

            this.x = x;
            this.y = y;
            w = 64;
            h = 64;
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, x, y, w, h);
        }

        public void Update()
        {
            // Nothing here?
        }
    }
}
