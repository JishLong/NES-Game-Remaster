using System;
using Sprint0.Player.State;

namespace Sprint0.Commands.Player
{
    public class PlayerDownInputCommand : ICommand
    {
        private readonly PlayerStateController stateController;

        public PlayerDownInputCommand(PlayerStateController stateController)
        {
            this.stateController = stateController;
        }

        public void Execute()
        {
            this.stateController.HandleDownInput();
        }
    }
}

