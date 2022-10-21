using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class BlueStairs : AbstractBlock
    {
        public BlueStairs(Vector2 position) : base(position)
        {
            Sprite = new BlueStairsSprite();
            Pushable = false;
            Walkable = true;
        }
    }
}
