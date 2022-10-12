using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            };

            CharacterMap = new Dictionary<string, Types.Character>()
            {
                {"skel", Types.Character.SKELETON },
                {"bat", Types.Character.BAT },
            };

            ItemMap = new Dictionary<string, Types.Item>()
            {
                {"comp", Types.Item.COMPASS },
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
