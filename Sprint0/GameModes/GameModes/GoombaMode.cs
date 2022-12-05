using Sprint0.Assets;

namespace Sprint0.GameModes.GameModes
{
    public class GoombaMode : IGameMode
    {
        public Types.GameMode Type => Types.GameMode.GOOMBAMODE;

        public IImageAssets ImageAssets => AssetManager.GoombaImageAssets;

        public IAudioAssets AudioAssets => AssetManager.GoombaAudioAssets;

        public IFontAssets FontAssets => AssetManager.GoombaFontAssets;
    }
}
