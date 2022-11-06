using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Levels.Utils;
using Sprint0.Sprites;
using Sprint0.Sprites.Doors;
using static Sprint0.Utils;

namespace Sprint0.Doors.States
{
    public class DownUnlockedDoorState: AbstractTraversableDoorState
    {
        IDoor Door;
        LevelResources LevelResources;
        public DownUnlockedDoorState(IDoor door)
        {
            // Set context
            Door = door;
            LevelResources = LevelResources.GetInstance();
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = new Vector2(Width * 7, Height * 10);
            DoorWayOffset = new Vector2(0,-Height);

            // Create sprites
            DoorWaySprite = new DownUnlockedDoorWaySprite();
            DoorWallSprite = new DownUnlockedDoorWallSprite();
        }
        public override void Update(GameTime gameTime)
        {
            DoorWaySprite.Update();
            DoorWallSprite.Update();
        }
    }
}
