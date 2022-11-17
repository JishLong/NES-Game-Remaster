using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.GameStates
{
    public interface IGameState
    {
        void Draw(SpriteBatch sb);

        void Update(GameTime gameTime);

        void HandleClientInput(dynamic input, string id);
    }
}
