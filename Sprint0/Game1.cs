using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Sprites;
using System.Collections.Generic;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager g;
        private SpriteBatch sb;

        private List<IController> controllers;
        public ISprite sprite;
        public ISprite text;

        public Game1()
        {
            g = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            controllers = new List<IController>();
            controllers.Add(new KeyboardController(this));
            controllers.Add(new MouseController(this, g));

            sprite = new StillSprite();
            text = new TextSprite();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            sb = new SpriteBatch(GraphicsDevice);

            Resources.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }

            sprite.Update(g.PreferredBackBufferWidth, g.PreferredBackBufferHeight);
            text.Update(g.PreferredBackBufferWidth, g.PreferredBackBufferHeight);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            sb.Begin();
            sprite.Draw(sb, g.PreferredBackBufferWidth, g.PreferredBackBufferHeight);
            text.Draw(sb, g.PreferredBackBufferWidth, g.PreferredBackBufferHeight);
            sb.End();

            base.Draw(gameTime);
        }
    }
}
