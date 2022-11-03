using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.Levels
{
    public class LeftRoomTransitionCommand: ICommand
    {
        private readonly Game1 Game;

        public LeftRoomTransitionCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            if (Game.LevelManager.CurrentLevel.CurrentRoom.GetAdjacentRoom(Types.RoomTransition.LEFT) != null)
            Game.CurrentState = new LeftTransitionState();
        }
    }
}
