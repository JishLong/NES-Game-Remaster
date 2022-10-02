using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class BluePotion : AbstractItem
    {
        public BluePotion(Vector2 Position) : base(Position)
        {
            sprite = new BluePotionSprite();
        }
    }
}
