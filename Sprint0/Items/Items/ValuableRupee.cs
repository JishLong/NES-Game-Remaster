using Microsoft.Xna.Framework;
using Sprint0.Sprites.Items;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    public class ValuableRupee : AbstractItem
    {
        public ValuableRupee(Vector2 position) : base(new ValuableRupeeSprite(), position, Types.Item.RUPEE) { }
    }
}
