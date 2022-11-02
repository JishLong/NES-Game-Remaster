using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using static Sprint0.Utils;

namespace Sprint0.Doors.States
{
    public abstract class AbstractDoorState : IDoorState
    {
        protected ISprite DoorWaySprite;
        protected ISprite DoorWallSprite;

        // Doorways are drawn relative to the 'Door Wall', so we use a vector to offset them.
        protected Vector2 DoorWayOffset;

        protected Vector2 Position;

        // Room needs to know which direction to transition in.
        public Types.RoomTransition TransitionDirection;

        public Types.RoomTransition GetTransitionDirection()
        {
            return TransitionDirection;
        }

        public abstract void Update(GameTime gameTime);
        
        
        public void Draw(SpriteBatch sb)
        {
            DoorWallSprite.Draw(sb, Position, Color.White, DoorWallLayerDepth);
            DoorWaySprite.Draw(sb, Position + DoorWayOffset, Color.White, DoorWayLayerDepth);
        }
    }
}
