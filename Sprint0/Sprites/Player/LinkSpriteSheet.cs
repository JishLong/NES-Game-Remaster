using System;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    public static class LinkSpriteSheet
    {
        private static Texture2D spriteSheet;

        public static void Init(Game1 game)
        {
            spriteSheet = game.Content.Load<Texture2D>("Link+Items");
        }

        public static Texture2D GetSpriteSheet()
        {
            if (spriteSheet == null)
            {
                throw new InvalidOperationException("Sprite sheet must be initialized before use");
            }
            return spriteSheet;
        }
    }
}

