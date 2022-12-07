using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets.DefaultAssets;

namespace Sprint0.Assets.MinecraftAssets
{
    public class MinecraftFontAssets : DefaultFontAssets
    {
        public override void LoadContent(ContentManager c)
        {
            SmallFont = c.Load<SpriteFont>("Fonts/Minecraft/smallFont");
            MediumFont = c.Load<SpriteFont>("Fonts/Minecraft/mediumFont");
            LargeFont = c.Load<SpriteFont>("Fonts/Minecraft/largeFont");
        }
    }
}
