namespace Sprint0.Commands.Levels
{
    public class NextRoomCommand : ICommand
    {
        private readonly Game1 Game;

        public NextRoomCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.LevelManager.CurrentLevel.GoToNextRoom();
        }
    }
}
