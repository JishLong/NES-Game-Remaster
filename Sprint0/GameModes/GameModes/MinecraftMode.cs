using Sprint0.Assets;

namespace Sprint0.GameModes.GameModes
{
    internal class MinecraftMode : IGameMode
    {
        public Types.GameMode Type => Types.GameMode.MINECRAFTMODE;

        public IImageAssets ImageAssets => AssetManager.MinecraftImageAssets;

        public IAudioAssets AudioAssets => AssetManager.MinecraftAudioAssets;

        public IFontAssets FontAssets => AssetManager.MinecraftFontAssets;
    }
}
