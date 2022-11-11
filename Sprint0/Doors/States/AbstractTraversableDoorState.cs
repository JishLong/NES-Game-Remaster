using Microsoft.Xna.Framework;
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
    // "Traversable" doors are in a state in which the player can pass through them (e.g. an unlocked or secret door.)
    public abstract class AbstractTraversableDoorState : IDoorState
    {
        protected ISprite DoorWaySprite;
        protected ISprite DoorWallSprite;

        // Doorways are drawn relative to the 'Door Wall', so we use a vector to offset them.
        protected Vector2 DoorWayOffset;

        protected Vector2 Position;

        // Each door may have several blocks.
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
            DoorWallSprite.Draw(sb, Position, Color.White, DoorWallLayerDepth);
            DoorWaySprite.Draw(sb, Position + DoorWayOffset, Color.White, DoorWayLayerDepth);
        }

        public void Lock()
        {
            throw new NotImplementedException();
        }

        public void Unlock()
        {
            throw new NotImplementedException();
        }
    }
}
