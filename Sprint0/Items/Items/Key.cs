using Microsoft.Xna.Framework;
using Sprint0.Sprites.Items;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    public class Key : AbstractItem
    {
        public Key(Vector2 position) : base(new KeySprite(), position, Types.Item.KEY) { }
    }
}
