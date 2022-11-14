using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Doors.States.SecretUnlockedStates;
using Sprint0.Levels;
using Sprint0.Sprites;
using Sprint0.Sprites.Doors.WallDoorSprites;
using System.Collections.Generic;
using static Sprint0.Utils;

namespace Sprint0.Doors.States.WallStates
{
    public class UpSecretWallDoorState : AbstractImpassableDoorState
    {
        public UpSecretWallDoorState(Door door)
        {
            // Set context
            Door = door;
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = LevelResources.UpDoorPosition;

            // Create sprite
            DoorSprite = new UpWallDoorSprite();

            // Blocks
            Blocks = new List<IBlock>();
            CreateBlocks(Height, Width);
            CreateTriggers(Height, Width);
        }
        public override void Lock()
        {
            // Does nothing.
        }
        public override void Unlock()
        {
            // Get adjacent room
            Room adjacentRoom = Door.Room.GetAdjacentRoom(Types.RoomTransition.UP);
            // Get the door that is adjacent to this one and unlock it
            Door adjacentDoor = adjacentRoom.DoorHandler.GetDoors()["down"] as Door;
            adjacentDoor.State = new DownSecretUnlockedDoorState(adjacentDoor);
            Door.State = new UpSecretUnlockedDoorState(Door);
        }
        private void CreateTriggers(float height, float width)
        {
            IBlock block = BlockFactory.GetBlock(Types.Block.EXPLOSION_TRIGGER, Position + new Vector2(width / 2, height));
            block.SetParent(Door);
            Blocks.Add(block);
        }
        private void CreateBlocks(float height, float width)
        {
            Blocks.Add(BlockFactory.GetBlock(Types.Block.BORDER_BLOCK, Position + new Vector2(0, height))); // Left
            Blocks.Add(BlockFactory.GetBlock(Types.Block.BORDER_BLOCK, Position + new Vector2(width, height))); // Right
        }
        public override void Update(GameTime gameTime)
        {
            DoorSprite.Update();
        }
    }
}
