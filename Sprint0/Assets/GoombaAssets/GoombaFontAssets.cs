using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets.DefaultAssets;

namespace Sprint0.Assets.GoombaAssets
{
    public class GoombaFontAssets : DefaultFontAssets
    {
        public override void LoadContent(ContentManager c)
        {
            SmallFont = c.Load<SpriteFont>("Fonts/Goomba/smallFont");
            MediumFont = c.Load<SpriteFont>("Fonts/Goomba/mediumFont");
            LargeFont = c.Load<SpriteFont>("Fonts/Goomba/largeFont");
        }
    }
}
