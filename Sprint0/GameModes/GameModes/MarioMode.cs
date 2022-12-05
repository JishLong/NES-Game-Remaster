using Sprint0.Assets;

namespace Sprint0.GameModes.GameModes
{
    public class MarioMode : IGameMode
    {
        public Types.GameMode Type => Types.GameMode.MARIOMODE;

        public IImageAssets ImageAssets => AssetManager.MarioImageAssets;

        public IAudioAssets AudioAssets => AssetManager.MarioAudioAssets;

        public IFontAssets FontAssets => AssetManager.MarioFontAssets;
    }
}
