using Microsoft.Xna.Framework;
using Sprint0.Sprites.Items;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    public class Heart : AbstractItem
    {
        public Heart(Vector2 position) : base(new HeartSprite(), position, Types.Item.HEART) { }
    }
}
