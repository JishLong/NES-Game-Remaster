using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Sprites;
using Sprint0.Sprites.Doors.WallDoorSprites;
using System.Collections.Generic;
using static Sprint0.Utils;

namespace Sprint0.Doors.States.WallStates
{
    public class LeftWallDoorState : AbstractImpassableDoorState
    {
        public LeftWallDoorState(Door door)
        {
            // Set context
            Door = door;
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = new Vector2(0, Height * 4 + Height / 2);

            // Create sprite
            DoorSprite = new LeftWallDoorSprite();

            // Blocks
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
            // Switch to secret passage state.
        }
        public override void Update(GameTime gameTime)
        {
            DoorSprite.Update();
        }
    }
}
