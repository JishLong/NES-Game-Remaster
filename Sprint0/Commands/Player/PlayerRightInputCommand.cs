using System;
using Sprint0.Player.State;

namespace Sprint0.Commands.Player
{
    public class PlayerRightInputCommand : ICommand
    {
        private readonly PlayerStateController stateController;

        public PlayerRightInputCommand(PlayerStateController stateController)
        {
            this.stateController = stateController;
        }

        public void Execute()
        {
            this.stateController.HandleRightInput();
        }
    }
}

