using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.Levels
{
    public class RoomTransitionCommand: ICommand
    {
        private readonly Game1 Game;
        private readonly Types.Direction Direction;

        public RoomTransitionCommand(Game1 game, Types.Direction direction)
        {
            Game = game;
            Direction = direction;
        }

        public void Execute()
        {
            if (Game.LevelManager.CurrentLevel.CurrentRoom.GetAdjacentRoom(Utils.DirectionToRoomTransition(Direction)) != null)
                Game.CurrentState = new RoomTransitionState(Direction);
        }
    }
}
