namespace Sprint0
{
    // Contains various useful enumerations that are used throughout the code
    public static class Types
    {
        public enum Character { BAT, GEL, HAND, RED_GORIYA, SKELETON, ZOL, SNAKE, AQUAMENTUS, DODONGO, FLAME, OLDMAN }

        public enum Item { ARROW, BLUE_CANDLE, BLUE_POTION, BOMB, BOW, CLOCK, COMPASS, FAIRY, HEART, HEART_CONTAINER, 
        KEY, MAP, RUPEE, TRIFORCE_PIECE, WOODEN_BOOMERANG };

        public enum Block { WATER, BLUE_SAND, BLUE_STAIRS, BLUE_STATUE_LEFT, BLUE_STATUE_RIGHT, BLUE_TILE, BLUE_WALL, 
        GREY_BRICKS, LADDER, WHITE_BARS, PUSHABLE_BLOCK_UP, BORDER_BLOCK };

        public enum Projectile { ARROW_EXPLOSION_PARTICLE, ARROW_PROJ, BLUE_ARROW_PROJ, BOMB_EXPLOSION_PARTICLE, BOMB_PROJ,
            BOSS_PROJ, DEATH_PARTICLE, FLAME_PROJ, GORIYA_BOOMERANG_PROJ, PLAYER_BOOMERANG_PROJ, SWORD_MELEE, SWORD_PROJ, SWORD_FLAME_PROJ };

        public enum Direction { UP, DOWN, LEFT, RIGHT, UPLEFT, UPRIGHT, DOWNLEFT, DOWNRIGHT }

        public enum RoomTransition { UP, DOWN, LEFT, RIGHT, SECRET };

        public enum Level{ LEVEL1 };

        public enum PlayerWeapon { SWORD, ARROW, BLUE_ARROW, FLAME, BOMB, BOOMERANG };
    }
}
