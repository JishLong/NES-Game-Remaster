namespace Sprint0
{
    // Contains various useful enumerations that are used throughout the code
    public static class Types
    {

        public enum Character { BAT, GEL, HAND, RED_GORIYA, SKELETON, ZOL, SNAKE, AQUAMENTUS, DODONGO, FLAME, OLDMAN}

        public enum Item {ARROW, BLUE_CANDLE, BLUE_POTION, BOMB, BOW, CLOCK, COMPASS, FAIRY, HEART, HEART_CONTAINER, 
        KEY, MAP, RUPEE, TRIFORCE_PIECE, WOODEN_BOOMERANG};

        public enum Block { BLUE_GAP, BLUE_SAND, BLUE_STAIRS, BLUE_STATUE_LEFT, BLUE_STATUE_RIGHT, BLUE_TILE, BLUE_WALL, 
        FIRE_BLOCK, GREY_BRICKS, LADDER_BLOCK, WHITE_BARS};

        public enum Projectile { ARROWEXPLOSIONPARTICLE, ARROWPROJ, BLUEARROWPROJ, BOMBEXPLOSIONPARTICLE, BOMBPROJ,
            BOSSPROJ, DEATHPARTICLE, FLAMEPROJ, GORIYABOOMERANGPROJ, PLAYERBOOMERANGPROJ, SWORDMELEE};

        // To be utilized soon
        public enum Direction {UP, DOWN, LEFT, RIGHT, UPLEFT, UPRIGHT, DOWNLEFT, DOWNRIGHT,
            Up
        }
        public enum RoomTransition {UP, DOWN, LEFT, RIGHT, SECRET};
        public enum Level{LEVEL1};

        public enum PlayerWeapon { SWORD, ARROW, BLUEARROW, FLAME, BOMB, BOOMERANG };
    }
}
