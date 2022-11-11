using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class AbstractGameState : IGameState
    {
        protected static Game1 Game;
        protected List<IController> Controllers;

        protected AbstractGameState() { }

        protected AbstractGameState(Game1 game)
        {
            Game = game;
        }

        public virtual void Draw(SpriteBatch sb)
        {

        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var controller in Controllers)
            {
                controller.Update();
            }
        }
    }
}
