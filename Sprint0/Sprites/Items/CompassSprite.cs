﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player
{
    public class CompassSprite : ISprite
    {
        public CompassSprite()
        {
            
        }

        public void Draw(SpriteBatch sb, int x, int y, int w, int h)
        {
            Texture2D SpriteSheet = Resources.stillItemsSheet;
            Rectangle SheetPosition = Resources.compass;

            sb.Draw(SpriteSheet, new Rectangle(x, y, w, h), SheetPosition, Color.White);
        }

        public void Update()
        {
            // Nothing here!
        }
    }
}

