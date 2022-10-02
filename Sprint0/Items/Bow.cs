using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class Bow : AbstractItem
    {
        public Bow(Vector2 Position) : base(Position)
        {
            sprite = new BowSprite();
        }
    }
}
