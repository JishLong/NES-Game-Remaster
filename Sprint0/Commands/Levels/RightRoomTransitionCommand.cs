namespace Sprint0.Commands.Levels
{
    public class RightRoomTransitionCommand: ICommand
    {
        private readonly Game1 Game;
        private readonly Types.RoomTransition Direction;

        public RightRoomTransitionCommand(Game1 game)
        {
            Game = game;
            Direction = Types.RoomTransition.RIGHT;
        }

        public void Execute()
        {
            Game.LevelManager.CurrentLevel.CurrentRoom.MakeTransition(Direction);
        }
    }
}
