using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.GameStates
{
    public class RestartGameCommand : ICommand
    {
        private readonly Game1 Game;

        public RestartGameCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.CreateNewGame();
            Game.CurrentState = new PlayingState();
        }
    }
}
