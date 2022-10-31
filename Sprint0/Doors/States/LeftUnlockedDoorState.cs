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
        ISprite Sprite;
        IDoor Door;
        Vector2 Position;
        LevelResources LevelResources;
        public LeftUnlockedDoorState(IDoor door)
        {
            Door = door;
            LevelResources = LevelResources.GetInstance();
            float Height = LevelResources.BlockHeight;
            Position = new Vector2(0,Height * 4 + (Height/2));
            //Position = new Vector2(100,100);
            Sprite = new LeftUnlockedDoorSprite();
        }
        public void Update(GameTime gameTime)
        {
            Sprite.Update();
        }
        public void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }
    }
}
