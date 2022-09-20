using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Player
{
    public class Player : IPlayer
    {
        private readonly PlayerStateController stateController;

        // I'm not sure if "provider" is the best name for this class
        private readonly PlayerSpriteProvider spriteProvider;

        public Player(Game1 game)
        {
            stateController = new PlayerStateController();
            spriteProvider = new PlayerSpriteProvider(stateController, game);
        }

        public void Draw(SpriteBatch spriteBatch, int screenWidth, int screenHeight)
        {
            this.spriteProvider.Draw(spriteBatch, screenWidth, screenHeight);
        }

        public void Update()
        {
            stateController.Update();
            spriteProvider.Update();
        }

        public PlayerStateController GetStateController()
        {
            return this.stateController;
        }
    }
}

