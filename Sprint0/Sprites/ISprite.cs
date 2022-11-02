using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    public interface ISprite
    {
        void Update();

        void Draw(SpriteBatch sb, Vector2 position);

        void Draw(SpriteBatch sb, Vector2 position, Color color, float layer);
        void Draw(SpriteBatch sb, Vector2 position, Color color);

        Rectangle GetDrawbox(Vector2 position);

        int GetAnimationTime();
    }
}
