﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class DodongoLeftSprite : AbstractAnimatedSprite
    {
        public DodongoLeftSprite() : base(2, 16)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.DodongoSide;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            DrawFlippedHorz(spriteBatch, position, color);
        }
    }
}