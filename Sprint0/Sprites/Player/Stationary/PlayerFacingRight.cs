﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Stationary
{
    public class PlayerFacingRight : AbstractStillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFrame() => Resources.LinkSideways;
    }
}
