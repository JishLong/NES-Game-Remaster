namespace Sprint0.Commands.Levels
{
    public class PreviousRoomCommand
    {
        private readonly Game1 Game;

        public PreviousRoomCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.LevelManager.CurrentLevel.GoToPreviousRoom();
        }
    }
}
