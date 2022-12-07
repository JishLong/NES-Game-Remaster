using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Levels.Utils;
using Sprint0.Sprites.Doors.UnlockedDoors;
using System.Collections.Generic;

namespace Sprint0.Doors.States.UnlockedStates
{
    public class UpUnlockedDoorState : AbstractTraversableDoorState
    {
        public UpUnlockedDoorState(Door door)
        {
            // Set context
            Door = door;
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = LevelResources.UpDoorPosition;
            DoorWayOffset = new Vector2(0, Height);

            // Create sprites
            DoorWaySprite = new UnlockedDoorWayUpSprite();
            DoorWallSprite = new UnlockedDoorWallUpSprite();

            // Blocks
            Blocks = new List<IBlock>();
            CreateBlocks(Height, Width);

            // Triggers
            CreateTriggers(Height, Width);
        }

        private void CreateBlocks(float height, float width)
        {
            Blocks.Add(BlockFactory.GetBlock(Types.Block.LEFT_DOOR_WAY_BLOCK, Position)); // Top left
            Blocks.Add(BlockFactory.GetBlock(Types.Block.LEFT_DOOR_WAY_BLOCK, Position + new Vector2(0, height))); // Bottom left
            Blocks.Add(BlockFactory.GetBlock(Types.Block.RIGHT_DOOR_WAY_BLOCK, Position + new Vector2(width, 0))); // Top right
            Blocks.Add(BlockFactory.GetBlock(Types.Block.RIGHT_DOOR_WAY_BLOCK, Position + new Vector2(width, height))); // Bottom right
        }

        private void CreateTriggers(float height, float width)
        {
            Blocks.Add(BlockFactory.GetBlock(Types.Block.ROOM_TRANSITION_BLOCK, Position + new Vector2(width / 2, 0)));
        }
        public override void Lock()
        {
            throw new System.NotImplementedException();
        }

        public override void Unlock()
        {
            // Does nothing.
        }
        public override void Update(GameTime gameTime)
        {
            DoorWaySprite.Update();
            DoorWallSprite.Update();

            foreach (IBlock block in Blocks)
            {
                block.Update();
            }
        }
    }
}
