using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class BorderBlock : AbstractBlock
    {
        public BorderBlock(Vector2 position) : base(position)
        {
            Sprite = new BorderBlockSprite();
            Pushable = false;
            Walkable = false;
        }
    } 
}
