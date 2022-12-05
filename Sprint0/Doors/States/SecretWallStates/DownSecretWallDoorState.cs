using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Doors.States.SecretUnlockedStates;
using Sprint0.Levels;
using Sprint0.Sprites.Doors.WallDoors;
using System.Collections.Generic;

namespace Sprint0.Doors.States.SecretWallStates
{
    public class DownSecretWallDoorState : AbstractImpassableDoorState
    {
        public DownSecretWallDoorState(Door door)
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
            CreateTriggers(Height, Width);
        }

        public override void Lock()
        {
            // Does nothing.
        }

        public override void Unlock()
        {
            // Get adjacent room
            Room adjacentRoom = Door.Room.GetAdjacentRoom(Types.RoomTransition.DOWN);
            // Get the door that is adjacent to this one and unlock it
            Door adjacentDoor = adjacentRoom.DoorHandler.GetDoors()["up"] as Door;
            adjacentDoor.State = new UpSecretUnlockedDoorState(adjacentDoor);
            Door.State = new DownSecretUnlockedDoorState(Door);
        }
        private void CreateTriggers(float height, float width)
        {
            IBlock block = BlockFactory.GetBlock(Types.Block.EXPLOSION_TRIGGER, Position + new Vector2(width / 2, 0));
            block.Parent = Door;
            Blocks.Add(block);
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
