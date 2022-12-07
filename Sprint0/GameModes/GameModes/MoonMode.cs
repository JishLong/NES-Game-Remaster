using Sprint0.Assets;

namespace Sprint0.GameModes.GameModes
{
    public class MoonMode : IGameMode
    {
        public Types.GameMode Type => Types.GameMode.MOONMODE;

        public IImageAssets ImageAssets => AssetManager.MoonImageAssets;

        public IAudioAssets AudioAssets => AssetManager.MoonAudioAssets;

        public IFontAssets FontAssets => AssetManager.MoonFontAssets;
    }
}
