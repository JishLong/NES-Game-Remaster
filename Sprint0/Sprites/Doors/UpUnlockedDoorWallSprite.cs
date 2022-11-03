using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Doors
{
    public class UpUnlockedDoorWallSprite : AbstractStillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.Level1SpriteSheet;

        protected override Rectangle GetFrame() => Resources.UpUnlockedDoorWall;
    }
}
