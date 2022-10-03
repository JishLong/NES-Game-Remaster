using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class WoodenBoomerang : AbstractItem
    {
        public WoodenBoomerang(Vector2 position) : base(position)
        {
            Sprite = new WoodenBoomerangSprite();
        }
    }
}
