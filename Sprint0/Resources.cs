using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    // Contains spritesheets and exact positions of desirable items on them
    public static class Resources
    {
        // Sprite sheets for blocks
        public static Texture2D BlocksSpriteSheet;
        public static Texture2D ItemsSpriteSheet;
        public static Texture2D WeaponsAndProjSpriteSheet;
        public static Texture2D CharactersSpriteSheet;
        public static Texture2D LinkSpriteSheet;

        // Old sprite sheets - just in case someone needs to implement something using these at first
        public static Texture2D BossEnemiesSheet;
        public static Texture2D DungeonEnemiesSheet;
        public static Texture2D EnemyDeathSheet;
        public static Texture2D LinkAndItemsSheet;
        public static Texture2D NpcsSheet;
        public static Texture2D WeaponsAndItemsSheet;

        // Sprite sheet positions for all blocks
        public static readonly Rectangle FireBlock = new Rectangle(32, 32, 16, 16);
        public static readonly Rectangle BlueTile = new Rectangle(0, 0, 16, 16);
        public static readonly Rectangle BlueWall = new Rectangle(16, 0, 16, 16);
        public static readonly Rectangle BlueGap = new Rectangle(32, 16, 16, 16);
        public static readonly Rectangle BlueStatueLeft = new Rectangle(32, 0, 16, 16);
        public static readonly Rectangle BlueStatueRight = new Rectangle(48, 0, 16, 16);
        public static readonly Rectangle BlueStairs = new Rectangle(48, 16, 16, 16);
        public static readonly Rectangle BlueSand = new Rectangle(16, 16, 16, 16);
        public static readonly Rectangle GreyBricks = new Rectangle(0, 32, 16, 16);
        public static readonly Rectangle WhiteBars = new Rectangle(16, 32, 16, 16);
        public static readonly Rectangle LadderBlock = new Rectangle(0, 16, 16, 16);

        // Sprite sheet positions for all items
        public static readonly Rectangle Compass = new Rectangle(0, 0, 11, 12);
        public static readonly Rectangle Map = new Rectangle(11, 0, 8, 16);
        public static readonly Rectangle Key = new Rectangle(19, 0, 8, 16);
        public static readonly Rectangle HeartContainer = new Rectangle(27, 0, 13, 13);
        public static readonly Rectangle WoodenBoomerang = new Rectangle(40, 0, 5, 8);
        public static readonly Rectangle Bow = new Rectangle(45, 0, 8, 16);
        public static readonly Rectangle Arrow = new Rectangle(53, 0, 5, 16);
        public static readonly Rectangle Bomb = new Rectangle(58, 0, 8, 14);
        public static readonly Rectangle Clock = new Rectangle(66, 0, 11, 16);
        public static readonly Rectangle BlueCandle = new Rectangle(77, 0, 8, 16);
        public static readonly Rectangle BluePotion = new Rectangle(85, 0, 8, 16);
        public static readonly Rectangle Fairy = new Rectangle(0, 16, 8, 16);
        public static readonly Rectangle Heart = new Rectangle(16, 16, 7, 8);
        public static readonly Rectangle Rupee = new Rectangle(30, 16, 8, 16);
        public static readonly Rectangle TriforcePiece = new Rectangle(46, 16, 10, 10);

        // Sprite sheet positions for all weapons/projectiles
        public static readonly Rectangle BoomerangProj = new Rectangle(0, 0, 8, 8);
        public static readonly Rectangle BombWeapon = new Rectangle(24, 0, 16, 16);
        public static readonly Rectangle BossProj = new Rectangle(0, 16, 8, 10);

        // Sprite sheet positions for all characters
        public static readonly Rectangle Bat = new Rectangle(0, 0, 16, 10);
        public static readonly Rectangle Gel = new Rectangle(32, 0, 8, 9);
        public static readonly Rectangle Hand = new Rectangle(48, 0, 16, 16);
        public static readonly Rectangle Skeleton = new Rectangle(80, 0, 15, 16);
        public static readonly Rectangle Zol = new Rectangle(110, 0, 14, 16);
        public static readonly Rectangle OldMan = new Rectangle(138, 0, 16, 16);
        public static readonly Rectangle RedGoriyaDown = new Rectangle(0, 16, 13, 16);
        public static readonly Rectangle RedGoriyaUp = new Rectangle(26, 16, 13, 16);
        public static readonly Rectangle RedGoriyaRight = new Rectangle(52, 16, 14, 16);
        public static readonly Rectangle RedGoriyaLeft = new Rectangle(80, 16, 14, 16);
        public static readonly Rectangle SnakeRight = new Rectangle(108, 16, 15, 15);
        public static readonly Rectangle SnakeLeft = new Rectangle(138, 16, 15, 15);
        public static readonly Rectangle DodongoDown = new Rectangle(0, 32, 15, 16);
        public static readonly Rectangle DodongoUp = new Rectangle(30, 32, 15, 16);
        public static readonly Rectangle DodongoRight = new Rectangle(60, 32, 28, 16);
        public static readonly Rectangle DodongoLeft = new Rectangle(116, 32, 28, 16);
        public static readonly Rectangle Aquamentus = new Rectangle(0, 48, 24, 32);

        // Sprite sheet positions for link sprites
        public static readonly Rectangle LinkDown = new Rectangle(0, 0, 15, 16);
        public static readonly Rectangle LinkUp = new Rectangle(30, 0, 12, 16);
        public static readonly Rectangle LinkRight = new Rectangle(54, 0, 15, 16);
        public static readonly Rectangle LinkLeft = new Rectangle(84, 0, 15, 16);
        public static readonly Rectangle LinkSwordDown = new Rectangle(0, 16, 16, 27);
        public static readonly Rectangle LinkSwordUp = new Rectangle(64, 16, 16, 28);
        public static readonly Rectangle LinkSwordRight = new Rectangle(0, 45, 27, 15);
        public static readonly Rectangle LinkSwordLeft = new Rectangle(0, 61, 27, 15);

        public static void LoadContent(ContentManager c) 
        {
            // Load sprite sheets
            BlocksSpriteSheet = c.Load<Texture2D>("blocks");
            ItemsSpriteSheet = c.Load<Texture2D>("items");
            WeaponsAndProjSpriteSheet = c.Load<Texture2D>("weaponsAndProj");
            CharactersSpriteSheet = c.Load<Texture2D>("characters");
            LinkSpriteSheet = c.Load<Texture2D>("link");

            BossEnemiesSheet = c.Load<Texture2D>("BossEnemies");
            DungeonEnemiesSheet = c.Load<Texture2D>("DungeonEnemies");
            EnemyDeathSheet = c.Load<Texture2D>("EnemyDeath");
            LinkAndItemsSheet = c.Load<Texture2D>("Link+Items");
            NpcsSheet = c.Load<Texture2D>("Npcs");
            WeaponsAndItemsSheet = c.Load<Texture2D>("weaponsAndItems");
        }
    }
}
