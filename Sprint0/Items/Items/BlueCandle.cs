using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    // NOTE: this item is not currently in use
    public class BlueCandle : AbstractItem
    {
        public BlueCandle(Vector2 position) : base(new BlueCandleSprite(), position) { }

        public override Types.Item GetItemType()
        {
            return Types.Item.BLUE_CANDLE;
        }
    }
}
