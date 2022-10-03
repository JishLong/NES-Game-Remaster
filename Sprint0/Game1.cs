using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Items;
using Sprint0.Player;
using Sprint0.Bosses.Interfaces;
using Sprint0.Bosses.Utils;
using Sprint0.Sprites;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Items.Utils;
using Sprint0.Characters;

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
        public ICharacter CurrentCharacter { get; set; }

        // Boss stuff
        //public IBoss[] Bosses;
        public string[] BossTypes;
        public BossFactory BossFactory;
        public Vector2 BossPosition;
        public IBoss CurrentBossProj1 { get; set; }
        public IBoss CurrentBossProj2 { get; set; }
        public IBoss CurrentBossProj3 { get; set; }

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
            BossFactory = new BossFactory();
            BossPosition = new Vector2(600, 200);

            Keyboard = new KeyboardController(this, Player.GetStateController());

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SBatch = new SpriteBatch(GraphicsDevice);
            Resources.LoadContent(Content);


            BossTypes = new string[]
            {
                "DODONGO",
                "AQUAMENTUS",
                "AQUAMENTUSFLAME",
            };

            // Character currently instantiated here because of texture loading issue - soon to be fixed
            CurrentCharacter = CharacterFactory.GetInstance().GetNextCharacter(CharacterFactory.DefaultCharacterPosition);

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
            CurrentCharacter.Update(gameTime);

            // Boss projectiles.
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

            // Draw the item, block, and character.
            CurrentItem.Draw(SBatch);
            CurrentBlock.Draw(SBatch);
            CurrentCharacter.Draw(SBatch);

            // Boss projectiles.
            CurrentBossProj1.Draw(SBatch);
            CurrentBossProj2.Draw(SBatch);
            CurrentBossProj3.Draw(SBatch);

            SBatch.End();

            base.Draw(gameTime);
        }
    }
}