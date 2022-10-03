using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class Heart : AbstractItem
    {
        public Heart(Vector2 position) : base(position)
        {
            Sprite = new HeartSprite();
        }
    }
}
