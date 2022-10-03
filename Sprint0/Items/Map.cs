using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class Map : AbstractItem
    {
        public Map(Vector2 position) : base(position)
        {
            Sprite = new MapSprite();
        }
    }
}
