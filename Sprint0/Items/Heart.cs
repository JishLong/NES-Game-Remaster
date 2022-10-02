using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class Heart : AbstractItem
    {
        public Heart(Vector2 Position) : base(Position)
        {
            sprite = new HeartSprite();
        }
    }
}
