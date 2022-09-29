using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.SpriteControllers;
using Sprint0.Player.State;

namespace Sprint0.Player
{
    public class PlayerMasterSpriteController : ISpriteController
    {
        // singleton instance
        private static PlayerMasterSpriteController instance;

        private readonly PlayerStateController stateController;
        private ISpriteController currentController;

        public static PlayerMasterSpriteController GetInstance(PlayerStateController stateController)
        {
            if (instance == null)
            {
                instance = new PlayerMasterSpriteController(stateController);
            }

            return instance;
        }

        private PlayerMasterSpriteController(PlayerStateController stateController)
        {
            this.stateController = stateController;
            this.currentController = PlayerStationarySpriteController.GetInstance(stateController);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentController.Draw(spriteBatch);
        }

        public void Update()
        {
            var state = stateController.GetState();
            currentController.Update();

            if (state.IsMoving())
            {
                currentController = PlayerMovementSpriteController.GetInstance(stateController);
            }
            else
            {
                currentController = PlayerStationarySpriteController.GetInstance(stateController);
            }            

            if (state.IsAttacking())
            {
                currentController = PlayerAttackingSpriteController.GetInstance(stateController);
            }
        }

        public void Reset()
        {
            // not a useful method for this controller
        }
    }
}
