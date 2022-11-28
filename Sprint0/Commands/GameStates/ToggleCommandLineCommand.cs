using Sprint0.GameStates;
using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.GameStates
{
    public class ToggleCommandLineCommand : ICommand
    {
        private readonly Game1 Game;

        public ToggleCommandLineCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            if (Game.CurrentState is CommandLineState) Game.CurrentState = new PlayingState(Game);
            else if (Game.CurrentState is PlayingState) Game.CurrentState = new CommandLineState(Game);
        }
    }
}
