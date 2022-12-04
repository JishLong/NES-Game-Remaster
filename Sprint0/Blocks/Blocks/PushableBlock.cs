using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.Blocks.Utils;
using Sprint0.Entities;
using Sprint0.Sprites.Blocks;
using static Sprint0.Utils;

namespace Sprint0.Blocks.Blocks
{
    public class PushableBlock : AbstractBlock, IEntity
    {
        private Types.Direction Direction;

        public bool HasBeenPushed {get; private set; }
        // A frame counter that is incremented while the block is being pushed
        private int FramesPushed;

        // The block that is "covered" by the pushable block
        private readonly IBlock BlockUnderneath;

        public PushableBlock(Vector2 position) : base(new BlueWallSprite(), position, true)
        {
            Direction = Types.Direction.NO_DIRECTION;
            HasBeenPushed = false;
            FramesPushed = 0;

            // IMPORTANT: this block is not seen by the collision system; the rest of the game doesn't know this block even exists
            // Assuming the block underneath is some kind of flooring, this doesn't actually matter
            BlockUnderneath = BlockFactory.GetInstance().GetBlock(Types.Block.BLUE_TILE, position);
        }

        public void Push(Types.Direction direction)
        {
            // Can only be moved one time
            if (!HasBeenPushed)
            {
                HasBeenPushed = true;
                Direction = direction;
                AudioManager.GetInstance().PlayOnce(AudioMappings.GetInstance().SecretFound);
            }
        }

        public void Reset() 
        {
            if (HasBeenPushed) 
            {
                Position -= DirectionToVector(Direction) * Sprite.GetDrawbox(Position).Width;
                HasBeenPushed = false;
                FramesPushed = 0;
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            if (HasBeenPushed) BlockUnderneath.Draw(sb);
            // The pushable block is technically on top of another block if it has been pushed, but is guaranteed to be drawn after it
            Sprite.Draw(sb, LinkToCamera(Position), Color.White, PushableBlockLayerDepth);
        }

        public override void Update()
        {
            base.Update();

            if (HasBeenPushed)
            {
                BlockUnderneath.Update();

                // We'll move the block one space in the direction [Direction]
                // NOTE: this condition assumes that the block dimensions are square (i.e. the width and height are equal)
                if (FramesPushed < Sprite.GetDrawbox(Position).Width)
                {
                    FramesPushed++;
                    Position += DirectionToVector(Direction);
                }
            }
        }
    }
}
