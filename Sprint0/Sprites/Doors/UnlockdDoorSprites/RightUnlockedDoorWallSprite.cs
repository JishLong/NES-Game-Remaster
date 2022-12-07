using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Doors.UnlockdDoorSprites
{
    public class RightUnlockedDoorWallSprite : AbstractStillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.LevelSpriteSheet;

        protected override Rectangle GetFrame() => Resources.RightUnlockedDoorWall;
    }
}
