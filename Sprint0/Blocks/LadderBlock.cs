using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class LadderBlock : AbstractBlock
    {
        public LadderBlock(Vector2 position) : base(position)
        {
            Sprite = new LadderBlockSprite();
        }
    }
}
