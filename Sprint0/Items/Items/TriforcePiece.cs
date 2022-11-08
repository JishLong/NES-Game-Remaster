using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    public class TriforcePiece : AbstractItem
    {
        public TriforcePiece(Vector2 position) : base(new TriforcePieceSprite(), position) { }

        public override Types.Item GetItemType()
        {
            return Types.Item.TRIFORCE_PIECE;
        }
    }
}
