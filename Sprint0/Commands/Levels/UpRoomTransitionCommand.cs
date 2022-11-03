using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.Levels
{
    public class UpRoomTransitionCommand: ICommand
    {
        private readonly Game1 Game;

        public UpRoomTransitionCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            if (Game.LevelManager.CurrentLevel.CurrentRoom.GetAdjacentRoom(Types.RoomTransition.UP) != null)
                Game.CurrentState = new UpTransitionState();
        }
    }
}
