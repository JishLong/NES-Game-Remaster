using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    // NOTE: this item is not currently in use
    public class Clock : AbstractItem
    {
        public Clock(Vector2 position) : base(new ClockSprite(), position) { }
    }
}
