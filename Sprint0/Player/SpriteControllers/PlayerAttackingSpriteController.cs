using System;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;
using Sprint0.Sprites.Player;

namespace Sprint0.Player.SpriteControllers
{
    public class PlayerAttackingSpriteController : ISpriteController
    {
        // singleton instance
        private static PlayerAttackingSpriteController instance;

        private readonly PlayerStateController stateController;
        private ISpriteController currentController;

        private PlayerAttackingSpriteController(PlayerStateController stateController)
        {
            this.stateController = stateController;
            this.currentController = PlayerSwordAttackingSpriteController.GetInstance(stateController);
        }

        public static PlayerAttackingSpriteController GetInstance(PlayerStateController stateController)
        {
            if (instance == null)
            {
                instance = new PlayerAttackingSpriteController(stateController);
            }

            return instance;
        }

        public void Update()
        {
            currentController.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentController.Draw(spriteBatch);
        }

        public void Reset()
        {

        }
    }
}

