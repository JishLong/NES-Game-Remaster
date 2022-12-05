using Microsoft.Xna.Framework.Graphics;
using Sprint0.GameModes;

namespace Sprint0.Assets
{
    public class FontMappings
    {
        private static FontMappings Instance;

        private readonly GameModeManager GMM;

        private FontMappings()
        {
            GMM = GameModeManager.GetInstance();
        }

        public static FontMappings GetInstance()
        {
            Instance ??= new FontMappings();
            return Instance;
        }

        public SpriteFont SmallFont => GMM.GameMode.FontAssets.SmallFont;
        public SpriteFont MediumFont => GMM.GameMode.FontAssets.MediumFont;
        public SpriteFont LargeFont => GMM.GameMode.FontAssets.LargeFont;
    }
}
