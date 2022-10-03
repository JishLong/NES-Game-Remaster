using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class HeartContainer : AbstractItem
    {
        public HeartContainer(Vector2 position) : base(position)
        {
            Sprite = new HeartContainerSprite();
        }
    }
}
