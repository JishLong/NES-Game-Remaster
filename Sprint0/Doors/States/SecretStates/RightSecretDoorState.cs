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
    public class RightSecretDoorState : AbstractTraversableDoorState
    {
        public RightSecretDoorState(Door door)
        {
            // Set context
            Door = door;
            LevelResources = LevelResources.GetInstance();
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = LevelResources.RightDoorPosition + new Vector2(Width,0);
            DoorWayOffset = new Vector2(-Width, 0);

            // Create sprites
            DoorWaySprite = new RightSecretDoorWaySprite();
            DoorWallSprite = new RightSecretDoorWallSprite();

            // Triggers
            Blocks = new List<IBlock>();
            CreateTriggers(Height, Width);
        }
        private void CreateTriggers(float height, float width)
        {
            Blocks.Add(BlockFactory.GetBlock(Types.Block.ROOM_TRANSITION_BLOCK, Position + new Vector2(0, height / 2)));
        }
        public override void Lock()
        {
            throw new System.NotImplementedException();
        }
        public override void Unlock()
        {
            // Do nothing.
        }
        public override void Update(GameTime gameTime)
        {
            DoorWaySprite.Update();
            DoorWallSprite.Update();
        }
    }
}
