using Sprint0.Player.State;

namespace Sprint0.Commands.Player
{
    public class PlayerTakeDamageCommand : ICommand
    {
        private readonly PlayerStateController stateController;

        public PlayerTakeDamageCommand(PlayerStateController stateController)
        {
            this.stateController = stateController;
        }

        public void Execute()
        {
            this.stateController.HandleTakeDamage();
        }
    }
}
