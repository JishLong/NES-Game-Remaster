using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Assets
{
    public interface IFontAssets
    {
        void LoadContent(ContentManager c);

        SpriteFont SmallFont { get; }
        SpriteFont MediumFont { get; }
        SpriteFont LargeFont { get; }
    }
}
