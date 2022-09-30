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
            else if (state.FacingRight())
            {
                if (attackFrame == 0)
                {
                    return new PlayerAttackingRightFrame0(state.GetPosition());
                }
                else if (attackFrame == 1)
                {
                    return new PlayerSwordAttackingRightFrame1(state.GetPosition());
                }
                else if (attackFrame == 2)
                {
                    return new PlayerSwordAttackingRightFrame2(state.GetPosition());
                }
                else
                {
                    return new PlayerSwordAttackingRightFrame3(state.GetPosition());
                }
            }
            else if (state.FacingUp())
            {
                if (attackFrame == 0)
                {
                    return new PlayerAttackingUpFrame0(state.GetPosition());
                }
                else if (attackFrame == 1)
                {
                    return new PlayerSwordAttackingUpFrame1(state.GetPosition());
                }
                else if (attackFrame == 2)
                {
                    return new PlayerSwordAttackingUpFrame2(state.GetPosition());
                }
                else
                {
                    return new PlayerSwordAttackingUpFrame3(state.GetPosition());
                }
            }
            // when facing left
            else
            {
                if (attackFrame == 0)
                {
                    return new PlayerAttackingLeftFrame0(state.GetPosition());
                }
                else if (attackFrame == 1)
                {
                    return new PlayerSwordAttackingLeftFrame1(state.GetPosition());
                }
                else if (attackFrame == 2)
                {
                    return new PlayerSwordAttackingLeftFrame2(state.GetPosition());
                }
                else
                {
                    return new PlayerSwordAttackingLeftFrame3(state.GetPosition());
                }
            }
        }
    }
}

