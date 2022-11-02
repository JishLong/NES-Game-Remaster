using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Levels.Utils;
using Sprint0.Sprites;
using Sprint0.Sprites.Doors;
using static Sprint0.Utils;

namespace Sprint0.Doors.States
{
    public class LeftUnlockedDoorState : IDoorState
    {
        ISprite DoorWaySprite;
        ISprite DoorWallSprite;
        IDoor Door;
        Vector2 Position;
        Vector2 DoorWayOffset;
        LevelResources LevelResources;
        public LeftUnlockedDoorState(IDoor door)
        {
            // Set context
            Door = door;
            LevelResources = LevelResources.GetInstance();
            float Height = LevelResources.BlockHeight;
            float Width = LevelResources.BlockWidth;

            // Used mostly for drawing
            Position = new Vector2(0,Height * 4 + (Height/2));
            DoorWayOffset = new Vector2(Width,0);

            // Create sprites
            DoorWaySprite = new LeftUnlockedDoorWaySprite();
            DoorWallSprite = new LeftUnlockedDoorWallSprite();
        }
        public void Update(GameTime gameTime)
        {
            DoorWaySprite.Update();
            DoorWallSprite.Update();
        }
        public void Draw(SpriteBatch sb)
        { 
            DoorWaySprite.Draw(sb, Position+DoorWayOffset,Color.White, 1);
            DoorWallSprite.Draw(sb, Position, Color.White, 0);
        }
    }
}
