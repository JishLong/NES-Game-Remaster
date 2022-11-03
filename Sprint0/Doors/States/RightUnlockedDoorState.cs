using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Levels.Utils;
using Sprint0.Sprites;
using Sprint0.Sprites.Doors;
using static Sprint0.Utils;

namespace Sprint0.Doors.States
{
    public class RightUnlockedDoorState: AbstractDoorState
    {
        IDoor Door;
        LevelResources LevelResources;
        public RightUnlockedDoorState(IDoor door)
        {
            // Set context
            Door = door;
            LevelResources = LevelResources.GetInstance();
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = new Vector2(Width * 15,Height * 4 + (Height/2));
            DoorWayOffset = new Vector2(-Width,0);

            // Create sprites
            DoorWaySprite = new RightUnlockedDoorWaySprite();
            DoorWallSprite = new RightUnlockedDoorWallSprite();
        }
        public override void Update(GameTime gameTime)
        {
            DoorWaySprite.Update();
            DoorWallSprite.Update();
        }
    }
}
