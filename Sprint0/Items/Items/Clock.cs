using Microsoft.Xna.Framework;
using Sprint0.Sprites.Items;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    public class Clock : AbstractItem
    {
        public Clock(Vector2 position) : base(new ClockSprite(), position, Types.Item.CLOCK) { }
    }
}
