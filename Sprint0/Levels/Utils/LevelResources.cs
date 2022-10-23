using System.Collections.Generic;

namespace Sprint0.Levels.Utils
{
    public class LevelResources
    {
        private static LevelResources Instance;
        public Dictionary<string, Types.Block> BlockMap;
        public Dictionary<string, Types.Character> CharacterMap;
        public Dictionary<string, Types.Item> ItemMap;

        private static int Scale = 3;  // This seems to be universal, need to find a way to centralize it.
        public int BlockWidth = 16 * Scale;
        public int BlockHeight = 16 * Scale;

        private LevelResources()
        {
            BlockMap = new Dictionary<string, Types.Block>()
            {
                {"bt", Types.Block.BLUE_TILE},
                {"bw", Types.Block.BLUE_WALL },
                {"bsl", Types.Block.BLUE_STATUE_LEFT },
                {"bsr", Types.Block.BLUE_STATUE_RIGHT},
                {"bsand", Types.Block.BLUE_SAND },
                {"water", Types.Block.BLUE_GAP },
                {"bstairs", Types.Block.BLUE_STAIRS },
            };

            CharacterMap = new Dictionary<string, Types.Character>()
            {
                {"skel", Types.Character.SKELETON },
                {"bat", Types.Character.BAT },
                {"gel", Types.Character.GEL },
                {"rgoriya", Types.Character.RED_GORIYA},
                {"hand", Types.Character.HAND },
                {"aqua", Types.Character.AQUAMENTUS},
                {"oldman", Types.Character.OLDMAN },
                {"flame", Types.Character.FLAME },
            };

            ItemMap = new Dictionary<string, Types.Item>()
            {
                {"comp", Types.Item.COMPASS },
                {"key", Types.Item.KEY },
                {"tforce", Types.Item.TRIFORCE_PIECE },
                {"hcont", Types.Item.HEART_CONTAINER },
                {"map", Types.Item.MAP },
            };
        }
        public static LevelResources GetInstance()
        {
            if (Instance == null)
            {
                Instance = new LevelResources();
            }
            return Instance;
        }
    }
}
