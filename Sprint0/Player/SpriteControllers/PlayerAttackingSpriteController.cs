using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Player.SpriteControllers
{
    public class PlayerAttackingSpriteController : ISpriteController
    {
        // singleton instance
        private static PlayerAttackingSpriteController instance;

        private ISpriteController currentController;

        private PlayerAttackingSpriteController(PlayerStateController stateController)
        {
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
    }
}
