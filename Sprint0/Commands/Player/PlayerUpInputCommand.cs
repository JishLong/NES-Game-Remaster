using Sprint0.Player.State;

namespace Sprint0.Commands.Player
{
    public class PlayerUpInputCommand : ICommand
    {
        private readonly PlayerStateController stateController;

        public PlayerUpInputCommand(PlayerStateController stateController)
        {
            this.stateController = stateController;
        }

        public void Execute()
        {
            this.stateController.HandleUpInput();
        }
    }
}
