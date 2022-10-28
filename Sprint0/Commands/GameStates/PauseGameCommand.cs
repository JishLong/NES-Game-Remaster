using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.GameStates
{
    public class PauseGameCommand : ICommand
    {
        private readonly Game1 Game;

        public PauseGameCommand(Game1 game) 
        {
            Game = game;
        }

        public void Execute() 
        {
            Game.CurrentState = new PauseState();
        }
    }
}
