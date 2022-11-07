using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Levels.Utils;
using Sprint0.Sprites;
using Sprint0.Sprites.Doors;
using System.Collections.Generic;
using static Sprint0.Utils;

namespace Sprint0.Doors.States
{
    public class DownUnlockedDoorState: AbstractTraversableDoorState
    {
        IDoor Door;
        public DownUnlockedDoorState(IDoor door)
        {
            // Set context
            Door = door;
            LevelResources = LevelResources.GetInstance();
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = LevelResources.DownDoorPosition;
            DoorWayOffset = new Vector2(0,-Height);

            // Create sprites
            DoorWaySprite = new DownUnlockedDoorWaySprite();
            DoorWallSprite = new DownUnlockedDoorWallSprite();

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
        private void CreateTriggers(float height, float width)
        {
            Blocks.Add(BlockFactory.GetBlock(Types.Block.ROOM_TRANSITION_BLOCK, Position + new Vector2(width/2, 0)));
        }
        public override void Update(GameTime gameTime)
        {
            DoorWaySprite.Update();
            DoorWallSprite.Update();
        }
    }
}
