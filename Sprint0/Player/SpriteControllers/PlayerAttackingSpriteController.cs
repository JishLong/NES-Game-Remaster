using System;
using Sprint0.Player.State;
using Sprint0.Sprites.Player;

namespace Sprint0.Player.SpriteControllers
{
    public class PlayerAttackingSpriteController
    {
        private PlayerStateController stateController;
        private PlayerSwordAttackingSpriteController swordController;

        public PlayerAttackingSpriteController(PlayerStateController stateController)
        {
            this.stateController = stateController;
            this.swordController = new PlayerSwordAttackingSpriteController(stateController);
        }

        public ISprite GetSprite()
        {
            var state = stateController.GetState();
            if (state.SwordEquipped())
            {
                return swordController.GetSprite();
            }
            else
            {
                //TODO: temporary
                return new PlayerAttackingDownFrame0(state.GetPosition());
            }
        }
    }
}

