using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class BlueWall : AbstractBlock
    {
        public BlueWall(Vector2 position) : base(position)
        {
            Sprite = new BlueWallSprite();
        }
    }
}
