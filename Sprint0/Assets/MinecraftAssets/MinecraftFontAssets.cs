using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Assets.MinecraftAssets
{
    public class MinecraftFontAssets : IFontAssets
    {
        public SpriteFont SmallFont { get; private set; }
        public SpriteFont MediumFont { get; private set; }
        public SpriteFont LargeFont { get; private set; }

        public void LoadContent(ContentManager c)
        {
            SmallFont = c.Load<SpriteFont>("Fonts/Minecraft/smallFont");
            MediumFont = c.Load<SpriteFont>("Fonts/Minecraft/mediumFont");
            LargeFont = c.Load<SpriteFont>("Fonts/Minecraft/largeFont");
        }
    }
}
