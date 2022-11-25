using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Doors.States.UnlockedStates;
using Sprint0.Levels;
using Sprint0.Sprites;
using Sprint0.Sprites.Doors;
using Sprint0.Sprites.Doors.KeyLockedDoorSprites;
using System.Collections.Generic;
using static Sprint0.Utils;

namespace Sprint0.Doors.States.KeyLockedStates
{
    public class RightKeyLockedDoorState : AbstractImpassableDoorState
    {
        public RightKeyLockedDoorState(Door door)
        {
            // Set context
            Door = door;
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = LevelResources.RightDoorPosition;

            // Create sprite
            DoorSprite = new RightKeyLockedDoorSprite();

            // Blocks
            Blocks = new List<IBlock>();
            CreateBlocks(Height, Width);

            // Triggers
            CreateTriggers(Height, Width);
        }

        public override void Lock()
        {
            // Does nothing.
        }

        public override void Unlock()
        {
            // Get adjacent room
            Room adjacentRoom = Door.Room.GetAdjacentRoom(Types.RoomTransition.RIGHT);
            // Get the door that is adjacent to this one and unlock it
            Door adjacentDoor = adjacentRoom.DoorHandler.GetDoors()["left"] as Door;
            adjacentDoor.State = new LeftUnlockedDoorState(adjacentDoor);
            Door.State = new RightUnlockedDoorState(Door);
        }

        private void CreateBlocks(float height, float width)
        {
            Blocks.Add(BlockFactory.GetBlock(Types.Block.BORDER_BLOCK, Position)); // Top
            Blocks.Add(BlockFactory.GetBlock(Types.Block.BORDER_BLOCK, Position + new Vector2(0, height))); // Right
        }
        private void CreateTriggers(float height, float width)
        {
            IBlock block = BlockFactory.GetBlock(Types.Block.UNLOCK_DOOR_TRIGGER, Position + new Vector2(-1, 0));
            block.Parent = Door;
            Blocks.Add(block);
        }
        public override void Update(GameTime gameTime)
        {
            DoorSprite.Update();
        }
    }
}
