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
using Sprint0.Blocks.Utils;
using Sprint0.Items.Utils;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager g;
        private SpriteBatch sb;

        private List<IController> controllers;
        public IBoss[] Bosses;
        public IPlayer player;
        public IItem CurrentItem { get; set; }
        public IBlock CurrentBlock { get; set; }
        public IEnemy CurrentEnemy { get; set; }

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
            this.BossFactory = new BossFactory();
            this.NpcFactory = new NpcFactory();
            BossPosition = new Vector2(600, 200);
            NpcPosition = new Vector2(0, 200);

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

            CurrentEnemy = EnemyFactory.GetInstance().GetNextEnemy(new Vector2(500, 200));
            CurrentItem = ItemFactory.GetInstance().GetNextItem(new Vector2(300, 300));
            CurrentBlock = BlockFactory.GetInstance().GetNextBlock(new Vector2(200, 200));

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

            CurrentItem.Update();
            CurrentBlock.Update();
            CurrentEnemy.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlueViolet);

            sb.Begin(samplerState: SamplerState.PointClamp);
            player.Draw(sb, g.PreferredBackBufferWidth, g.PreferredBackBufferHeight);
            CurrentItem.Draw(sb);
            CurrentBlock.Draw(sb);
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