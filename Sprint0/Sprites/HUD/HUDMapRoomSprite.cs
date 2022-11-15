using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Doors.UnlockdDoorSprites
{
    public class HUDMapRoomSprite: AbstractStillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.HUDMapRoomSheet;

        protected override Rectangle GetFrame() => Resources.HUDMapRoom;
    }
}
