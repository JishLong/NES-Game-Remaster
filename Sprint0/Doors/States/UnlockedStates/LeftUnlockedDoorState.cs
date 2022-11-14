using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Levels.Utils;
using Sprint0.Sprites;
using Sprint0.Sprites.Doors.UnlockdDoorSprites;
using System.Collections.Generic;
using static Sprint0.Utils;

namespace Sprint0.Doors.States.UnlockedStates
{
    public class LeftUnlockedDoorState : AbstractTraversableDoorState
    {
        public LeftUnlockedDoorState(Door door)
        {
            // Set context
            Door = door;
            LevelResources = LevelResources.GetInstance();
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = LevelResources.LeftDoorPosition;
            DoorWayOffset = new Vector2(Width, 0);

            // Create sprites
            DoorWaySprite = new LeftUnlockedDoorWaySprite();
            DoorWallSprite = new LeftUnlockedDoorWallSprite();

            // Create triggers
            Blocks = new List<IBlock>();
            CreateTriggers(Height, Width);
        }
        public override void Lock()
        {
            throw new System.NotImplementedException();
        }

        public override void Unlock()
        {
            // Does nothing.
        }

        private void CreateTriggers(float height, float width)
        {
            Blocks.Add(BlockFactory.GetBlock(Types.Block.ROOM_TRANSITION_BLOCK, Position + new Vector2(0, height / 2)));
        }
        public override void Update(GameTime gameTime)
        {
            DoorWaySprite.Update();
            DoorWallSprite.Update();
        }
    }
}
