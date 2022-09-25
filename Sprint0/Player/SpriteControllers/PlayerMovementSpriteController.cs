using System;
using Sprint0.Player.State;
using Sprint0.Sprites.Player;

namespace Sprint0.Player.SpriteControllers
{
    public class PlayerMovementSpriteController
    {
        int animationFrame = 0;
        PlayerStateController stateController;

        public PlayerMovementSpriteController(PlayerStateController stateController)
        {
            this.stateController = stateController;
        }

        public void Update()
        {
            if (animationFrame > 30)
            {
                animationFrame = 0;
            }
            else
            {
                animationFrame++;
            }
        }

        public void Reset()
        {
            animationFrame = 0;
        }

        public ISprite GetSprite()
        {
            var state = stateController.GetState();

            if (state.FacingUp())
            {
                if (animationFrame > 15)
                {
                    return new PlayerFacingUpFrame0(state.GetPosition());
                }
                else
                {
                    return new PlayerFacingUpFrame1(state.GetPosition());
                }
            }
            else if (state.FacingDown())
            {
                if (animationFrame > 15)
                {
                    return new PlayerFacingDownwardFrame1(state.GetPosition());
                }
                else
                {
                    return new PlayerFacingDownwardFrame0(state.GetPosition());
                }
            }
            else if (state.FacingRight())
            {
                if (animationFrame > 15)
                {
                    return new PlayerFacingRightFrame0(state.GetPosition());
                }
                else
                {
                    return new PlayerFacingRightFrame1(state.GetPosition());
                }
            }

            else
            {
                if (animationFrame > 15)
                {
                    return new PlayerFacingLeftFrame0(state.GetPosition());
                }
                else
                {
                    return new PlayerFacingLeftFrame1(state.GetPosition());
                }
            }
        }
    }
}

