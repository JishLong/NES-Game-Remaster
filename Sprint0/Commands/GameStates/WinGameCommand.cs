using Sprint0.Assets;
using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.GameStates
{
    public class WinGameCommand : ICommand
    {
        private readonly Game1 Game;

        public WinGameCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            AudioManager.GetInstance().StopAudio();
            AudioManager.GetInstance().PlayOnce(AudioMappings.GetInstance().WinGame);
            Game.CurrentState = new WinState(Game);
        }
    }
}
