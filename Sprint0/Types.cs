namespace Sprint0
{
    // Contains various useful enumerations that are used throughout the code
    public static class Types
    {
        public enum Block
        {
            BLUE_SAND, BLUE_STAIRS, BLUE_STATUE_LEFT, BLUE_STATUE_RIGHT, BLUE_TILE, BLUE_WALL, BORDER_BLOCK,
            EXIT_SECRET_TRANSITION_BLOCK, GREY_BRICKS, LEFT_DOOR_WAY_BLOCK, PUSHABLE_BLOCK, RIGHT_DOOR_WAY_BLOCK,
            ROOM_TRANSITION_BLOCK, SOFT_BORDER_BLOCK, WATER, WHITE_BARS,
        };

        public enum Border { BLUE_BORDER, NONE }

        public enum Character { AQUAMENTUS, BLADE_TRAP, BAT, DODONGO, FLAME, GEL, HAND, OLDMAN, RED_GORIYA, SKELETON, SNAKE, ZOL }

        public enum Direction { UP, DOWN, LEFT, RIGHT, UPLEFT, UPRIGHT, DOWNLEFT, DOWNRIGHT, NO_DIRECTION }

        public enum Door { UP_LOCKED, RIGHT_LOCKED, DOWN_LOCKED, LEFT_LOCKED, 
                           UP_UNLOCKED, RIGHT_UNLOCKED, DOWN_UNLOCKED, LEFT_UNLOCKED,
                           UP_EVENT_LOCKED, RIGHT_EVENT_LOCKED, DOWN_EVENT_LOCKED, LEFT_EVENT_LOCKED,
                           UP_WALL, RIGHT_WALL, DOWN_WALL, LEFT_WALL,
                           UP_SECRET, RIGHT_SECRET, DOWN_SECRET, LEFT_SECRET}

        public enum Event { PUSHBLOCK_UNLOCKS_DOOR, ENEMIES_KILLED_DROPS_ITEM, ENEMIES_KILLED_UNLOCKS_DOOR }

        public enum Item
        {
            ARROW, BLUE_CANDLE, BLUE_POTION, BOMB, BOW, CLOCK, COMPASS, FAIRY, HEART, HEART_CONTAINER,
            KEY, MAP, RUPEE, TRIFORCE_PIECE, WOODEN_BOOMERANG, VALUABLE_RUPEE
        };

        public enum Level { LEVEL1 };

        public enum Projectile { ARROW_EXPLOSION_PARTICLE, ARROW_PROJ, BLUE_ARROW_PROJ, BOMB_EXPLOSION_PARTICLE, BOMB_PROJ,
            BOOMERANG_PROJ, BOSS_PROJ, DEATH_PARTICLE, FLAME_PROJ, SPAWN_PARTICLE, SWORD_MELEE, SWORD_PROJ, SWORD_FLAME_PROJ };
        
        public enum RoomTransition { UP, DOWN, LEFT, RIGHT, SECRET };   
    }
}
