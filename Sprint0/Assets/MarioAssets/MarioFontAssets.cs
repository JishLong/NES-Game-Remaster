using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets.DefaultAssets;

namespace Sprint0.Assets.MarioAssets
{
    public class MarioFontAssets : DefaultFontAssets
    {
        public override void LoadContent(ContentManager c)
        {
            SmallFont = c.Load<SpriteFont>("Fonts/Mario/smallFont");
            MediumFont = c.Load<SpriteFont>("Fonts/Mario/mediumFont");
            LargeFont = c.Load<SpriteFont>("Fonts/Mario/largeFont");
        }
    }
}
