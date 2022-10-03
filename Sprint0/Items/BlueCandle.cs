using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class BlueCandle : AbstractItem
    {
        public BlueCandle(Vector2 position) : base(position)
        {
            Sprite = new BlueCandleSprite();
        }
    }
}
