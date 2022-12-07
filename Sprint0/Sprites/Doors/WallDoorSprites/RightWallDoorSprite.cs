using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Doors.WallDoorSprites
{
    public class RightWallDoorSprite : AbstractStillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.LevelSpriteSheet;

        protected override Rectangle GetFrame() => Resources.RightWallDoor;
    }
}
