﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Player
{
    public class PlayerHoldItemSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().PlayerSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().PlayerHoldItem;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.PlayerHoldItem;
    }
}
