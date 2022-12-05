using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Assets.MarioAssets
{
    public class MarioFontAssets : IFontAssets
    {
        public SpriteFont SmallFont { get; private set; }
        public SpriteFont MediumFont { get; private set; }
        public SpriteFont LargeFont { get; private set; }

        public void LoadContent(ContentManager c)
        {
            SmallFont = c.Load<SpriteFont>("Fonts/Default/smallFont");
            MediumFont = c.Load<SpriteFont>("Fonts/Default/mediumFont");
            LargeFont = c.Load<SpriteFont>("Fonts/Default/largeFont");
        }
    }
}
