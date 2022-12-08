using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player;
using Sprint0.Levels;
using Sprint0.GameStates;
using Sprint0.GameStates.GameStates;
using Sprint0.Input;
using System;
using Microsoft.Xna.Framework.Input;
using Sprint0.Sprites;
using Sprint0.WebSockets;
using Sprint0.GameModes;
using Sprint0.Assets;
using Sprint0.Assets.DefaultAssets;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager Graphics;
        private readonly GameWindow GameWindow;
        private RenderTarget2D ResizableArea;
        private SpriteBatch SBatch;
        private ISprite MouseSprite;
        private WSClient wsClient;

        public LevelManager LevelManager { get; private set; }
        public PlayerManager PlayerManager { get; private set; }

        public IGameState CurrentState { get; set; }

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            GameWindow = new();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.ClientSizeChanged += OnResize;
            wsClient = new WSClient(this);
        }

        protected override void Initialize()
        {
            GameModeManager.GetInstance().Initialize();

            MouseSprite = new MouseCursorSprite();

            // Set display resolution.
            Graphics.PreferredBackBufferWidth = GameWindow.DefaultScreenWidth;
            Graphics.PreferredBackBufferHeight = GameWindow.DefaultScreenHeight;
            Window.AllowUserResizing = true;
            Graphics.ApplyChanges();
            GameWindow.UpdateWindowSize(Graphics);
            ResizableArea = new(GraphicsDevice, GameWindow.DefaultScreenWidth, GameWindow.DefaultScreenHeight);

            wsClient.Connect();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SBatch = new SpriteBatch(GraphicsDevice);

            AssetManager.LoadContent(Content);
            AudioManager.GetInstance().PlayLooped(AudioMappings.GetInstance().MusicMenu);
            Mouse.SetCursor(MouseCursor.FromTexture2D((AssetManager.DefaultImageAssets as DefaultImageAssets).Invisible, 0, 0));

            GameModeManager.GetInstance().Initialize();
            CreateNewGame(false);

            CurrentState = new MainMenuState(this);
        }

        protected override void Update(GameTime gameTime)
        {
            CurrentState.Update(gameTime);
            MouseSprite.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Make an invisible area to render everything onto
            GraphicsDevice.SetRenderTarget(ResizableArea);
            GraphicsDevice.Clear(Color.Black);

            // Render everything onto the invisible area - not to the screen
            SBatch.Begin(sortMode: SpriteSortMode.BackToFront, samplerState: SamplerState.PointClamp);

            CurrentState.Draw(SBatch);
            wsClient.DrawGameCode(SBatch);

            SBatch.End();

            // Render everything onto the screen at once, scaled according to the screen size and centered on-screen
            GraphicsDevice.SetRenderTarget(null);
            SBatch.Begin(samplerState: SamplerState.PointClamp);

            SBatch.Draw(ResizableArea, GameWindow.GetCenteredArea(), Color.White);
            MouseSprite.Draw(SBatch, Mouse.GetState().Position.ToVector2(), Color.White, 0f);

            SBatch.End();

            base.Draw(gameTime);
        }

        public void CreateNewGame(bool resetPlayers = true) 
        {
            GameModeManager.GetInstance().Initialize();
            LevelManager = new LevelManager();
            LevelManager.LoadLevel(Types.Level.LEVEL1);
            //LevelManager.LoadLevel(Types.Level.LEVEL2);
            MouseMappings.GetInstance().InitializeMappings(this);
            if (resetPlayers) PlayerManager.ResetPlayers();
            PlayerManager = new PlayerManager(this);
        }

        public void OnResize(object sender, EventArgs e)
        {
            GameWindow.UpdateWindowSize(Graphics);
        }
    }
}
