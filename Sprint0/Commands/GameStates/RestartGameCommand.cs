using Sprint0.Assets;
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
            AudioManager.GetInstance().StopAudio();
            AudioManager.GetInstance().PlayLooped(AudioMappings.GetInstance().MusicGame);
            Game.CurrentState = new PlayingState(Game);
        }
    }
}
