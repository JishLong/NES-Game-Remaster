using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public abstract class AbstractGameState : IGameState
    {
        protected Game1 Game;
        protected List<IController> Controllers;

        protected AbstractGameState() { }

        protected AbstractGameState(Game1 game)
        {
            Game = game;
        }

        public abstract void Draw(SpriteBatch sb);

        public virtual void HandleClientInput(dynamic input, string id)
        {
            // if left empty, the game state will not use client input
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
