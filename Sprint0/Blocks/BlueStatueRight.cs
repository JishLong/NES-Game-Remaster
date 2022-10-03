using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class BlueStatueRight : AbstractBlock
    {
        public BlueStatueRight(Vector2 position) : base(position)
        {
            Sprite = new BlueStatueRightSprite();
        }
    }
}
