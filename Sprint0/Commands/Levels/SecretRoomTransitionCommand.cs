using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.Levels
{
    public class SecretRoomTransitionCommand: ICommand
    {
        private readonly Game1 Game;

        public SecretRoomTransitionCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.CurrentState = new SecretRoomTransitionState(Game);
        }
    }
}
