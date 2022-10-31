namespace Sprint0.Commands.GameStates
{
    public class UnpauseGameCommand : ICommand
    {
        private readonly Game1 Game;

        public UnpauseGameCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.UnpauseGame();
        }
    }
}
