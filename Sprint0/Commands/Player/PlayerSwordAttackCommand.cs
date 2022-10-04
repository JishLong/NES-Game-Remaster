using Sprint0.Player.State;

namespace Sprint0.Commands.Player
{
    public class PlayerSwordAttackCommand : ICommand
    {
        private readonly PlayerStateController stateController;

        public PlayerSwordAttackCommand(PlayerStateController stateController)
        {
            this.stateController = stateController;
        }

        public void Execute()
        {
            this.stateController.HandleSwordAttackInput();
        }
    }
}
