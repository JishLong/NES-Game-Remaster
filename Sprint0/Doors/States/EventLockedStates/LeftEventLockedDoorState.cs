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
            LevelResources = LevelResources.GetInstance();
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = new Vector2(0, Height * 4 + Height / 2);

            // Create sprites
            DoorSprite = new LeftEventLockedDoorSprite();

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
            Door.State = new LeftUnlockedDoorState(Door);
        }

        private void CreateTriggers(float height, float width)
        {
            Blocks.Add(BlockFactory.GetBlock(Types.Block.ROOM_TRANSITION_BLOCK, Position + new Vector2(0, height / 2)));
        }
        public override void Update(GameTime gameTime)
        {
            DoorSprite.Update();
        }
    }
}
