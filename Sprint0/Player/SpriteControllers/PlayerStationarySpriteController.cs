using Sprint0.Player.State;
using Sprint0.Sprites.Player;

namespace Sprint0.Player.SpriteControllers
{
    public class PlayerStationarySpriteController
    {
        readonly PlayerStateController stateController;

        public PlayerStationarySpriteController(PlayerStateController stateController)
        {
            this.stateController = stateController;
        }

        public ISprite GetSprite()
        {
            var state = stateController.GetState();

            if (state.FacingUp())
            {
                return new PlayerFacingUpFrame0(state.GetPosition());
            }
            else if (state.FacingDown())
            {
                return new PlayerFacingDownwardFrame0(state.GetPosition());
            }
            else if (state.FacingRight())
            {
                return new PlayerFacingRightFrame0(state.GetPosition());
            }
            else
            {
                return new PlayerFacingLeftFrame0(state.GetPosition());
            }
        }
    }
}

