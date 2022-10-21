using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class BlueTile : AbstractBlock
    {
        public BlueTile(Vector2 position) : base(position)
        {
            Sprite = new BlueTileSprite();
            Pushable = false;
            Walkable = true;
        }
    }
}
