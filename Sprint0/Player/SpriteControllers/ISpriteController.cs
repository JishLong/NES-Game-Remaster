using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Player.SpriteControllers
{
    public interface ISpriteController
    {
        void Update();
        void Draw(SpriteBatch sb);

        // used to reset animation frames for animated sprites
        void Reset();
    }
}

