using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Doors.UnlockedDoors
{
    public class UnlockedDoorWallDownSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().RoomSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().UnlockedDoorWallDown;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.UnlockedDoorWallDown;
    }
}
