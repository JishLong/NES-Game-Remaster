using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    public class Bomb : AbstractItem
    {
        public Bomb(Vector2 position) : base(new BombSprite(), position, Types.Item.BOMB) { }
    }
}
