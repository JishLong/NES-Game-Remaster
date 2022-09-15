using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    public static class Resources
    {
        public static Texture2D mario;

        public static SpriteFont creditsFont;

        public static void LoadContent(ContentManager c) 
        {
            mario = c.Load<Texture2D>("mario");

            creditsFont = c.Load<SpriteFont>("credits");
        }
    }
}
