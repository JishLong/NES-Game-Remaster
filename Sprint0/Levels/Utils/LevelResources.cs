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

        public readonly int BlockWidth = (int)(16 * GameWindow.ResolutionScale);
        public readonly int BlockHeight = (int)(16 * GameWindow.ResolutionScale);
        public readonly int BorderWidth = 16 * 3 * 2;

        public Vector2 UpDoorPosition;
        public Vector2 RightDoorPosition;
        public Vector2 DownDoorPosition;
        public Vector2 LeftDoorPosition;
            
        private LevelResources()
        {
            UpDoorPosition = new Vector2(BlockWidth * 7,0);
            RightDoorPosition = new Vector2(BlockWidth * 14, BlockHeight * 4 + (BlockHeight / 2));
            DownDoorPosition = new Vector2(BlockWidth * 7, BlockHeight * 9);
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
                {"hst", Types.Block.HAND_SPAWNER_TRIGGER }

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
                {"sectext", Types.Character.SECRET_TEXT }
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
                {"valuablerupee", Types.Item.VALUABLE_RUPEE }
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
                {"up_event_locked", Types.Door.UP_EVENT_LOCKED },
                {"right_event_locked", Types.Door.RIGHT_EVENT_LOCKED },
                {"down_event_locked", Types.Door.DOWN_EVENT_LOCKED },
                {"left_event_locked", Types.Door.LEFT_EVENT_LOCKED },
                {"up_key_locked", Types.Door.UP_KEY_LOCKED},
                {"right_key_locked", Types.Door.RIGHT_KEY_LOCKED },
                {"down_key_locked", Types.Door.DOWN_KEY_LOCKED },
                {"left_key_locked", Types.Door.LEFT_KEY_LOCKED },
                {"up_secret_unlocked", Types.Door.UP_SECRET_UNLOCKED },
                {"right_secret_unlocked", Types.Door.RIGHT_SECRET_UNLOCKED },
                {"down_secret_unlocked", Types.Door.DOWN_SECRET_UNLOCKED },
                {"left_secret_unlocked", Types.Door.LEFT_SECRET_UNLOCKED },
                {"up_secret_wall", Types.Door.UP_SECRET_WALL },
                {"right_secret_wall", Types.Door.RIGHT_SECRET_WALL },
                {"down_secret_wall", Types.Door.DOWN_SECRET_WALL },
                {"left_secret_wall", Types.Door.LEFT_SECRET_WALL }
            };

            EventMap = new Dictionary<string, Types.Event>()
            {
                {"pushblock_unlocks_door", Types.Event.PUSHBLOCK_UNLOCKS_DOOR },
                {"enemies_killed_drops_item", Types.Event.ENEMIES_KILLED_DROPS_ITEM },
                {"enemies_killed_unlocks_door", Types.Event.ENEMIES_KILLED_UNLOCKS_DOOR },
                {"old_man_attack", Types.Event.OLD_MAN_ATTACK }
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
