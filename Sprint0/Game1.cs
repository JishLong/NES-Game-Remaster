using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player;
using Sprint0.Levels;
using static Sprint0.Utils;
using Sprint0.GameStates;
using Sprint0.GameStates.GameStates;
using Sprint0.Input;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SBatch;

        public LevelManager LevelManager { get; private set; }

        public IGameState CurrentState { get; set; }

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            

            LevelManager = new LevelManager();
            LevelManager.LoadLevel(Types.Level.LEVEL1);
            IPlayer Player = new Player.Player(this);
            KeyboardMappings.GetInstance().InitializeMappings(this, Player);
            MouseMappings.GetInstance().InitializeMappings(this);

            CurrentState = new PlayingState(LevelManager, Player);

            // Set display resolution.
            Graphics.PreferredBackBufferWidth = 256 * (int) GameScale;
            Graphics.PreferredBackBufferHeight = 176 * (int) GameScale;
            Graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SBatch = new SpriteBatch(GraphicsDevice);

            Resources.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            CurrentState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            SBatch.Begin(samplerState: SamplerState.PointClamp);

            CurrentState.Draw(SBatch);
        
            SBatch.End();
            base.Draw(gameTime);
        }
    }
}
