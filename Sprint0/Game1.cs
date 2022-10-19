using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Player;
using Sprint0.Projectiles;
using Sprint0.Levels;
using Sprint0.Collision;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SBatch;

        private IController Keyboard, Mouse;
        private CollisionDetector Collisions;
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
            // Temp testing Aquamentus projectile collisions
            LevelManager.CurrentLevel.CurrentRoom.AddCharacterToRoom(Types.Character.AQUAMENTUS, new Vector2(200, 200));

            Player = new Player.Player(this);   

            Keyboard = new KeyboardController(this, Player);
            Mouse = new MouseController(this);

            Collisions = new CollisionDetector(LevelManager.CurrentLevel.CurrentRoom, Player);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SBatch = new SpriteBatch(GraphicsDevice);

            Resources.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            // Input should be updated before everything else, especially the player
            Keyboard.Update();
            Mouse.Update();

            

            LevelManager.Update(gameTime);

            ProjectileManager.GetInstance().Update();
      
            Player.Update();

            // Best for collisions to be updated last so that every collision for this frame is cleaned up
            Collisions.CurrentRoom = LevelManager.CurrentLevel.CurrentRoom;
            Collisions.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlueViolet);
            SBatch.Begin(samplerState: SamplerState.PointClamp);

            LevelManager.Draw(SBatch);

            ProjectileManager.GetInstance().Draw(SBatch);

            Player.Draw(SBatch);
        
            SBatch.End();

            base.Draw(gameTime);
        }
    }
}
