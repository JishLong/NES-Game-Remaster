using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Sprites.Doors.WallDoors;
using System.Collections.Generic;

namespace Sprint0.Doors.States.WallStates
{
    public class DownWallDoorState : AbstractImpassableDoorState
    {
        public DownWallDoorState(Door door)
        {
            // Set context
            Door = door;
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = LevelResources.DownDoorPosition;

            // Create sprite
            DoorSprite = new WallDoorDownSprite();

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
            // Door.State = new DownHiddenDoorState();
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
