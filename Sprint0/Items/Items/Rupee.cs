using Microsoft.Xna.Framework;
using Sprint0.Sprites.Items;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    public class Rupee : AbstractItem
    {
        public Rupee(Vector2 position) : base(new RupeeSprite(), position, Types.Item.RUPEE) { }
    }
}
