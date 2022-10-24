using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks.Utils;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class AbstractPushableBlock : AbstractBlock
    {
        public Types.Direction Direction { get; }
        private bool HasBeenPushed;
        private int FramesPushed;

        // The block that is "covered" by the pushable block
        private IBlock BlockUnderneath;

        protected AbstractPushableBlock(Vector2 position, Types.Direction direction) : base(new BlueWallSprite(), position, true)
        {
            Direction = direction;
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

        public void Push()
        {
            // Can only be moved one time
            if (!HasBeenPushed) HasBeenPushed = true;
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
