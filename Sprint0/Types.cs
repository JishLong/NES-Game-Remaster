﻿namespace Sprint0
{
    // Contains various useful enumerations that are used throughout the code
    public static class Types
    {

        public enum Character { BAT, GEL, HAND, RED_GORIYA, SKELETON, ZOL, SNAKE, BLADE_TRAP, AQUAMENTUS, DODONGO, FLAME, OLDMAN}
        public enum Item { ARROW, BLUE_CANDLE, BLUE_POTION, BOMB, BOW, CLOCK, COMPASS, FAIRY, HEART, HEART_CONTAINER, 
        KEY, MAP, RUPEE, TRIFORCE_PIECE, WOODEN_BOOMERANG };

        public enum Block { WATER, BLUE_SAND, BLUE_STAIRS, BLUE_STATUE_LEFT, BLUE_STATUE_RIGHT, BLUE_TILE, BLUE_WALL, 
        GREY_BRICKS, LADDER, WHITE_BARS, PUSHABLE_BLOCK, BORDER_BLOCK };

        public enum Projectile { ARROW_EXPLOSION_PARTICLE, ARROW_PROJ, BLUE_ARROW_PROJ, BOMB_EXPLOSION_PARTICLE, BOMB_PROJ,
            BOSS_PROJ, DEATH_PARTICLE, FLAME_PROJ, BOOMERANG_PROJ, SWORD_MELEE, SWORD_PROJ, SWORD_FLAME_PROJ, SPAWN_PARTICLE };

        public enum Direction { UP, DOWN, LEFT, RIGHT, UPLEFT, UPRIGHT, DOWNLEFT, DOWNRIGHT, NO_DIRECTION }

        public enum RoomTransition { UP, DOWN, LEFT, RIGHT, SECRET };

        public enum Level{ LEVEL1 };
    }
}
