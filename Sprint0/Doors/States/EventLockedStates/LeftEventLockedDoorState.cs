using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Doors.States.UnlockedStates;
using Sprint0.Levels.Utils;
using Sprint0.Sprites;
using Sprint0.Sprites.Doors.EventLockedDoorSprites;
using System.Collections.Generic;
using static Sprint0.Utils;

namespace Sprint0.Doors.States.EventLockedStates
{
    public class LeftEventLockedDoorState : AbstractImpassableDoorState 
    {
        public LeftEventLockedDoorState(Door door)
        {
            // Set context
            Door = door;
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = new Vector2(0, Height * 4 + Height / 2);

            // Create sprites
            DoorSprite = new LeftEventLockedDoorSprite();

            // Create blocks
            Blocks = new List<IBlock>();
            CreateBlocks(Height, Width);
        }
        private void CreateBlocks(float height, float width)
        {
            Blocks.Add(BlockFactory.GetBlock(Types.Block.BORDER_BLOCK, Position + new Vector2(width, 0))); // Top
            Blocks.Add(BlockFactory.GetBlock(Types.Block.BORDER_BLOCK, Position + new Vector2(width, height))); // Right
        }
        public override void Lock()
        {
            // Does nothing.
        }

        public override void Unlock()
        {
            Door.State = new LeftUnlockedDoorState(Door);
        }

        public override void Update(GameTime gameTime)
        {
            DoorSprite.Update();
        }
    }
}
