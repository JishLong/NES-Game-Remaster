using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    public class Arrow : AbstractItem
    {
        public Arrow(Vector2 position) : base(new ArrowSprite(), position, Types.Item.ARROW) { }
    }
}
