using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    public class BluePotion : AbstractItem
    {
        public BluePotion(Vector2 position) : base(new BluePotionSprite(), position, Types.Item.BLUE_POTION) { }
    }
}
