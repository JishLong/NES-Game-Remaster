using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class Bomb : AbstractItem
    {
        public Bomb(Vector2 position) : base(position)
        {
            Sprite = new BombSprite();
        }
    }
}
