﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Levels.Utils;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using static Sprint0.Utils;

namespace Sprint0.Doors.States
{
    // "Impassable" doors are in a state in which the player cannot pass through them (e.g. a locked door.)
    public abstract class AbstractImpassableDoorState: IDoorState
    {
        protected ISprite DoorSprite;

        protected Vector2 Position;

        // Each room may have several blocks.
        protected List<IBlock> Blocks;

        // Room needs to know which direction to transition in.
        public Types.RoomTransition TransitionDirection;

        // Utilities and Factories
        protected LevelResources LevelResources = LevelResources.GetInstance();
        protected BlockFactory BlockFactory = BlockFactory.GetInstance();

        public abstract void Update(GameTime gameTime);

        public List<IBlock> GetBlocks()
        {
            return Blocks;
        }

        public Types.RoomTransition GetTransitionDirection()
        {
            return TransitionDirection;
        }

        public void Draw(SpriteBatch sb)
        {
            DoorSprite.Draw(sb, Position, Color.White, DoorWayLayerDepth);
        }
    }
}