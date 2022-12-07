using Sprint0.GameModes.GameModes;

namespace Sprint0.GameModes
{
    public class GameModeManager
    {
        private static GameModeManager Instance;
        
        public IGameMode GameMode { get; set; }

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
