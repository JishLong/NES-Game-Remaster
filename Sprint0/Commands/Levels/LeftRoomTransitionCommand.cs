using Sprint0.Items;
using Sprint0.Levels;

namespace Sprint0.Commands.Levels
{
    public class LeftRoomTransitionCommand: ICommand
    {
        private Game1 Game;
        private Room Room;
        private Types.RoomTransition Direction = Types.RoomTransition.LEFT;

        public LeftRoomTransitionCommand(Game1 game)
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
