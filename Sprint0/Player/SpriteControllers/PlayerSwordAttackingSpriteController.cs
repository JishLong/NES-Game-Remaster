using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;
using Sprint0.Sprites;
using Sprint0.Sprites.Player;
using Sprint0.Sprites.Player.Attack.SwordAttack;

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
            currentSprite = PlayerSwordAttackDown.GetInstance(stateController);
        }

        public void Update()
        {
            var state = stateController.GetState();

            if (state.FacingDown())
            {
                currentSprite = PlayerSwordAttackDown.GetInstance(stateController);
            }
            else if (state.FacingRight())
            {
                currentSprite = PlayerSwordAttackRight.GetInstance(stateController);
            }
            else if (state.FacingUp())
            {
                currentSprite = PlayerSwordAttackUp.GetInstance(stateController);
            }
            // when facing left
            else
            {
                currentSprite = PlayerSwordAttackLeft.GetInstance(stateController);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Draw(spriteBatch, 0, 0, 0, 0);
        }

        public void Reset() { }
    }
}