using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class Compass : AbstractItem
    {
        public Compass(Vector2 position) : base(position) 
        {
            Sprite = new CompassSprite();
        }
    }
}
