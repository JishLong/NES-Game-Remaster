﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Characters.Bosses
{
    public class DodongoDownSprite : AnimatedSprite
    {
        public DodongoDownSprite() : base(2, 16)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.DodongoDown;
    }
}