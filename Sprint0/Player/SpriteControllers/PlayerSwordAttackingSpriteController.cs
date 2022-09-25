using System;
using Sprint0.Player.State;
using Sprint0.Sprites.Player;

namespace Sprint0.Player.SpriteControllers
{
    public class PlayerSwordAttackingSpriteController
    {
        private PlayerStateController stateController;

        public PlayerSwordAttackingSpriteController(PlayerStateController stateController)
        {
            this.stateController = stateController;
        }

        public ISprite GetSprite()
        {
            int attackFrame = stateController.GetAttackFrame();
            var state = stateController.GetState();

            if (state.FacingDown())
            {
                if (attackFrame == 0)
                {
                    return new PlayerAttackingDownFrame0(state.GetPosition());
                }
                else if (attackFrame == 1)
                {
                    return new PlayerSwordAttackingDownFrame1(state.GetPosition());
                }
                else if (attackFrame == 2)
                {
                    return new PlayerSwordAttackingDownFrame2(state.GetPosition());
                }
                else
                {
                    return new PlayerSwordAttackingDownFrame3(state.GetPosition());
                }
            }
            else
            {
                // TODO: temporary
                return new PlayerFacingDownwardFrame0(state.GetPosition());
            }
        }
    }
}

