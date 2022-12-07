using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Doors.UnlockedDoors
{
    public class UnlockedDoorWallRightSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().RoomSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().UnlockedDoorWallRight;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.UnlockedDoorWallRight;
    }
}
