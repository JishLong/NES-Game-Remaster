using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    // Contains spritesheets and exact positions of desirable items on them
    public static class Resources
    {
        // Font
        public static SpriteFont SmallFont { get; private set; }
        public static SpriteFont MediumFont { get; private set; }
        public static SpriteFont LargeFont { get; private set; }

        // Audio   
        public static SoundEffect ArrowBoomerangShoot { get; private set; }
        public static SoundEffect BombExplode { get; private set; }
        public static SoundEffect BossNoise { get; private set; }
        public static SoundEffect Dababy { get; private set; }
        public static SoundEffect DoorOpened { get; private set; }
        public static SoundEffect DungeonMusic { get; private set; }
        public static SoundEffect EnemyDeath { get; private set; }
        public static SoundEffect EnemyTakeDamage { get; private set; }
        public static SoundEffect FlameShoot { get; private set; }
        public static SoundEffect HeartKeyPickup { get; private set; }
        public static SoundEffect ItemPickup { get; private set; }
        public static SoundEffect KeyAppear { get; private set; }
        public static SoundEffect LowHealth { get; private set; }
        public static SoundEffect MenuMusic { get; private set; }
        public static SoundEffect NewItem { get; private set; }
        public static SoundEffect PlaceBomb { get; private set; }
        public static SoundEffect PlayerDeath { get; private set; }
        public static SoundEffect PlayerTakeDamage { get; private set; }
        public static SoundEffect RupeePickup { get; private set; }
        public static SoundEffect SecretFound { get; private set; }
        public static SoundEffect ShieldBlock { get; private set; }
        public static SoundEffect Sword { get; private set; }
        public static SoundEffect SwordProj { get; private set; }
        public static SoundEffect Text { get; private set; }
        public static SoundEffect Win { get; private set; }

        // Mouse Cursor
        public static Texture2D MouseCursor { get; private set; }

        // Sprite sheets
        public static Texture2D BlocksSpriteSheet { get; private set; }
        public static Texture2D ItemsSpriteSheet { get; private set; }
        public static Texture2D WeaponsAndProjSpriteSheet { get; private set; }
        public static Texture2D CharactersSpriteSheet { get; private set; }
        public static Texture2D LinkSpriteSheet { get; private set; }
        public static Texture2D Level1SpriteSheet { get; private set; }
        public static Texture2D PausePanel { get; private set; }
        public static Texture2D ScreenCover { get; private set; }
        public static Texture2D Invisible { get; private set; }
        public static Texture2D HUDMapRoomSheet { get; private set; }
        public static Texture2D PlayerLocationSheet { get; private set; }

        // Sprite sheet positions for all blocks
        public static readonly Rectangle BlueTile = new Rectangle(0, 0, 16, 16);
        public static readonly Rectangle BlueWall = new Rectangle(16, 0, 16, 16);   
        public static readonly Rectangle BlueStatueLeft = new Rectangle(32, 0, 16, 16);
        public static readonly Rectangle BlueStatueRight = new Rectangle(48, 0, 16, 16);
        public static readonly Rectangle BlueStairs = new Rectangle(32, 16, 16, 16);
        public static readonly Rectangle BlueSand = new Rectangle(0, 16, 16, 16);
        public static readonly Rectangle GreyBricks = new Rectangle(48, 16, 16, 16);
        public static readonly Rectangle WhiteBars = new Rectangle(0, 32, 16, 16);
        public static readonly Rectangle Water = new Rectangle(16, 16, 16, 16);

        // Sprite sheet positions for all borders
        public static readonly Rectangle Level1Border = new Rectangle(521, 11, 256, 176);

        // Sprite sheet positions for all doors
        public static readonly Rectangle UpUnlockedDoorWall = new Rectangle(848, 11, 32, 16);
        public static readonly Rectangle UpUnlockedDoorWay = new Rectangle(848, 27, 32, 16);
        public static readonly Rectangle LeftUnlockedDoorWay = new Rectangle(864, 44, 16, 32);
        public static readonly Rectangle LeftUnlockedDoorWall = new Rectangle(848, 44, 16, 32);
        public static readonly Rectangle RightUnlockedDoorWay = new Rectangle(848, 77, 16, 32);
        public static readonly Rectangle RightUnlockedDoorWall = new Rectangle(864, 77, 16, 32);
        public static readonly Rectangle DownUnlockedDoorWay = new Rectangle(848, 110, 32, 16);
        public static readonly Rectangle DownUnlockedDoorWall = new Rectangle(848, 126, 32, 16);

        public static readonly Rectangle UpWallDoor = new Rectangle(815, 11, 32, 32);
        public static readonly Rectangle LeftWallDoor = new Rectangle(815, 44, 32, 32);
        public static readonly Rectangle RightWallDoor = new Rectangle(815, 77, 32, 32);
        public static readonly Rectangle DownWallDoor = new Rectangle(815, 110, 32, 32);

        public static readonly Rectangle UpEventLockedDoor = new Rectangle(914, 11, 32, 32);
        public static readonly Rectangle LeftEventLockedDoor = new Rectangle(914, 44, 32, 32);
        public static readonly Rectangle RightEventLockedDoor = new Rectangle(914, 77, 32, 32);
        public static readonly Rectangle DownEventLockedDoor = new Rectangle(914, 110, 32, 32);

        public static readonly Rectangle UpKeyLockedDoor = new Rectangle(881, 11, 32, 32);
        public static readonly Rectangle LeftKeyLockedDoor = new Rectangle(881, 44, 32, 32);
        public static readonly Rectangle RightKeyLockedDoor = new Rectangle(881, 77, 32, 32);
        public static readonly Rectangle DownKeyLockedDoor = new Rectangle(881, 110, 32, 32);

        public static readonly Rectangle UpSecretDoorWall = new Rectangle(947, 11, 32, 16);
        public static readonly Rectangle UpSecretDoorWay = new Rectangle(947, 27, 32, 16);
        public static readonly Rectangle LeftSecretDoorWall = new Rectangle(947, 44, 16, 32);
        public static readonly Rectangle LeftSecretDoorWay = new Rectangle(963, 44, 16, 32);
        public static readonly Rectangle RightSecretDoorWall = new Rectangle(963, 77, 16, 32);
        public static readonly Rectangle RightSecretDoorWay = new Rectangle(947, 77, 16, 32);
        public static readonly Rectangle DownSecretDoorWall = new Rectangle(947, 126, 32, 16);
        public static readonly Rectangle DownSecretDoorWay = new Rectangle(947, 110, 32, 16);

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
        public static readonly Rectangle WoodenSword = new Rectangle(0, 48, 7, 16);

        // Sprite sheet positions for all weapons/projectiles
        public static readonly Rectangle BoomerangProj = new Rectangle(0, 0, 8, 8);
        public static readonly Rectangle BombProj = new Rectangle(24, 0, 16, 16);
        public static readonly Rectangle BombExplosionParticle = new Rectangle(40, 0, 16, 16);
        public static readonly Rectangle ArrowProjVert = new Rectangle(0, 16, 5, 16);
        public static readonly Rectangle ArrowProjHorz = new Rectangle(10, 16, 16, 5);
        public static readonly Rectangle BlueArrowProjVert = new Rectangle(5, 16, 5, 16);
        public static readonly Rectangle BlueArrowProjHorz = new Rectangle(10, 21, 16, 5);
        public static readonly Rectangle ArrowExplosionParticle = new Rectangle(26, 20, 8, 8);
        public static readonly Rectangle FlameProj = new Rectangle(34, 16, 16, 16);
        public static readonly Rectangle BossProj = new Rectangle(50, 16, 8, 10);
        public static readonly Rectangle CharacterDeathParticle = new Rectangle(0, 32, 15, 16);
        public static readonly Rectangle SwordMeleeHorz = new Rectangle(69, 32, 12, 7);
        public static readonly Rectangle SwordMeleeVert = new Rectangle(61, 32, 7, 12);
        public static readonly Rectangle SwordProjHorz = new Rectangle(14, 48, 16, 7);
        public static readonly Rectangle SwordProjVert = new Rectangle(0, 48, 7, 16);
        public static readonly Rectangle SwordFlameProjUp = new Rectangle(46, 48, 8, 10);
        public static readonly Rectangle SwordFlameProjDown = new Rectangle(62, 48, 8, 10);

        // Sprite sheet positions for all characters
        public static readonly Rectangle Bat = new Rectangle(0, 0, 16, 10);
        public static readonly Rectangle Gel = new Rectangle(32, 0, 8, 9);
        public static readonly Rectangle Hand = new Rectangle(48, 0, 16, 16);
        public static readonly Rectangle Skeleton = new Rectangle(80, 0, 15, 16);
        public static readonly Rectangle Zol = new Rectangle(94, 0, 14, 16);
        public static readonly Rectangle OldMan = new Rectangle(122, 0, 16, 16);
        public static readonly Rectangle RedGoriyaDown = new Rectangle(0, 16, 13, 16);
        public static readonly Rectangle RedGoriyaUp = new Rectangle(26, 16, 13, 16);
        public static readonly Rectangle RedGoriyaSide = new Rectangle(52, 16, 14, 16);
        public static readonly Rectangle Snake = new Rectangle(80, 16, 15, 15);
        public static readonly Rectangle DodongoDown = new Rectangle(0, 32, 15, 16);
        public static readonly Rectangle DodongoUp = new Rectangle(30, 32, 15, 16);
        public static readonly Rectangle DodongoSide = new Rectangle(60, 32, 28, 16);
        public static readonly Rectangle Aquamentus = new Rectangle(0, 48, 24, 32);
        public static readonly Rectangle BladeTrap = new Rectangle(96, 48, 16, 16);
        public static readonly Rectangle Flame = new Rectangle(112, 48, 16, 16);

        // Sprite sheet positions for link sprites
        public static readonly Rectangle LinkDown = new Rectangle(0, 0, 16, 16);
        public static readonly Rectangle LinkUp = new Rectangle(32, 0, 16, 16);
        public static readonly Rectangle LinkSideways = new Rectangle(64, 0, 16, 16);
        public static readonly Rectangle LinkSwordDown = new Rectangle(0, 16, 16, 27);
        public static readonly Rectangle LinkSwordUp = new Rectangle(64, 16, 16, 28);
        public static readonly Rectangle LinkSwordSideways = new Rectangle(0, 44, 27, 16);
        public static readonly Rectangle LinkPickUpItem = new Rectangle(108, 44, 14, 16);

        // Sprite sheet positions for mouse cursor
        public static readonly Rectangle CursorFrame1 = new Rectangle(0, 0, 12, 12);
        public static readonly Rectangle CursorFrame2 = new Rectangle(12, 0, 12, 12);
        public static readonly Rectangle CursorFrame3 = new Rectangle(24, 0, 12, 12);
        public static readonly Rectangle CursorFrame4 = new Rectangle(36, 0, 12, 12);

        // Sprite sheet positions for HUD and map elements
        public static readonly Rectangle HUDMapRoom = new Rectangle(0, 0, 7, 3);
        public static readonly Rectangle PlayerLocation = new Rectangle(0, 0, 3, 3);

        public static void LoadContent(ContentManager c) 
        {
            // Load font
            SmallFont = c.Load<SpriteFont>("Fonts/smallFont");
            MediumFont = c.Load<SpriteFont>("Fonts/mediumFont");
            LargeFont = c.Load<SpriteFont>("Fonts/largeFont");

            // Load audio
            ArrowBoomerangShoot = c.Load<SoundEffect>("Audio/arrowBoomerang");
            BombExplode = c.Load<SoundEffect>("Audio/bomb");
            BossNoise = c.Load<SoundEffect>("Audio/bossNoise");
            Dababy = c.Load<SoundEffect>("Audio/dababy");
            DoorOpened = c.Load<SoundEffect>("Audio/doorOpened");
            DungeonMusic = c.Load<SoundEffect>("Audio/dungeonMusic");
            EnemyDeath = c.Load<SoundEffect>("Audio/enemyDeath");
            EnemyTakeDamage = c.Load<SoundEffect>("Audio/enemyTakeDamage");
            FlameShoot = c.Load<SoundEffect>("Audio/flame");
            HeartKeyPickup = c.Load<SoundEffect>("Audio/heartKeyPickup");
            ItemPickup = c.Load<SoundEffect>("Audio/itemPickup");
            KeyAppear = c.Load<SoundEffect>("Audio/keyAppear");
            LowHealth = c.Load<SoundEffect>("Audio/lowHealth");
            MenuMusic = c.Load<SoundEffect>("Audio/menuMusic");
            NewItem = c.Load<SoundEffect>("Audio/newItem");
            PlaceBomb = c.Load<SoundEffect>("Audio/placeBomb");
            PlayerDeath = c.Load<SoundEffect>("Audio/playerDeath");
            PlayerTakeDamage = c.Load<SoundEffect>("Audio/playerTakeDamage");
            RupeePickup = c.Load<SoundEffect>("Audio/rupeePickup");
            SecretFound = c.Load<SoundEffect>("Audio/secretFound");
            ShieldBlock = c.Load<SoundEffect>("Audio/shieldBlock");
            Sword = c.Load<SoundEffect>("Audio/sword"); 
            SwordProj = c.Load<SoundEffect>("Audio/swordProj");
            Text = c.Load<SoundEffect>("Audio/text");
            Win = c.Load<SoundEffect>("Audio/win");

            // Load sprite sheets
            BlocksSpriteSheet = c.Load<Texture2D>("Images/blocks");
            ItemsSpriteSheet = c.Load<Texture2D>("Images/items");
            WeaponsAndProjSpriteSheet = c.Load<Texture2D>("Images/weaponsAndProj");
            CharactersSpriteSheet = c.Load<Texture2D>("Images/characters");
            LinkSpriteSheet = c.Load<Texture2D>("Images/link");
            Level1SpriteSheet = c.Load<Texture2D>("Images/level1");
            PausePanel = c.Load<Texture2D>("Images/pausePanel");
            ScreenCover = c.Load<Texture2D>("Images/screenCover");
            MouseCursor = c.Load<Texture2D>("Images/cursor");
            Invisible = c.Load<Texture2D>("Images/invisible");
            HUDMapRoomSheet = c.Load<Texture2D>("Images/HUDMapRoom");
            PlayerLocationSheet = c.Load<Texture2D>("Images/PlayerLocation");
        }

        // Why you looking down here? Tryna see how many lines of code this class is? Go back to the top >:(
    }
}
