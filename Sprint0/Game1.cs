﻿using Microsoft.Xna.Framework;
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

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SBatch;
        private ISprite MouseSprite;
        private WSClient wsClient;

        public LevelManager LevelManager { get; private set; }
        public PlayerManager PlayerManager { get; private set; }

        public IGameState CurrentState { get; set; }

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.ClientSizeChanged += OnResize;
            wsClient = new WSClient(this);
        }

        protected override void Initialize()
        {
            CreateNewGame(false);
            PlayerManager = new PlayerManager(this);
            MouseSprite = new MouseCursorSprite();

            // Set display resolution.
            Graphics.PreferredBackBufferWidth = Utils.GameWidth;
            Graphics.PreferredBackBufferHeight = Utils.GameHeight;
            Window.AllowUserResizing = true;
            Graphics.ApplyChanges();
            wsClient.Connect();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SBatch = new SpriteBatch(GraphicsDevice);

            Resources.LoadContent(Content);
            AudioManager.GetInstance().PlayLooped(Resources.MenuMusic);
            Mouse.SetCursor(MouseCursor.FromTexture2D(Resources.Invisible, 0, 0));

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
            GraphicsDevice.Clear(Color.Black);
            SBatch.Begin(sortMode: SpriteSortMode.BackToFront, samplerState: SamplerState.PointClamp);

            CurrentState.Draw(SBatch);
            MouseSprite.Draw(SBatch, Mouse.GetState().Position.ToVector2() - new Vector2(15, 175), Color.White, 0f);
            wsClient.DrawGameCode(SBatch);

            SBatch.End();
            base.Draw(gameTime);
        }

        public void CreateNewGame(bool resetPlayers = true) 
        {
            LevelManager = new LevelManager();
            LevelManager.LoadLevel(Types.Level.LEVEL1);
            MouseMappings.GetInstance().InitializeMappings(this);
            if (resetPlayers) PlayerManager.ResetPlayers();
        }

        public void OnResize(Object sender, EventArgs e)
        {
            AudioManager.GetInstance().PlayOnce(Resources.HeartKeyPickup);
            Utils.UpdateWindowSize(Graphics);
        }
    }
}
