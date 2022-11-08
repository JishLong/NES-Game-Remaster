﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Blocks
{
    public class BlueBorderSprite: AbstractStillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.Level1SpriteSheet;

        protected override Rectangle GetFrame() => Resources.Level1Border;
    }
}
