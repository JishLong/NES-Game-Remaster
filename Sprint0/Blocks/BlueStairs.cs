using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class BlueStairs : IBlock
    {
        // Sprite
        private ISprite sprite;

        // Coordinates and dimensions
        private int x, y, w, h;

        public BlueStairs(int x, int y)
        {
            sprite = new BlueStairsSprite();

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
