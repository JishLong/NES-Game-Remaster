using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class FireBlock : AbstractBlock
    {
        public FireBlock(Vector2 pos) : base(pos)
        {
            sprite = new FireBlockSprite();
        }
    }
}

