using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    public class Compass : AbstractItem
    {
        public Compass(Vector2 position) : base(new CompassSprite(), position) { }
    }
}
