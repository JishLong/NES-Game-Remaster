using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Items;
using Sprint0.Player;
using Sprint0.Enemies;
using Sprint0.Bosses;
using Sprint0.Bosses.Interfaces;
using Sprint0.Bosses.Utils;
using Sprint0.Npcs;
using Sprint0.Npcs.Interfaces;
using Sprint0.Npcs.Utils;
using Sprint0.Sprites;
using System.Collections.Generic;
using Sprint0.Enemies.Interfaces;
using Sprint0.Enemies.Utils;
using Sprint0.Blocks;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager g;
        private SpriteBatch sb;

        private List<IController> controllers;
        public IBoss[] Bosses;
        public IPlayer player;

        public IItem[] items;
        public IBlock[] blocks;
        public int currentItem { get; set; }
        public int currentBlock { get; set; }

        public int currentEnemyIndex { get; set; }

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

        public string[] NpcTypes;
        public INpc CurrentNpc { get; set; }
        public NpcFactory NpcFactory;
        public Vector2 NpcPosition;

 

        public Game1()
        {
            g = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            player = new Player.Player(this);
            LinkSpriteSheet.Init(this);
            currentItem = 0;
            this.BossFactory = new BossFactory();
            this.NpcFactory = new NpcFactory();
            BossPosition = new Vector2(600, 200);
            NpcPosition = new Vector2(0, 200);

            currentItem = 0;
            currentBlock = 0;
            currentEnemyIndex = 0;

            this.EnemyFactory = new EnemyFactory();
            DefaultEnemyPosition = new Vector2(500, 200);

            controllers = new List<IController>
            {
                new KeyboardController(this, player.GetStateController()),
                new MouseController(this)
            };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            sb = new SpriteBatch(GraphicsDevice);

            Resources.LoadContent(Content);
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

            // For Aquamentus flames - need to refactor later
            CurrentBossProj1 = this.BossFactory.GetBoss(BossTypes[2], BossPosition);
            CurrentBossProj2 = this.BossFactory.GetBoss(BossTypes[2], BossPosition);
            CurrentBossProj3 = this.BossFactory.GetBoss(BossTypes[2], BossPosition);
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            // controllers MUST be updated before player
            player.Update();

            CurrentBoss.Update(gameTime);
            CurrentNpc.Update(gameTime);
            CurrentBossProj1.Update(gameTime);
            CurrentBossProj2.Update(gameTime);
            CurrentBossProj3.Update(gameTime);
            player.Update();

            items[currentItem].Update();
            blocks[currentBlock].Update();
            CurrentEnemy.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlueViolet);

            sb.Begin(samplerState: SamplerState.PointClamp);
            player.Draw(sb, g.PreferredBackBufferWidth, g.PreferredBackBufferHeight);
            items[currentItem].Draw(sb);
            blocks[currentBlock].Draw(sb);
            CurrentEnemy.Draw(sb);
            CurrentBossProj1.Draw(sb);
            CurrentBossProj2.Draw(sb);
            CurrentBossProj3.Draw(sb);
            CurrentBoss.Draw(sb);
            CurrentNpc.Draw(sb);
            sb.End();

            base.Draw(gameTime);
        }
    }
}