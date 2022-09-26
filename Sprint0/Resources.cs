using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    public static class Resources
    {
        // Sprite sheets for blocks
        public static Texture2D blocksSpriteSheet;
        public static Texture2D fireSpriteSheet;
        public static Texture2D weaponsAndItemsSpriteSheet;

        // Sprite sheets for items
        public static Texture2D stillItemsSheet;
        public static Texture2D fairyItemSheet;
        public static Texture2D heartItemSheet;
        public static Texture2D rupeeItemSheet;
        public static Texture2D triforcePieceItemSheet;

        // Sprite sheets for enemies
        public static Texture2D DungeonEnemySpriteSheet;

        // Sprite sheet positions for all blocks
        public static Rectangle fireBlock;
        public static Rectangle blueTile;
        public static Rectangle blueWall;
        public static Rectangle blueGap;
        public static Rectangle blueStatueLeft;
        public static Rectangle blueStatueRight;
        public static Rectangle blueStairs;
        public static Rectangle blueSand;
        public static Rectangle greyBricks;
        public static Rectangle whiteBars;
        public static Rectangle ladderBlock;


        // Sprite sheet positions for still items
        public static Rectangle compass;
        public static Rectangle map;
        public static Rectangle key;
        public static Rectangle heartContainer;
        public static Rectangle woodenBoomerang;
        public static Rectangle bow;
        public static Rectangle arrow;
        public static Rectangle bomb;
        public static Rectangle clock;
        public static Rectangle blueCandle;
        public static Rectangle bluePotion;

        public static void LoadContent(ContentManager c) 
        {

            // Load enemy sprite sheets
            DungeonEnemySpriteSheet = c.Load<Texture2D>("DungeonEnemies");

            // Load item sprite sheets
            stillItemsSheet = c.Load<Texture2D>("stillItems");
            fairyItemSheet = c.Load<Texture2D>("fairyItem");
            heartItemSheet = c.Load<Texture2D>("heartItem");
            rupeeItemSheet = c.Load<Texture2D>("rupeeItem");
            triforcePieceItemSheet = c.Load<Texture2D>("triforcePieceItem");

            // Load block sprite sheets
            blocksSpriteSheet = c.Load<Texture2D>("dungeonBlocks");
            fireSpriteSheet = c.Load<Texture2D>("fireBlock");
            weaponsAndItemsSpriteSheet = c.Load<Texture2D>("weaponsAndItems");

            // Load positions for all blocks
            fireBlock = new Rectangle(0, 0, 16, 16);
            blueTile = new Rectangle(5, 12, 16, 16);
            blueWall = new Rectangle(22, 12, 16, 16);
            blueGap = new Rectangle(39, 29, 16, 16);
            blueStatueLeft = new Rectangle(39, 12, 16, 16);
            blueStatueRight = new Rectangle(56, 12, 16, 16);
            blueStairs = new Rectangle(56, 29, 16, 16);
            blueSand = new Rectangle(22, 29, 16, 16);
            greyBricks = new Rectangle(5, 46, 16, 16);
            whiteBars = new Rectangle(22, 46, 16, 16);
            ladderBlock = new Rectangle(280, 12, 16, 16);



            // Load exact position of still items
            compass = new Rectangle(0, 0, 16, 16);
            map = new Rectangle(16, 0, 16, 16);
            key = new Rectangle(32, 0, 16, 16);
            heartContainer = new Rectangle(48, 0, 16, 16);
            woodenBoomerang = new Rectangle(64, 0, 16, 16);
            bow = new Rectangle(80, 0, 16, 16);
            arrow = new Rectangle(96, 0, 16, 16);
            bomb = new Rectangle(112, 0, 16, 16);
            clock = new Rectangle(128, 0, 16, 16);
            blueCandle = new Rectangle(144, 0, 16, 16);
            bluePotion = new Rectangle(160, 0, 16, 16);
        }
    }
}
