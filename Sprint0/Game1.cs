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

        // Boss stuff
        public IBoss[] Bosses;
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

            CurrentBoss = this.BossFactory.GetBoss(BossTypes[0], BossPosition);
            CurrentNpc = this.NpcFactory.GetNpc(NpcTypes[1], NpcPosition);

            // For Aquamentus flames - need to refactor later
            CurrentBossProj1 = this.BossFactory.GetBoss(BossTypes[2], BossPosition);
            CurrentBossProj2 = this.BossFactory.GetBoss(BossTypes[2], BossPosition);
            CurrentBossProj3 = this.BossFactory.GetBoss(BossTypes[2], BossPosition);
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

            // Boss and NPC stuff
            CurrentBoss.Update(gameTime);
            CurrentNpc.Update(gameTime);
            CurrentBossProj1.Update(gameTime);
            CurrentBossProj2.Update(gameTime);
            CurrentBossProj3.Update(gameTime);
            Player.Update();

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

            SBatch.End();

            base.Draw(gameTime);
        }
    }
}
