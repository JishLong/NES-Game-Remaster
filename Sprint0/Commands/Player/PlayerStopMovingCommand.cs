using Sprint0.Player.State;

namespace Sprint0.Commands.Player
{
    public class PlayerStopMovingCommand : ICommand
    {
        private readonly PlayerStateController stateController;

        public PlayerStopMovingCommand(PlayerStateController stateController)
        {
            this.stateController = stateController;
        }

        public void Execute()
        {
            this.stateController.HandleStopMoving();
        }
    }
}
