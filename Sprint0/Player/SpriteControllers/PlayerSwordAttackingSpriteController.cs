using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;
using Sprint0.Sprites;
using Sprint0.Sprites.Player.Attack.SwordAttack;
using Microsoft.Xna.Framework;

namespace Sprint0.Player.SpriteControllers
{
    public class PlayerSwordAttackingSpriteController : ISpriteController
    {
        // singleton instance
        private static PlayerSwordAttackingSpriteController instance;

        private readonly PlayerStateController stateController;
        private ISprite currentSprite;

        public static PlayerSwordAttackingSpriteController GetInstance(PlayerStateController stateController)
        {
            if (instance == null)
            {
                instance = new PlayerSwordAttackingSpriteController(stateController);
            }

            return instance;
        }

        private PlayerSwordAttackingSpriteController(PlayerStateController stateController)
        {
            this.stateController = stateController;
            currentSprite = PlayerSwordAttackDown.GetInstance();
        }

        public void Update()
        {
            var state = stateController.GetState();
            currentSprite.Update();

            if (state.FacingDown())
            {
                currentSprite = PlayerSwordAttackDown.GetInstance();
            }
            else if (state.FacingRight())
            {
                currentSprite = PlayerSwordAttackRight.GetInstance();
            }
            else if (state.FacingUp())
            {
                currentSprite = PlayerSwordAttackUp.GetInstance();
            }
            // when facing left
            else
            {
                currentSprite = PlayerSwordAttackLeft.GetInstance();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (stateController.GetState().IsDamaged())
            {
                currentSprite.Draw(spriteBatch, stateController.GetState().GetPosition(), Color.Red);
            }
            else
            {
                currentSprite.Draw(spriteBatch, stateController.GetState().GetPosition());
            }           
        }
    }
}
