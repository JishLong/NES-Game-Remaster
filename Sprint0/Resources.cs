using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    public static class Resources
    {
        // Sprite sheets for blocks
        public static Texture2D BlocksSpriteSheet;
        public static Texture2D FireSpriteSheet;
        public static Texture2D WeaponsAndItemsSpriteSheet;

        // Sprite sheets for items
        public static Texture2D StillItemsSpriteSheet;
        public static Texture2D FairySpriteSheet;
        public static Texture2D HeartSpriteSheet;
        public static Texture2D RupeeSpriteSheet;
        public static Texture2D TriforcePieceSpriteSheet;

        public static Texture2D BossEnemiesSpriteSheet;
        public static Texture2D NpcsSpriteSheet;
        public static Texture2D LinkItemsSpriteSheet;

        public static SpriteFont CreditsFont;
        // Sprite sheets for enemies
        public static Texture2D DungeonEnemySpriteSheet;

        // Sprite sheet positions for all blocks
        public static readonly Rectangle FireBlock = new Rectangle(0, 0, 16, 16);
        public static readonly Rectangle BlueTile = new Rectangle(4, 11, 16, 16);
        public static readonly Rectangle BlueWall = new Rectangle(21, 11, 16, 16);
        public static readonly Rectangle BlueGap = new Rectangle(38, 28, 16, 16);
        public static readonly Rectangle BlueStatueLeft = new Rectangle(38, 11, 16, 16);
        public static readonly Rectangle BlueStatueRight = new Rectangle(55, 11, 16, 16);
        public static readonly Rectangle BlueStairs = new Rectangle(55, 28, 16, 16);
        public static readonly Rectangle BlueSand = new Rectangle(21, 28, 16, 16);
        public static readonly Rectangle GreyBricks = new Rectangle(4, 45, 16, 16);
        public static readonly Rectangle WhiteBars = new Rectangle(21, 45, 16, 16);
        public static readonly Rectangle LadderBlock = new Rectangle(280, 12, 16, 16);

        // Sprite sheet positions for still items
        public static readonly Rectangle Compass = new Rectangle(0, 0, 16, 16);
        public static readonly Rectangle Map = new Rectangle(16, 0, 16, 16);
        public static readonly Rectangle Key = new Rectangle(32, 0, 16, 16);
        public static readonly Rectangle HeartContainer = new Rectangle(48, 0, 16, 16);
        public static readonly Rectangle WoodenBoomerang = new Rectangle(64, 0, 16, 16);
        public static readonly Rectangle Bow = new Rectangle(80, 0, 16, 16);
        public static readonly Rectangle Arrow = new Rectangle(96, 0, 16, 16);
        public static readonly Rectangle Bomb = new Rectangle(112, 0, 16, 16);
        public static readonly Rectangle Clock = new Rectangle(128, 0, 16, 16);
        public static readonly Rectangle BlueCandle = new Rectangle(144, 0, 16, 16);
        public static readonly Rectangle BluePotion = new Rectangle(160, 0, 16, 16);

        public static void LoadContent(ContentManager c) 
        {
            // Load enemy sprite sheets
            DungeonEnemySpriteSheet = c.Load<Texture2D>("DungeonEnemies");

            // Load item sprite sheets
            StillItemsSpriteSheet = c.Load<Texture2D>("stillItems");
            FairySpriteSheet = c.Load<Texture2D>("fairyItem");
            HeartSpriteSheet = c.Load<Texture2D>("heartItem");
            RupeeSpriteSheet = c.Load<Texture2D>("rupeeItem");
            TriforcePieceSpriteSheet = c.Load<Texture2D>("triforcePieceItem");
            BossEnemiesSpriteSheet = c.Load<Texture2D>("BossEnemies");
            NpcsSpriteSheet = c.Load<Texture2D>("Npcs");
            LinkItemsSpriteSheet = c.Load<Texture2D>("Link+items");

            // Load block sprite sheets
            BlocksSpriteSheet = c.Load<Texture2D>("dungeonBlocks");
            FireSpriteSheet = c.Load<Texture2D>("fireBlock");
            WeaponsAndItemsSpriteSheet = c.Load<Texture2D>("weaponsAndItems");      
        }
    }
}
