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
        public static SoundEffect EnemyDeath { get; private set; }
        public static SoundEffect Dababy { get; private set; }
        public static SoundEffect MenuMusic { get; private set; }

        // Sprite sheets
        public static Texture2D BlocksSpriteSheet { get; private set; }
        public static Texture2D ItemsSpriteSheet { get; private set; }
        public static Texture2D WeaponsAndProjSpriteSheet { get; private set; }
        public static Texture2D CharactersSpriteSheet { get; private set; }
        public static Texture2D LinkSpriteSheet { get; private set; }
        public static Texture2D Level1SpriteSheet { get; private set; }

        // Sprite sheet positions for all blocks
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
        public static readonly Rectangle BorderBlock = new Rectangle(33, 33, 16, 16);

        // Sprite sheet positions for all borders
        public static readonly Rectangle Level1Border = new Rectangle(521, 11, 256, 176);

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
        public static readonly Rectangle SwordMeleeHorz = new Rectangle(61, 32, 12, 15);
        public static readonly Rectangle SwordMeleeVert = new Rectangle(74, 32, 15, 12);
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

        public static void LoadContent(ContentManager c) 
        {
            // Load font
            SmallFont = c.Load<SpriteFont>("smallFont");
            MediumFont = c.Load<SpriteFont>("mediumFont");
            LargeFont = c.Load<SpriteFont>("largeFont");

            // Load audio
            EnemyDeath = c.Load<SoundEffect>("enemyDeath");
            Dababy = c.Load<SoundEffect>("dababy");
            MenuMusic = c.Load<SoundEffect>("menuMusic");

            // Load sprite sheets
            BlocksSpriteSheet = c.Load<Texture2D>("blocks");
            ItemsSpriteSheet = c.Load<Texture2D>("items");
            WeaponsAndProjSpriteSheet = c.Load<Texture2D>("weaponsAndProj");
            CharactersSpriteSheet = c.Load<Texture2D>("characters");
            LinkSpriteSheet = c.Load<Texture2D>("link");
            Level1SpriteSheet = c.Load<Texture2D>("level1");
        }
    }
}
