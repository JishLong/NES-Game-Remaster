using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Items;
using Sprint0.Player;
using Sprint0.Sprites;
using System.Collections.Generic;
using Sprint0.Enemies.Interfaces;
using Sprint0.Enemies.Utils;
using Sprint0.Blocks;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager g;
        private SpriteBatch sb;

        private List<IController> controllers;
        public IPlayer player;

        public IItem[] items;
        public IBlock[] blocks;
        public int currentItem { get; set; }
        public int currentBlock { get; set; }

        public string[] EnemyNames;
        public IEnemy CurrentEnemy{ get; set; }
        public EnemyFactory EnemyFactory;
        public Vector2 DefaultEnemyPosition;

        public Game1()
        {
            g = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            player = new Player.Player(this);
            LinkSpriteSheet.Init(this);

            currentItem = 0;
            currentBlock = 0;

            this.EnemyFactory = new EnemyFactory();
            DefaultEnemyPosition = new Vector2(500, 200);

            controllers = new List<IController>
            {
                new KeyboardController(this, player.GetStateController()),
                new MouseController(this, g)
            };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            sb = new SpriteBatch(GraphicsDevice);

            Resources.LoadContent(Content);

            EnemyNames= new string[]
            {
                "SKELETON",
                "BAT",
                "HAND",
            };

            items = new IItem[] {
                    new Arrow(400, 200), new BlueCandle(400, 200),
                    new BluePotion(400, 200),
                    new Bomb(400, 200),
                    new Bow(400, 200),
                    new Clock(400, 200),
                    new Compass(400, 200),
                    new Fairy(400, 200),
                    new Heart(400, 200),
                    new HeartContainer(400, 200),
                    new Key(400, 200),
                    new Map(400, 200),
                    new Rupee(400, 200),
                    new TriforcePiece(400, 200),
                    new WoodenBoomerang(400, 200)
            };

            blocks = new IBlock[] {
                     new BlueGap(200, 200),
                     new BlueSand(200, 200),
                     new BlueStairs(200, 200),
                     new BlueStatueLeft(200, 200),
                     new BlueStatueRight(200, 200),
                     new BlueTile(200, 200),
                     new BlueWall(200, 200),
                     new FireBlock(200, 200),
                     new GreyBricks(200, 200),
                     new LadderBlock(200, 200),
                     new WhiteBars(200, 200),
            };

            CurrentEnemy = this.EnemyFactory.GetEnemy(EnemyNames[0], DefaultEnemyPosition);
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }

            player.Update();

            items[currentItem].Update();
            blocks[currentBlock].Update();
            CurrentEnemy.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlueViolet);

            player.Draw(sb, g.PreferredBackBufferWidth, g.PreferredBackBufferHeight);

            sb.Begin(samplerState: SamplerState.PointClamp);
            items[currentItem].Draw(sb);
            blocks[currentBlock].Draw(sb);
            CurrentEnemy.Draw(sb);
            sb.End();

            base.Draw(gameTime);
        }
    }
}
