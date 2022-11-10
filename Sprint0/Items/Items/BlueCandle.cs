using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    public class BlueCandle : AbstractItem
    {
        public BlueCandle(Vector2 position) : base(new BlueCandleSprite(), position, Types.Item.BLUE_CANDLE) { }
    }
}
