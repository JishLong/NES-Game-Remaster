namespace Sprint0.Commands.Levels
{
    internal class PreviousRoomCommand
    {
        private Game1 Game;

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
