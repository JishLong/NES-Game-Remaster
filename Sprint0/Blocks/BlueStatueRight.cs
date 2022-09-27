using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class BlueStatueRight : IBlock
    {
        // Sprite
        private ISprite sprite;

        // Coordinates and dimensions
        private int x, y, w, h;

        public BlueStatueRight(int x, int y)
        {
            sprite = new BlueStatueRightSprite();

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
