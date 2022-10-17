using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Items;
using Sprint0.Player;
using Sprint0.Blocks;
using Sprint0.Blocks.Utils;
using Sprint0.Items.Utils;
using Sprint0.Characters;
using Sprint0.Projectiles;
using Sprint0.Levels;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SBatch;
        private IController Keyboard;
        public LevelManager LevelManager { get; set; }
        public IPlayer Player { get; set; }
        public IItem CurrentItem { get; set; }
        public IBlock CurrentBlock { get; set; }
        public ICharacter CurrentCharacter { get; set; }

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Player = new Player.Player(this);
            CurrentItem = ItemFactory.GetInstance().GetBeginningItem(ItemFactory.DefaultItemPosition);
            CurrentBlock = BlockFactory.GetInstance().GetBeginningBlock(BlockFactory.DefaultBlockPosition);
            CurrentCharacter = CharacterFactory.GetInstance().GetBeginningCharacter(CharacterFactory.DefaultCharacterPosition);

            LevelManager = new LevelManager();
            LevelManager.LoadLevel(Types.Level.LEVEL1);

            Keyboard = new KeyboardController(this, Player.GetStateController());

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SBatch = new SpriteBatch(GraphicsDevice);

            Resources.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            // Keyboard should be updated before everything else, especially the player
            Keyboard.Update();
            ProjectileManager.GetInstance().Update();

            LevelManager.Update(gameTime);
            Player.Update();
            CurrentItem.Update();
            CurrentBlock.Update();
            CurrentCharacter.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlueViolet);
            SBatch.Begin(samplerState: SamplerState.PointClamp);

            LevelManager.Draw(SBatch);
            Player.Draw(SBatch, Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight);
            CurrentItem.Draw(SBatch);
            CurrentBlock.Draw(SBatch);
            CurrentCharacter.Draw(SBatch);


            ProjectileManager.GetInstance().Draw(SBatch);

            SBatch.End();

            base.Draw(gameTime);
        }
    }
}
