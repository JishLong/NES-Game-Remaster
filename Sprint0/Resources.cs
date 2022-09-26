using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    public static class Resources
    {
        public static Texture2D mario;

        public static Texture2D BossEnemiesSpriteSheet;
        public static Texture2D NpcsSpriteSheet;
        public static Texture2D LinkItemsSpriteSheet;

        public static SpriteFont creditsFont;

        public static void LoadContent(ContentManager c) 
        {
            BossEnemiesSpriteSheet = c.Load<Texture2D>("BossEnemies");
            NpcsSpriteSheet = c.Load<Texture2D>("Npcs");
            LinkItemsSpriteSheet = c.Load<Texture2D>("Link+items");

            creditsFont = c.Load<SpriteFont>("credits");
        }
    }
}
