using Sprint0.GameModes.GameModes;

namespace Sprint0.GameModes
{
    public class GameModeManager
    {
        private static GameModeManager Instance;
        
        public IGameMode GameMode { get; private set; }

        public void ChangeGameMode(IGameMode newGameMode, Game1 game) 
        {
            foreach (var player in game.PlayerManager)
            {
                player.TransitionGameModes(GameMode, newGameMode);
            }
            foreach (var room in game.LevelManager.CurrentLevel.Rooms) 
            {
                bool IsCurrentRoom = room == game.LevelManager.CurrentLevel.CurrentRoom;

                foreach (var character in room.Characters) 
                {
                    character.TransitionGameModes(GameMode, newGameMode, IsCurrentRoom);
                }
            }
            GameMode = newGameMode;
        }

        public void Initialize() 
        {
            GameMode = new NormalMode();
        }

        public static GameModeManager GetInstance()
        {
            Instance ??= new GameModeManager();
            return Instance;
        }
    }
}
