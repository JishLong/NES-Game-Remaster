using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class BlueSand : AbstractBlock
    {
        public BlueSand(Vector2 pos) : base(pos)
        {
            sprite = new BlueSandSprite();
        }
    }
}
