using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Doors.States.UnlockedStates;
using Sprint0.Sprites.Doors.EventLockedDoors;
using System.Collections.Generic;

namespace Sprint0.Doors.States.EventLockedStates
{
    public class RightEventLockedDoorState : AbstractImpassableDoorState
    {
        public RightEventLockedDoorState(Door door)
        {
            // Set context
            Door = door;
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = new Vector2(Width * 14, Height * 4 + Height / 2);

            // Create sprite
            DoorSprite = new EventLockedDoorRightSprite();

            // Blocks
            Blocks = new List<IBlock>();
            CreateBlocks(Height, Width);
        }
        private void CreateBlocks(float height, float width)
        {
            Blocks.Add(BlockFactory.GetBlock(Types.Block.BORDER_BLOCK, Position)); // Top
            Blocks.Add(BlockFactory.GetBlock(Types.Block.BORDER_BLOCK, Position + new Vector2(0, height))); // Right
        }
        public override void Lock()
        {
            // Does nothing.
        }

        public override void Unlock()
        {
            Door.State = new RightUnlockedDoorState(Door);
        }
        public override void Update(GameTime gameTime)
        {
            DoorSprite.Update();
        }
    }
}
