using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Sprites.Doors.WallDoors;
using System.Collections.Generic;

namespace Sprint0.Doors.States.WallStates
{
    public class UpWallDoorState : AbstractImpassableDoorState
    {
        public UpWallDoorState(Door door)
        {
            // Set context
            Door = door;
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = LevelResources.UpDoorPosition;

            // Create sprite
            DoorSprite = new WallDoorUpSprite();

            // Blocks
            Blocks = new List<IBlock>();
            CreateBlocks(Height, Width);
        }
        private void CreateBlocks(float height, float width)
        {
            Blocks.Add(BlockFactory.GetBlock(Types.Block.BORDER_BLOCK, Position + new Vector2(0, height))); // Left
            Blocks.Add(BlockFactory.GetBlock(Types.Block.BORDER_BLOCK, Position + new Vector2(width, height))); // Right
        }
        public override void Lock()
        {
            throw new System.NotImplementedException();
        }
        public override void Unlock()
        {
            throw new System.NotImplementedException();
        }
        public override void Update(GameTime gameTime)
        {
            DoorSprite.Update();
        }
    }
}
