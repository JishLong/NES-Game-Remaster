﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace Sprint0.Items
{
    public class AbstractItem : IItem
    {
        // Sprite
        protected ISprite Sprite;

        // Coordinates and dimensions
        protected Vector2 Position;
        protected int Width, Height;

        protected AbstractItem(Vector2 position)
        {
            Position = position;

            Width = 64;
            Height = 64;
        }

        public void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, (int)Position.X, (int)Position.Y, Width, Height);
        }

        public void Update()
        {
            Sprite.Update();
        }
    }
}
