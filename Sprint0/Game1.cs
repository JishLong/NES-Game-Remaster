using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Enemies;
using Sprint0.Bosses;
using Sprint0.Bosses.Interfaces;
using Sprint0.Bosses.Utils;
using Sprint0.Npcs;
using Sprint0.Npcs.Interfaces;
using Sprint0.Npcs.Utils;
using Sprint0.Sprites;
using System.Collections.Generic;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager g;
        private SpriteBatch sb;


        private List<IController> controllers;
        public IBoss[] Bosses;

        public int currentItem { get; set; }
        public int CurrentEnemy{ get; set; }

        public IBoss CurrentBoss { get; set; }
        public BossFactory BossFactory;

        public IBoss CurrentBossProj1 { get; set; }
        public IBoss CurrentBossProj2 { get; set; }
        public IBoss CurrentBossProj3 { get; set; }

        public INpc CurrentNpc { get; set; }
        public NpcFactory NpcFactory;

        public Vector2 BossPosition;
        public Vector2 NpcPosition;

        public string[] BossTypes = new string[]
            {
                "DODONGO",
                "AQUAMENTUS",
                "AQUAMENTUSFLAME",
            };
        public string[] NpcTypes = new string[]
            {
                "OLDMAN",
                "FLAME",
                "BOMBPROJ",
            };

        public Game1()
        {
            g = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            currentItem = 0;
            CurrentEnemy = 0;
            this.BossFactory = new BossFactory();
            this.NpcFactory = new NpcFactory();
            BossPosition = new Vector2(500, 200);
            NpcPosition = new Vector2(200, 200);

            //controllers = new List<IController>
           // {
            //    new KeyboardController(this, player.GetStateController()),
           //     new MouseController(this, g)
           // };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            sb = new SpriteBatch(GraphicsDevice);

            Resources.LoadContent(Content);

            // DODONGO [0]
            // AQUAMENTUS [1]
            // AQUAMENTUS FLAMES [2]
            CurrentBoss = this.BossFactory.GetBoss(BossTypes[1], BossPosition);
            CurrentNpc = this.NpcFactory.GetNpc(NpcTypes[1], NpcPosition);
            CurrentBossProj1 = this.BossFactory.GetBoss(BossTypes[2], BossPosition);
            CurrentBossProj2 = this.BossFactory.GetBoss(BossTypes[2], BossPosition);
            CurrentBossProj3 = this.BossFactory.GetBoss(BossTypes[2], BossPosition);
        }

        protected override void Update(GameTime gameTime)
        {

            CurrentBoss.Update(gameTime);
            CurrentNpc.Update(gameTime);
            CurrentBossProj1.Update(gameTime);
            CurrentBossProj2.Update(gameTime);
            CurrentBossProj3.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            sb.Begin(samplerState: SamplerState.PointClamp);
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