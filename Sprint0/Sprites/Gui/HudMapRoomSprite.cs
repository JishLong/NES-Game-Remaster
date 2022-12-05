﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Gui
{ 
    public class HUDMapRoomSprite: AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().GuiElementsSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().HudMapRoom;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.HudMapRoom;
    }
}
