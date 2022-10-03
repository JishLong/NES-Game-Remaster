using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class Fairy : AbstractItem
    {
        public Fairy(Vector2 position) : base(position)
        {
            Sprite = new FairySprite();
        }
    }
}
