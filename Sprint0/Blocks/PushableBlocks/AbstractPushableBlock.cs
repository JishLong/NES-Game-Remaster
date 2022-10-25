using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks.Utils;
using Sprint0.Levels;
using Sprint0.Sprites.Blocks;
using static Sprint0.Types;

namespace Sprint0.Blocks
{
    public class AbstractPushableBlock : AbstractBlock
    {
        public Types.Direction Direction { get; }
        private bool IsMoved;

        // Used to determine how long the block moves for
        private int FramesPassed;
        private int BlockSize;

        // The block that is "covered" by the pushable block
        private IBlock BlockUnderneath;

        protected AbstractPushableBlock(Vector2 position, Types.Direction direction) : base(position)
        {
            Sprite = new BlueWallSprite();
            Direction = direction;
            Walkable = false;
            FramesPassed = 0;
            BlockSize = Resources.BlueWall.Width;

            // IMPORTANT: this block is not seen by the collision system; the rest of the game doesn't know this block even exists
            BlockUnderneath = BlockFactory.GetInstance().GetBlock(Types.Block.BLUE_TILE, position);
        }

        public override void Update()
        {
            base.Update();
            if (IsMoved)
            {
                BlockUnderneath.Update();
                if (FramesPassed < BlockSize) 
                {
                    FramesPassed++;
                    Position += Sprint0.Utils.DirectionToVector(Direction) * Sprint0.Utils.GameScale;
                }
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            if (IsMoved) BlockUnderneath.Draw(sb);
            base.Draw(sb);
        }

        public void Push()
        {
            // Can only be moved one time
            if (!IsMoved) IsMoved = true;
        }
    }
}
