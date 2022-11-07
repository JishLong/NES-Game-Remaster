using Sprint0.GameStates.GameStates;

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
            AudioManager.GetInstance().StopAudio();
            AudioManager.GetInstance().PlayLooped(Resources.DungeonMusic);
            Game.CurrentState = new PlayingState();
        }
    }
}
