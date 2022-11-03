using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.Levels
{
    public class DownRoomTransitionCommand: ICommand
    {
        private readonly Game1 Game;

        public DownRoomTransitionCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            if (Game.LevelManager.CurrentLevel.CurrentRoom.GetAdjacentRoom(Types.RoomTransition.DOWN) != null)
                Game.CurrentState = new DownTransitionState();
        }
    }
}
