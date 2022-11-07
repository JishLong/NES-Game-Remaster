using Sprint0.GameStates.GameStates;

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
            AudioManager.GetInstance().StopAudio();
            Game.CurrentState = new LoseState();
        }
    }
}
