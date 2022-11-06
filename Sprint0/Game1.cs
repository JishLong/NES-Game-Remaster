using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player;
using Sprint0.Levels;
using Sprint0.GameStates;
using Sprint0.GameStates.GameStates;
using Sprint0.Input;
using System;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SBatch;

        public LevelManager LevelManager { get; private set; }
        public IPlayer Player { get; private set; }

        public IGameState CurrentState { get; set; }

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.ClientSizeChanged += OnResize;
        }

        protected override void Initialize()
        {
            LevelManager = new LevelManager();
            LevelManager.LoadLevel(Types.Level.LEVEL1);
            Player = new Player.Player(this);
            KeyboardMappings.GetInstance().InitializeMappings(this, Player);
            MouseMappings.GetInstance().InitializeMappings(this);

            // Set display resolution.
            Graphics.PreferredBackBufferWidth = Utils.GameWidth;
            Graphics.PreferredBackBufferHeight = Utils.GameHeight;
            Window.AllowUserResizing = true;
            Graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SBatch = new SpriteBatch(GraphicsDevice);

            Resources.LoadContent(Content);
            AudioManager.GetInstance().PlayLooped(Resources.MenuMusic);
            CurrentState = new MainMenuState(this);
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

        public void StartGame() 
        {
            AudioManager.GetInstance().StopLoopedAudio();
            AudioManager.GetInstance().PlayLooped(Resources.DungeonMusic);
            CurrentState = new PlayingState();
        }

        public void WinGame() 
        {
            AudioManager.GetInstance().StopLoopedAudio();
            AudioManager.GetInstance().PlayOnce(Resources.Win);
            CurrentState = new WinState();
        }

        public void PauseGame()
        {
            CurrentState = new PauseState();
        }

        public void UnpauseGame()
        {
            CurrentState = new PlayingState();
        }

        public void LoseGame() 
        {
            AudioManager.GetInstance().StopLoopedAudio();
            CurrentState = new LoseState();
        }

        public void RestartGame() 
        {
            AudioManager.GetInstance().PlayLooped(Resources.DungeonMusic);
            LevelManager.LoadLevel(Types.Level.LEVEL1);
            Player = new Player.Player(this);
            KeyboardMappings.GetInstance().InitializeMappings(this, Player);
            CurrentState = new PlayingState();
        }

        public void OnResize(Object sender, EventArgs e)
        {
            AudioManager.GetInstance().PlayOnce(Resources.HeartKeyPickup);
            Utils.UpdateWindowSize(Graphics);
        }
    }
}
