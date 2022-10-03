using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class FireBlock : AbstractBlock
    {
        public FireBlock(Vector2 position) : base(position)
        {
            Sprite = new FireBlockSprite();
        }
    }
}
