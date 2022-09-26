﻿namespace Sprint0.Commands.Player
{
    public class QuitCommand : ICommand
    {
        private Game1 game;

        public QuitCommand(Game1  game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}

