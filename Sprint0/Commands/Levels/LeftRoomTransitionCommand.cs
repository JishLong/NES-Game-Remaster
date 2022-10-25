namespace Sprint0.Commands.Levels
{
    public class LeftRoomTransitionCommand: ICommand
    {
        private readonly Game1 Game;
        private readonly Types.RoomTransition Direction;

        public LeftRoomTransitionCommand(Game1 game)
        {
            Game = game;
            Direction = Types.RoomTransition.LEFT;
        }

        public void Execute()
        {
            Game.LevelManager.CurrentLevel.CurrentRoom.MakeTransition(Direction);
        }
    }
}
