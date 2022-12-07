using Microsoft.Xna.Framework.Content;
using Sprint0.Assets.DefaultAssets;
using Sprint0.Assets.GoombaAssets;
using Sprint0.Assets.MarioAssets;
using Sprint0.Assets.MinecraftAssets;

namespace Sprint0.Assets
{
    public static class AssetManager
    {
        public static IImageAssets DefaultImageAssets { get; private set; }
        public static IAudioAssets DefaultAudioAssets { get; private set; }
        public static IFontAssets DefaultFontAssets { get; private set; }

        public static IImageAssets MoonImageAssets { get; private set; }
        public static IAudioAssets MoonAudioAssets { get; private set; }
        public static IFontAssets MoonFontAssets { get; private set; }

        public static IImageAssets MinecraftImageAssets { get; private set; }
        public static IAudioAssets MinecraftAudioAssets { get; private set; }
        public static IFontAssets MinecraftFontAssets { get; private set; }

        public static IImageAssets MarioImageAssets { get; private set; }
        public static IAudioAssets MarioAudioAssets { get; private set; }
        public static IFontAssets MarioFontAssets { get; private set; }

        public static IImageAssets GoombaImageAssets { get; private set; }
        public static IAudioAssets GoombaAudioAssets { get; private set; }
        public static IFontAssets GoombaFontAssets { get; private set; }

        public static void LoadContent(ContentManager c) 
        {
            // Initialize assets so we don't have a zillion rectangles being created every second
            DefaultImageAssets = new DefaultImageAssets();
            DefaultAudioAssets = new DefaultAudioAssets();
            DefaultFontAssets = new DefaultFontAssets();

            MoonImageAssets = new MoonImageAssets();
            MoonAudioAssets = new MoonAudioAssets();
            MoonFontAssets = new MoonFontAssets();

            MinecraftImageAssets = new MinecraftImageAssets();
            MinecraftAudioAssets = new MinecraftAudioAssets();
            MinecraftFontAssets = new MinecraftFontAssets();

            MarioImageAssets = new MarioImageAssets();
            MarioAudioAssets = new MarioAudioAssets();
            MarioFontAssets = new MarioFontAssets();

            GoombaImageAssets = new GoombaImageAssets();
            GoombaAudioAssets = new GoombaAudioAssets();
            GoombaFontAssets = new GoombaFontAssets();

            /* Load the assets
             * 
             * DEV NOTE: we could add something that would sort of load/deload certain assets as it sees fit (kinda like a garbage collector),
             * but for the scope of this project I don't think it's very necessary, plus there isn't any performance issues with loading only
             * these 5 sets of assets. However, for a project with an unknown (unlimited) amount of assets, this would be nice.
             */
            DefaultImageAssets.LoadContent(c);
            DefaultAudioAssets.LoadContent(c);
            DefaultFontAssets.LoadContent(c);

            MoonImageAssets.LoadContent(c);
            MoonAudioAssets.LoadContent(c);
            MoonFontAssets.LoadContent(c);

            MinecraftImageAssets.LoadContent(c);
            MinecraftAudioAssets.LoadContent(c);
            MinecraftFontAssets.LoadContent(c);

            MarioImageAssets.LoadContent(c);
            MarioAudioAssets.LoadContent(c);
            MarioFontAssets.LoadContent(c);

            GoombaImageAssets.LoadContent(c);
            GoombaAudioAssets.LoadContent(c);
            GoombaFontAssets.LoadContent(c);
        }
    }
}
