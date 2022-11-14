using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Doors.UnlockdDoorSprites
{
    public class UpSecretDoorWallSprite : AbstractStillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.Level1SpriteSheet;

        protected override Rectangle GetFrame() => Resources.UpSecretDoorWall;
    }
}
