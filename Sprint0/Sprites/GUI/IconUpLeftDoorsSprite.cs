using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Doors.UnlockdDoorSprites
{
    public class IconUpLeftDoorsSprite : AbstractStillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.GuiElementsSpriteSheet;

        protected override Rectangle GetFrame() => Resources.MapIconUpLeftDoors;
    }
}
