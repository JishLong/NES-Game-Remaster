using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Doors.States.UnlockedStates;
using Sprint0.Sprites.Doors.EventLockedDoors;
using System.Collections.Generic;

namespace Sprint0.Doors.States.EventLockedStates
{
    public class DownEventLockedDoorState : AbstractImpassableDoorState
    {
        public DownEventLockedDoorState(Door door)
        {
            // Set context
            Door = door;
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = new Vector2(Width * 7, Height * 9);

            // Create sprite
            DoorSprite = new EventLockedDoorDownSprite();

            // Blocks
            Blocks = new List<IBlock>();
            CreateBlocks(Height, Width);
        }

        public override void Lock()
        {
            // Does nothing.
        }

        public override void Unlock()
        {
            Door.State = new DownUnlockedDoorState(Door);
        }

        private void CreateBlocks(float height, float width)
        {
            Blocks.Add(BlockFactory.GetBlock(Types.Block.BORDER_BLOCK, Position + new Vector2(0, 0))); // Left
            Blocks.Add(BlockFactory.GetBlock(Types.Block.BORDER_BLOCK, Position + new Vector2(width, 0))); // Right 
        }
        public override void Update(GameTime gameTime)
        {
            DoorSprite.Update();
        }
    }
}
