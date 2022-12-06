using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Assets.DefaultAssets
{
    public class DefaultFontAssets : IFontAssets
    {
        public virtual void LoadContent(ContentManager c)
        {
            SmallFont = c.Load<SpriteFont>("Fonts/Default/smallFont");
            MediumFont = c.Load<SpriteFont>("Fonts/Default/mediumFont");
            LargeFont = c.Load<SpriteFont>("Fonts/Default/largeFont");
        }

        public SpriteFont SmallFont { get; protected set; }
        public SpriteFont MediumFont { get; protected set; }
        public SpriteFont LargeFont { get; protected set; }
    }
}
