using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    public interface ISprite
    {
        void Update();

        void Draw(SpriteBatch sb, int x, int y, int w, int h);
    }
}
