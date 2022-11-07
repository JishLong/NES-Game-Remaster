using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    public class HeartContainer : AbstractItem
    {
        public HeartContainer(Vector2 position) : base(new HeartContainerSprite(), position) { }

        public override Types.Item GetItemType()
        {
            return Types.Item.HEART_CONTAINER;
        }
    }
}
