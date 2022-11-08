using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    // NOTE: this item is not currently in use
    public class Bow : AbstractItem
    {
        public Bow(Vector2 position) : base(new BowSprite(), position) { }

        public override Types.Item GetItemType()
        {
            return Types.Item.BOW;
        }
    }
}
