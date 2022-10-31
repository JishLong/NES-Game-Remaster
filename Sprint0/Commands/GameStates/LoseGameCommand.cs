namespace Sprint0.Commands.GameStates
{
    public class LoseGameCommand : ICommand
    {
        private readonly Game1 Game;

        public LoseGameCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.LoseGame();
        }
    }
}
