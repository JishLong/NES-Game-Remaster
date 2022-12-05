using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    public interface ISprite
    {
        void Draw(SpriteBatch sb, Vector2 position, Color color, float layer);

        int GetAnimationTime();

        Rectangle GetHitbox(Vector2 position);

        void Update();
    }
}
