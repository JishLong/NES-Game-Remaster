using Sprint0.GameStates;

namespace Sprint0.Commands.GameStates
{
    public class UnpauseGameCommand : ICommand
    {
        private readonly Game1 Game;
        private readonly IGameState PrevGameState;

        public UnpauseGameCommand(Game1 game, IGameState prevGameState)
        {
            Game = game;
            PrevGameState = prevGameState;
        }

        public void Execute()
        {
            Game.CurrentState = PrevGameState;
        }
    }
}
