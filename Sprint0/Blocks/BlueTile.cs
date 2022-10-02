using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class BlueTile : AbstractBlock
    {
        public BlueTile(Vector2 pos) : base(pos)
        {
            sprite = new BlueTileSprite();
        }
    }
}

