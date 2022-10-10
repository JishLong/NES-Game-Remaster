﻿using Sprint0.Player.State;

namespace Sprint0.Commands.Player
{
    public class PlayerArrowAttackCommand : ICommand
    {
        private readonly PlayerStateController stateController;

        public PlayerArrowAttackCommand(PlayerStateController stateController)
        {
            this.stateController = stateController;
        }

        public void Execute()
        {
            this.stateController.HandleArrowAttackInput();
        }
    }
}