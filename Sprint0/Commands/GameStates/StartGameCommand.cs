namespace Sprint0.Commands.GameStates
{
    public class StartGameCommand : ICommand
    {
        private readonly Game1 Game;

        public StartGameCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.StartGame();
        }
    }
}
