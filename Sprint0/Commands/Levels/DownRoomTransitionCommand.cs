using Sprint0.Items;
using Sprint0.Levels;

namespace Sprint0.Commands.Levels
{
    public class DownRoomTransitionCommand: ICommand
    {
        private Game1 Game;
        private Room Room;
        private Types.RoomTransition Direction = Types.RoomTransition.DOWN;

        public DownRoomTransitionCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Room = Game.LevelManager.CurrentLevel.CurrentRoom;
            Room.MakeTransition(Direction);
        }
    }
}
