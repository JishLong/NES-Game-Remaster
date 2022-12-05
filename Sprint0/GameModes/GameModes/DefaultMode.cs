using Sprint0.Assets;

namespace Sprint0.GameModes.GameModes
{
    public class DefaultMode : IGameMode
    {
        public Types.GameMode Type => Types.GameMode.DEFAULTMODE;

        public IImageAssets ImageAssets => AssetManager.DefaultImageAssets;

        public IAudioAssets AudioAssets => AssetManager.DefaultAudioAssets;

        public IFontAssets FontAssets => AssetManager.DefaultFontAssets;
    }
}
