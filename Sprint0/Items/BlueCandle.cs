using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class BlueCandle : AbstractItem
    {
        public BlueCandle(Vector2 Position) : base(Position)
        {
            sprite = new BlueCandleSprite();
        }
    }
}
