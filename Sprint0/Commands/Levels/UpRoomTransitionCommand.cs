namespace Sprint0.Commands.Levels
{
    public class UpRoomTransitionCommand: ICommand
    {
        private readonly Game1 Game;
        private readonly Types.RoomTransition Direction;

        public UpRoomTransitionCommand(Game1 game)
        {
            Game = game;
            Direction = Types.RoomTransition.UP;
        }

        public void Execute()
        {
            Game.LevelManager.CurrentLevel.CurrentRoom.MakeTransition(Direction);
        }
    }
}
