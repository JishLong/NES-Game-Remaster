using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.Levels
{
    public class DownRoomTransitionCommand: ICommand
    {
        private readonly Game1 Game;
        private readonly Types.RoomTransition Direction;

        public DownRoomTransitionCommand(Game1 game)
        {
            Game = game;
            
            Direction = Types.RoomTransition.DOWN;
        }

        public void Execute()
        {
            Game.LevelManager.CurrentLevel.CurrentRoom.MakeTransition(Direction);
        }
    }
}
