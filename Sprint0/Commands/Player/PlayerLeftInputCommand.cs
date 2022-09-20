using System;
using Sprint0.Player.State;

namespace Sprint0.Commands.Player
{
    public class PlayerLeftInputCommand : ICommand
    {
        private readonly PlayerStateController stateController;

        public PlayerLeftInputCommand(PlayerStateController stateController)
        {
            this.stateController = stateController;
        }

        public void Execute()
        {
            this.stateController.HandleLeftInput();
        }
    }
}

