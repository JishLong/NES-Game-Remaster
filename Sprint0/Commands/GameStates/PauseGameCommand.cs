using Sprint0.GameStates;
using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.GameStates
{
    public class PauseGameCommand : ICommand
    {
        private readonly Game1 Game;
        private readonly IGameState PrevGameState;

        public PauseGameCommand(Game1 game, IGameState prevGameState) 
        {
            Game = game;
            PrevGameState = prevGameState;
        }

        public void Execute() 
        {
            Game.CurrentState = new PauseState(Game, PrevGameState);
        }
    }
}
