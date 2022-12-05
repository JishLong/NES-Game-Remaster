using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.Levels
{
    public class ExitSecretRoomTransitionCommand: ICommand
    {
        private readonly Game1 Game;

        public ExitSecretRoomTransitionCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.CurrentState = new ExitSecretRoomTransitionState(Game);
        }
    }
}
