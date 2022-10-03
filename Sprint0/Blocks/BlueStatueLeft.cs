using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class BlueStatueLeft : AbstractBlock
    {
        public BlueStatueLeft(Vector2 position) : base(position)
        {
            Sprite = new BlueStatueLeftSprite();
        }
    }
}
