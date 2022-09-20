using System;
using Sprint0.Player.State;

namespace Sprint0.Player
{
    public class Player : IPlayer
    {
        private PlayerStateController stateController;

        // I'm not sure if "provider" is the best name for this class
        private PlayerSpriteProvider spriteProvider;

        public Player()
        {
            stateController = new PlayerStateController();
            spriteProvider = new PlayerSpriteProvider(stateController);
        }

        public void Draw()
        {
            this.spriteProvider.Draw();
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

