using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.GameStates
{
    public class GoToBeginningCommand : ICommand
    {
        private readonly Game1 Game;

        public GoToBeginningCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.CurrentState = new HandTransitionState(Game);
        }
    }
}
