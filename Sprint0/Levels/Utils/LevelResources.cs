using Sprint0;
using System.Collections.Generic;
using static Sprint0.Utils;

namespace Sprint0.Levels.Utils
{
    public class LevelResources
    {
        private static LevelResources Instance;
        public Dictionary<string, Types.Block> BlockMap;
        public Dictionary<string, Types.Character> CharacterMap;
        public Dictionary<string, Types.Item> ItemMap;
        public Dictionary<string, Types.Door> DoorMap;

        public int BlockWidth = 16 * (int) GameScale;
        public int BlockHeight = 16 * (int) GameScale;

        private LevelResources()
        {
            BlockMap = new Dictionary<string, Types.Block>()
            {
                {"bt", Types.Block.BLUE_TILE},
                {"bw", Types.Block.BLUE_WALL },
                {"bsl", Types.Block.BLUE_STATUE_LEFT },
                {"bsr", Types.Block.BLUE_STATUE_RIGHT},
                {"bsand", Types.Block.BLUE_SAND },
                {"water", Types.Block.WATER },
                {"bstairs", Types.Block.BLUE_STAIRS },
                {"pb", Types.Block.PUSHABLE_BLOCK },
                {"bb", Types.Block.BORDER_BLOCK },
                {"ldwb", Types.Block.LEFT_DOOR_WAY_BLOCK },
                {"rdwb", Types.Block.RIGHT_DOOR_WAY_BLOCK},

            };

            CharacterMap = new Dictionary<string, Types.Character>()
            {
                {"skel", Types.Character.SKELETON },
                {"bat", Types.Character.BAT },
                {"gel", Types.Character.GEL },
                {"rgoriya", Types.Character.RED_GORIYA},
                {"hand", Types.Character.HAND },
                {"blade", Types.Character.BLADE_TRAP },
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

            DoorMap = new Dictionary<string, Types.Door>()
            {
                {"up_unlocked", Types.Door.UP_UNLOCKED},
                {"right_unlocked", Types.Door.RIGHT_UNLOCKED },
                {"down_unlocked", Types.Door.DOWN_UNLOCKED },
                {"left_unlocked", Types.Door.LEFT_UNLOCKED },
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
