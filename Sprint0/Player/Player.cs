using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Player
{
    public class Player : IPlayer
    {
        private readonly PlayerStateController stateController;

        // I'm not sure if "provider" is the best name for this class
        private readonly PlayerSpriteController spriteProvider;

        public Player(Game1 game)
        {
            stateController = new PlayerStateController();
            spriteProvider = new PlayerSpriteController(stateController, game);
        }

        public void Draw(SpriteBatch spriteBatch, int screenWidth, int screenHeight)
        {
            this.spriteProvider.Draw(spriteBatch, screenWidth, screenHeight);
        }

        public void Update()
        {
            // NOTE: spriteProvider MUST be updated before stateController
            spriteProvider.Update();
            stateController.Update();
        }

        public PlayerStateController GetStateController()
        {
            return this.stateController;
        }
    }
}

