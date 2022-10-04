using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;
using Sprint0.Sprites;
using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player.Movement;

namespace Sprint0.Player.SpriteControllers
{
    public class PlayerMovementSpriteController : ISpriteController
    {
        // singleton instance
        private static PlayerMovementSpriteController instance;

        private readonly PlayerStateController stateController;
        private ISprite currentSprite;

        private PlayerMovementSpriteController(PlayerStateController stateController)
        {
            this.stateController = stateController;
            this.currentSprite = PlayerMovingDown.GetInstance();
        }

        public static PlayerMovementSpriteController GetInstance(PlayerStateController stateController)
        {
            if (instance == null)
            {
                instance = new PlayerMovementSpriteController(stateController);
            }

            return instance;
        }

        public void Draw(SpriteBatch sb)
        {
            if (stateController.GetState().IsDamaged())
            {
                currentSprite.Draw(sb, stateController.GetState().GetPosition(), Color.Red);
            }
            else
            {
                currentSprite.Draw(sb, stateController.GetState().GetPosition());
            }
        }

        public void Update()
        {
            var state = stateController.GetState();
            currentSprite.Update();

            if (state.FacingUp())
            {
                currentSprite = PlayerMovingUp.GetInstance();
            }
            else if (state.FacingDown())
            {
                currentSprite = PlayerMovingDown.GetInstance();
            }
            else if (state.FacingRight())
            {
                currentSprite = PlayerMovingRight.GetInstance();
            }
            else
            {
                currentSprite = PlayerMovingLeft.GetInstance();
            }
        }
    }
}
