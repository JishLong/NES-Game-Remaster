using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Player;
using Sprint0.Levels;
using Sprint0.Collision;
using static Sprint0.Utils;
using Sprint0.Projectiles.Tools;
using System.Collections.Generic;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SBatch;

        private List<IController> Controllers;
        public LevelManager LevelManager { get; set; }
        public IPlayer Player { get; set; }

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
            Player = new Player.Player(this);
            Controllers = new List<IController>()
            {
                new KeyboardController(this, Player),
                new MouseController(this),
                new ProjectileController(LevelManager),
                new CollisionController(LevelManager, Player)
            };

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
            LevelManager.Update(gameTime);   
            Player.Update();
            foreach (var controller in Controllers)
            {
                controller.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            SBatch.Begin(samplerState: SamplerState.PointClamp);

            LevelManager.Draw(SBatch);
            Player.Draw(SBatch);
        
            SBatch.End();
            base.Draw(gameTime);
        }
    }
}
