using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Doors.UnlockdDoorSprites
{
    public class PlayerLocationSprite: AbstractStillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.PlayerLocationSheet;

        protected override Rectangle GetFrame() => Resources.PlayerLocation;
    }
}
