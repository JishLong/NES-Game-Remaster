using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class Compass : AbstractItem
    {
        public Compass(Vector2 Position) : base(Position) 
        {
            sprite = new CompassSprite();
        }
    }
}
