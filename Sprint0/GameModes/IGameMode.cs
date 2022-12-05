using Sprint0.Assets;

namespace Sprint0.GameModes
{
    public interface IGameMode
    {
        Types.GameMode Type { get; }

        IImageAssets ImageAssets { get; }

        IAudioAssets AudioAssets { get; }
      
        IFontAssets FontAssets { get; }
    }
}
