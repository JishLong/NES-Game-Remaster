using Sprint0.GameModes.GameModes;

namespace Sprint0.GameModes
{
    public class GameModeManager
    {
        private static GameModeManager Instance;
        
        public IGameMode GameMode { get; private set; }

        public void ChangeGameMode(IGameMode newGameMode) 
        {
            GameMode = newGameMode;
        }

        public void Initialize() 
        {
            GameMode = new DefaultMode();
        }

        public static GameModeManager GetInstance()
        {
            Instance ??= new GameModeManager();
            return Instance;
        }
    }
}
