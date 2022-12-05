using Microsoft.Xna.Framework;
using Sprint0.Sprites.Items;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    public class Bow : AbstractItem
    {
        public Bow(Vector2 position) : base(new BowSprite(), position, Types.Item.BOW) { }
    }
}
