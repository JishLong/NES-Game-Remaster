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

            // Item and block initialization
            CurrentItem = ItemFactory.GetInstance().GetNextItem(ItemFactory.DefaultItemPosition);
            CurrentBlock = BlockFactory.GetInstance().GetNextBlock(BlockFactory.DefaultBlockPosition);
            CurrentCharacter = CharacterFactory.GetInstance().GetNextCharacter(CharacterFactory.DefaultCharacterPosition);

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

            Player.Update();

            // Update the item, block, and enemy
            CurrentItem.Update();
            CurrentBlock.Update();
            CurrentCharacter.Update(gameTime);

            ProjectileManager.GetInstance().Update();

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

            ProjectileManager.GetInstance().Draw(SBatch);

            SBatch.End();

            base.Draw(gameTime);
        }
    }
}
