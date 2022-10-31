using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks.Utils;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    public class PushableBlock : AbstractBlock
    {
        private Types.Direction Direction;
        private bool HasBeenPushed;
        private int FramesPushed;

        // The block that is "covered" by the pushable block
        private readonly IBlock BlockUnderneath;

        public PushableBlock(Vector2 position) : base(new BlueWallSprite(), position, true)
        {
            Direction = Types.Direction.NO_DIRECTION;
            HasBeenPushed = false;
            FramesPushed = 0;

            // IMPORTANT: this block is not seen by the collision system; the rest of the game doesn't know this block even exists
            BlockUnderneath = BlockFactory.GetInstance().GetBlock(Types.Block.BLUE_TILE, position);
        }

        public override void Draw(SpriteBatch sb)
        {
            if (HasBeenPushed) BlockUnderneath.Draw(sb);
            base.Draw(sb);
        }

        public void Push(Types.Direction direction)
        {
            // Can only be moved one time
            if (!HasBeenPushed)
            {
                HasBeenPushed = true;
                Direction = direction;
                AudioManager.GetInstance().PlayOnce(Resources.SecretFound);
            }
        }

        public override void Update()
        {
            base.Update();
            if (HasBeenPushed)
            {
                BlockUnderneath.Update();

                // We'll move the block one space in the direction [Direction]
                if (FramesPushed < Sprite.GetDrawbox(Position).Width)
                {
                    FramesPushed++;
                    Position += Sprint0.Utils.DirectionToVector(Direction);
                }
            }
        }
    }
}
