﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Sprites;
using Sprint0.Sprites.Doors;
using System.Collections.Generic;
using static Sprint0.Utils;

namespace Sprint0.Doors.States.LockedStates
{
    public class DownLockedDoorState : AbstractTraversableDoorState
    {
        public DownLockedDoorState(Door door)
        {
            // Set context
            Door = door;
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = new Vector2(Width * 7, Height * 9);

            // Create sprite
            //DoorSprite = new DownWallDoorSprite();

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
            //DoorSprite.Update();
        }
    }
}