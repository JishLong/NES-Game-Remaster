using Microsoft.Xna.Framework.Content;
using Sprint0.Assets.DefaultAssets;
using Sprint0.Assets.MinecraftAssets;

namespace Sprint0.Assets
{
    public static class AssetManager
    {
        public static IImageAssets DefaultImageAssets { get; private set; }
        public static IAudioAssets DefaultAudioAssets { get; private set; }
        public static IFontAssets DefaultFontAssets { get; private set; }
        public static IImageAssets MinecraftImageAssets { get; private set; }
        public static IAudioAssets MinecraftAudioAssets { get; private set; }
        public static IFontAssets MinecraftFontAssets { get; private set; }

        public static void LoadContent(ContentManager c) 
        {
            // Initialize assets so we don't have a zillion rectangles being created every second
            DefaultImageAssets = new DefaultImageAssets();
            DefaultAudioAssets = new DefaultAudioAssets();
            DefaultFontAssets = new DefaultFontAssets();
            MinecraftImageAssets = new MinecraftImageAssets();
            MinecraftAudioAssets = new MinecraftAudioAssets();
            MinecraftFontAssets = new MinecraftFontAssets();
            
            // Load the assets
            DefaultImageAssets.LoadContent(c);
            DefaultAudioAssets.LoadContent(c);
            DefaultFontAssets.LoadContent(c);
            MinecraftImageAssets.LoadContent(c);
            MinecraftAudioAssets.LoadContent(c);
            MinecraftFontAssets.LoadContent(c);
        }
    }
}
