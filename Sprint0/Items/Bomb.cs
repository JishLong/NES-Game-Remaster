using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class Bomb : AbstractItem
    {
        public Bomb(Vector2 Position) : base(Position)
        {
            sprite = new BombSprite();
        }
    }
}
