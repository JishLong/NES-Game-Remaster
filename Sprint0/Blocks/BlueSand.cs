using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class BlueSand : AbstractBlock
    {
        public BlueSand(Vector2 position) : base(position)
        {
            Sprite = new BlueSandSprite();
            Pushable = false;
            Walkable = true;
        }
    }
}
