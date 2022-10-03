using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class Clock : AbstractItem
    {
        public Clock(Vector2 position) : base(position)
        {
            Sprite = new ClockSprite();
        }
    }
}
