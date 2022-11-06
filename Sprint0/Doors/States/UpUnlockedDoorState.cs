﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Levels.Utils;
using Sprint0.Sprites;
using Sprint0.Sprites.Doors;
using System.Collections.Generic;
using static Sprint0.Utils;

namespace Sprint0.Doors.States
{
    public class UpUnlockedDoorState: AbstractTraversableDoorState
    {
        IDoor Door;
        LevelResources LevelResources;
        BlockFactory BlockFactory;
        public UpUnlockedDoorState(IDoor door)
        {
            // Set context
            Door = door;
            LevelResources = LevelResources.GetInstance();
            BlockFactory = BlockFactory.GetInstance();
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = new Vector2(Width * 7,0);
            DoorWayOffset = new Vector2(0,Height);

            // Create sprites
            DoorWaySprite = new UpUnlockedDoorWaySprite();
            DoorWallSprite = new UpUnlockedDoorWallSprite();

            // Blocks
            Blocks = new List<IBlock>();
            CreateBlocks(Height, Width);
        }

        private void CreateBlocks(float height, float width)
        {
            Blocks.Add(BlockFactory.GetBlock(Types.Block.LEFT_DOOR_WAY_BLOCK, Position)); // Top left
            Blocks.Add(BlockFactory.GetBlock(Types.Block.LEFT_DOOR_WAY_BLOCK, Position + new Vector2(0, height))); // Bottom left
            Blocks.Add(BlockFactory.GetBlock(Types.Block.RIGHT_DOOR_WAY_BLOCK, Position + new Vector2(width, 0))); // Top right
            Blocks.Add(BlockFactory.GetBlock(Types.Block.RIGHT_DOOR_WAY_BLOCK, Position + new Vector2(width, height))); // Bottom right
        }
        public override void Update(GameTime gameTime)
        {
            DoorWaySprite.Update();
            DoorWallSprite.Update();

            foreach(IBlock block in Blocks)
            {
                block.Update();
            }
        }
    }
}
