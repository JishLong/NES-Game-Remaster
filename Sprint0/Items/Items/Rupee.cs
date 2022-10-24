using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    // NOTE: this item is not currently in use
    public class Rupee : AbstractItem
    {
        public Rupee(Vector2 position) : base(new RupeeSprite(), position) { }
    }
}
