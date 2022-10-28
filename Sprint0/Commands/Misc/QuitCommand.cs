namespace Sprint0.Commands.Misc
{
    public class QuitCommand : ICommand
    {
        private readonly Game1 Game;

        public QuitCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            AudioManager.GetInstance().StopAllSound();
            Game.Exit();
        }
    }
}
