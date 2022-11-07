using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    // NOTE: this item is not currently in use
    public class Bomb : AbstractItem
    {
        public Bomb(Vector2 position) : base(new BombSprite(), position) { }

        public override Types.Item GetItemType()
        {
            return Types.Item.BOMB;
        }
    }
}
