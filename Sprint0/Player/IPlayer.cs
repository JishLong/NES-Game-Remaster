using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Player
{
    public interface IPlayer
    {
        public void Update();

        public void Draw(SpriteBatch spriteBatch, int screenWidth, int screenHeight);

        public PlayerStateController GetStateController();
    }
}
