﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Enemies
{
    public class RedGoriyaDownSprite: AnimatedSprite
    {
        public RedGoriyaDownSprite() : base(2, 16)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.RedGoriyaDown;
    }
}
