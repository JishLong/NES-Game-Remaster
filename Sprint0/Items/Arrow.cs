using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class Arrow : AbstractItem
    {
        public Arrow(Vector2 Position) : base(Position)
        {
            sprite = new ArrowSprite();
        }
    }
}
