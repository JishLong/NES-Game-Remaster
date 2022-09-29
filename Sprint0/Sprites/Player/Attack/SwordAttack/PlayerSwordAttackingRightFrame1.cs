﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player
{
    public class PlayerSwordAttackingRightFrame1 : ISprite
    {
        private readonly int spriteScale = 3;
        private readonly Vector2 position;

        public PlayerSwordAttackingRightFrame1(Vector2 position)
        {
            this.position = position;
        }

        public void Draw(SpriteBatch sb, int x, int y, int w, int h)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(111, 77, 27, 16);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, spriteScale * 27, spriteScale * 16);

            sb.Draw(LinkSpriteSheet.GetSpriteSheet(), destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}

