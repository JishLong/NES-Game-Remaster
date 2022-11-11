using Microsoft.Xna.Framework;
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
        public Dictionary<string, Types.Event> EventMap;
        public Dictionary<string, Types.Item> ItemMap;
        public Dictionary<string, Types.Door> DoorMap;
        public Dictionary<string, Types.Border> BorderMap;

        public int BlockWidth = 16 * (int) GameScale;
        public int BlockHeight = 16 * (int) GameScale;

        public Vector2 UpDoorPosition;
        public Vector2 RightDoorPosition;
        public Vector2 DownDoorPosition;
        public Vector2 LeftDoorPosition;
            
        private LevelResources()
        {
            UpDoorPosition = new Vector2(BlockWidth * 7,0);
            RightDoorPosition = new Vector2(BlockWidth * 15, BlockHeight * 4 + (BlockHeight / 2));
            DownDoorPosition = new Vector2(BlockWidth * 7, BlockHeight * 10);
            LeftDoorPosition = new Vector2(0,BlockHeight * 4 + (BlockHeight/2));

            BlockMap = new Dictionary<string, Types.Block>()
            {
                {"bt", Types.Block.BLUE_TILE},
                {"bw", Types.Block.BLUE_WALL },
                {"bsl", Types.Block.BLUE_STATUE_LEFT },
                {"bsr", Types.Block.BLUE_STATUE_RIGHT},
                {"bsand", Types.Block.BLUE_SAND },
                {"water", Types.Block.WATER },
                {"bstairs", Types.Block.BLUE_STAIRS },
                {"pushblock", Types.Block.PUSHABLE_BLOCK },
                {"bb", Types.Block.BORDER_BLOCK },
                {"ldwb", Types.Block.LEFT_DOOR_WAY_BLOCK },
                {"rdwb", Types.Block.RIGHT_DOOR_WAY_BLOCK},
                {"rtb", Types.Block.ROOM_TRANSITION_BLOCK },
                {"barrier", Types.Block.BORDER_BLOCK },
                {"brick", Types.Block.GREY_BRICKS },
                {"gstairs", Types.Block.WHITE_BARS },
                {"estb", Types.Block.EXIT_SECRET_TRANSITION_BLOCK },
                {"sbb", Types.Block.SOFT_BORDER_BLOCK },

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
                {"arrow", Types.Item.ARROW },
                {"bluecandle", Types.Item.BLUE_CANDLE },
                {"bluepotion", Types.Item.BLUE_POTION },
                {"bomb", Types.Item.BOMB },
                {"bow", Types.Item.BOW },
                {"clock", Types.Item.CLOCK },
                {"fairy", Types.Item.FAIRY },
                {"heart", Types.Item.HEART },
                {"boomerang", Types.Item.WOODEN_BOOMERANG },
                {"rupee", Types.Item.RUPEE },
            };

            DoorMap = new Dictionary<string, Types.Door>()
            {
                {"up_unlocked", Types.Door.UP_UNLOCKED },
                {"right_unlocked", Types.Door.RIGHT_UNLOCKED },
                {"down_unlocked", Types.Door.DOWN_UNLOCKED },
                {"left_unlocked", Types.Door.LEFT_UNLOCKED },
                {"up_wall", Types.Door.UP_WALL },
                {"right_wall", Types.Door.RIGHT_WALL },
                {"down_wall", Types.Door.DOWN_WALL },
                {"left_wall", Types.Door.LEFT_WALL },
            };

            EventMap = new Dictionary<string, Types.Event>()
            {
                {"pushblock_unlocks_door", Types.Event.PUSHBLOCK_UNLOCKS_DOOR }
            };

            BorderMap = new Dictionary<string, Types.Border>()
            {
                {"blue_border", Types.Border.BLUE_BORDER },
                {"none", Types.Border.NONE},
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
