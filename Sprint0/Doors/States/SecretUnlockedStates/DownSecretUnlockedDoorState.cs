using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Doors.States.KeyLockedStates;
using Sprint0.Levels.Utils;
using Sprint0.Sprites.Doors.SecretDoors;
using System.Collections.Generic;

namespace Sprint0.Doors.States.SecretUnlockedStates
{
    public class DownSecretUnlockedDoorState : AbstractTraversableDoorState
    {
        public DownSecretUnlockedDoorState(Door door)
        {
            // Set context
            Door = door;
            LevelResources = LevelResources.GetInstance();
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = LevelResources.DownDoorPosition + new Vector2(0, Height);
            DoorWayOffset = new Vector2(0, -Height);

            // Create sprites
            DoorWaySprite = new SecretDoorWayDownSprite();
            DoorWallSprite = new SecretDoorWallDownSprite();

            // Blocks
            Blocks = new List<IBlock>();
            CreateBlocks(Height, Width);

            // Triggers
            CreateTriggers(Height, Width);
        }
        private void CreateBlocks(float height, float width)
        {
            Blocks.Add(BlockFactory.GetBlock(Types.Block.LEFT_DOOR_WAY_BLOCK, Position + new Vector2(0, -height))); // Top left
            Blocks.Add(BlockFactory.GetBlock(Types.Block.LEFT_DOOR_WAY_BLOCK, Position)); // Bottom left
            Blocks.Add(BlockFactory.GetBlock(Types.Block.RIGHT_DOOR_WAY_BLOCK, Position + new Vector2(width, -height))); // Top right
            Blocks.Add(BlockFactory.GetBlock(Types.Block.RIGHT_DOOR_WAY_BLOCK, Position + new Vector2(width, 0))); // Bottom right
        }
        public override void Lock()
        {
            Door.State = new DownKeyLockedDoorState(Door);
        }
        public override void Unlock()
        {
            // Does nothing.
        }
        private void CreateTriggers(float height, float width)
        {
            Blocks.Add(BlockFactory.GetBlock(Types.Block.ROOM_TRANSITION_BLOCK, Position + new Vector2(width / 2, 0)));
        }
        public override void Update(GameTime gameTime)
        {
            DoorWaySprite.Update();
            DoorWallSprite.Update();
        }
    }
}
