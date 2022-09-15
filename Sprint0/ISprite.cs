using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    public interface ISprite
    {
        void Update(int screenW, int screenH);

        void Draw(SpriteBatch sb, int screenW, int screenH);
    }
}
