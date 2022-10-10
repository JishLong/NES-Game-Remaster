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
            //How can we differentiate when to call sword attack and arrow attack controller???
            //this.currentController = PlayerSwordAttackingSpriteController.GetInstance(stateController);

            this.currentController = PlayerArrowAttackingSpriteController.GetInstance(stateController);
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
