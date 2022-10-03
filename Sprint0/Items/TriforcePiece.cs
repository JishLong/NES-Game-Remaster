using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class TriforcePiece : AbstractItem
    {
        public TriforcePiece(Vector2 position) : base(position)
        {
            Sprite = new TriforcePieceSprite();
        }
    }
}
