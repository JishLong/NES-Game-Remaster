using Microsoft.Xna.Framework;
using Sprint0.Sprites.Items;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    public class HeartContainer : AbstractItem
    {
        public HeartContainer(Vector2 position) : base(new HeartContainerSprite(), position, Types.Item.HEARTCONTAINER) { }
    }
}
