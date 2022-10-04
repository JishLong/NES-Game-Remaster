using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Player.SpriteControllers
{
    public interface ISpriteController
    {
        void Update();
        void Draw(SpriteBatch sb);
    }
}
