using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Items;
using Sprint0.Player;
using Sprint0.Bosses.Interfaces;
using Sprint0.Bosses.Utils;
using Sprint0.Npcs.Interfaces;
using Sprint0.Npcs.Utils;
using Sprint0.Sprites;
using Sprint0.Enemies.Interfaces;
using Sprint0.Enemies.Utils;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Items.Utils;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SBatch;
        private IController Keyboard;

        public IPlayer Player;

        // Current instantiations of items, blocks, enemies
        public IItem CurrentItem { get; set; }
        public IBlock CurrentBlock { get; set; }
        public IEnemy CurrentEnemy { get; set; }

        public int currentEnemyIndex { get; set; }
        public int currentCharacterIndex { get; set; }

        public string[] EnemyNames;
        public IEnemy CurrentEnemy{ get; set; }
        public EnemyFactory EnemyFactory;
        public Vector2 DefaultEnemyPosition;

        //public int CurrentEnemy{ get; set; }

        public string[] BossTypes;
        public IBoss CurrentBoss { get; set; }
        public BossFactory BossFactory;
        public Vector2 BossPosition;
        public IBoss CurrentBossProj1 { get; set; }
        public IBoss CurrentBossProj2 { get; set; }
        public IBoss CurrentBossProj3 { get; set; }

        // NPC stuff
        public string[] NpcTypes;
        public INpc CurrentNpc { get; set; }
        public NpcFactory NpcFactory;
        public Vector2 NpcPosition;

        public ICharacter[] characters;
        public Vector2 CharacterPosition;

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {       
            // Player initialization
            Player = new Player.Player(this);
            LinkSpriteSheet.Init(this);
            
            // Item and block initialization
            CurrentItem = ItemFactory.GetInstance().GetNextItem(ItemFactory.DefaultItemPosition);
            CurrentBlock = BlockFactory.GetInstance().GetNextBlock(BlockFactory.DefaultBlockPosition);

            // Boss and NPC stuff
            this.BossFactory = new BossFactory();
            this.NpcFactory = new NpcFactory();
            BossPosition = new Vector2(600, 200);
            NpcPosition = new Vector2(0, 200);
            CharacterPosition = new Vector2(500, 200);

            currentItem = 0;
            currentBlock = 0;
            currentEnemyIndex = 0;
            currentCharacterIndex = 0;
            Keyboard = new KeyboardController(this, Player.GetStateController());

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SBatch = new SpriteBatch(GraphicsDevice);
            Resources.LoadContent(Content);

            // Enemy currently instantiated here because of texture loading issue - soon to be fixed
            CurrentEnemy = EnemyFactory.GetInstance().GetNextEnemy(EnemyFactory.DefaultEnemyPosition);

            // Boss and NPC stuff
            BossTypes = new string[]
            {
                "DODONGO",
                "AQUAMENTUS",
                "AQUAMENTUSFLAME",
            };
            NpcTypes = new string[]
            {
                "OLDMAN",
                "FLAME",
                "BOMBPROJ",
            };

            EnemyNames= new string[]
            {
                "SKELETON",
                "BAT",
                "HAND",
                "GEL",
                "RED_GORIYA",
                "ZOL"
            };

            characters = new ICharacter[] {
                    new OldMan(CharacterPosition),
                    new Flame(CharacterPosition),
                    new BombProj(CharacterPosition),
                    new Skeleton(CharacterPosition),
                    new Bat(CharacterPosition),
                    new Hand(CharacterPosition),
                    new Gel(CharacterPosition),
                    new RedGoriya(CharacterPosition),
                    new Zol(CharacterPosition),
                    new Dodongo(CharacterPosition),
                    new Aquamentus(CharacterPosition)
            };

            items = new IItem[] {
                    new Arrow(400, 200), new BlueCandle(400, 200),
                    new BluePotion(400, 200),
                    new Bomb(400, 200),
                    new Bow(400, 200),
                    new Clock(400, 200),
                    new Compass(400, 200),
                    new Fairy(400, 200),
                    new Heart(400, 200),
                    new HeartContainer(400, 200),
                    new Key(400, 200),
                    new Map(400, 200),
                    new Rupee(400, 200),
                    new TriforcePiece(400, 200),
                    new WoodenBoomerang(400, 200)
            };

            blocks = new IBlock[] {
                     new BlueGap(200, 200),
                     new BlueSand(200, 200),
                     new BlueStairs(200, 200),
                     new BlueStatueLeft(200, 200),
                     new BlueStatueRight(200, 200),
                     new BlueTile(200, 200),
                     new BlueWall(200, 200),
                     new FireBlock(200, 200),
                     new GreyBricks(200, 200),
                     new LadderBlock(200, 200),
                     new WhiteBars(200, 200),
            };

            CurrentEnemy = this.EnemyFactory.GetEnemy(EnemyNames[0], DefaultEnemyPosition);

            CurrentBoss = this.BossFactory.GetBoss(BossTypes[1], BossPosition);
            CurrentNpc = this.NpcFactory.GetNpc(NpcTypes[1], NpcPosition);
        }

        protected override void Update(GameTime gameTime)
        {
            // Keyboard should be updated before everything else, especially the player
            Keyboard.Update();

            Player.Update();

            // Update the item, block, and enemy
            CurrentItem.Update();
            CurrentBlock.Update();
            CurrentEnemy.Update(gameTime);

            // CurrentBoss.Update(gameTime);
            // CurrentNpc.Update(gameTime);

            items[currentItem].Update();
            blocks[currentBlock].Update();
            characters[currentCharacterIndex].Update(gameTime);
            CurrentEnemy.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlueViolet);
            SBatch.Begin(samplerState: SamplerState.PointClamp);

            Player.Draw(SBatch, Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight);

            // Draw the item, block, and enemy
            CurrentItem.Draw(SBatch);
            CurrentBlock.Draw(SBatch);
            CurrentEnemy.Draw(SBatch);

            // Boss and NPC stuff
            CurrentBossProj1.Draw(SBatch);
            CurrentBossProj2.Draw(SBatch);
            CurrentBossProj3.Draw(SBatch);
            CurrentBoss.Draw(SBatch);
            CurrentNpc.Draw(SBatch);

            sb.Begin(samplerState: SamplerState.PointClamp);
            player.Draw(sb, g.PreferredBackBufferWidth, g.PreferredBackBufferHeight);
            items[currentItem].Draw(sb);
            blocks[currentBlock].Draw(sb);
            // CurrentEnemy.Draw(sb);
            // CurrentBoss.Draw(sb);
            // CurrentNpc.Draw(sb);
            characters[currentCharacterIndex].Draw(sb);
            sb.End();

            base.Draw(gameTime);
        }
    }
}
