using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class Rupee : AbstractItem
    {
        public Rupee(Vector2 position) : base(position)
        {
            Sprite = new RupeeSprite();
        }
    }
}
