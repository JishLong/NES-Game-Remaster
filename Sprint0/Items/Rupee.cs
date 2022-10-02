using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class Rupee : AbstractItem
    {
        public Rupee(Vector2 Position) : base(Position)
        {
            sprite = new RupeeSprite();
        }
    }
}
