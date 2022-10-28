using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Levels;
using Sprint0.Player;

namespace Sprint0.GameStates.GameStates
{
    public class AbstractGameState : IGameState
    {
        protected static LevelManager LevelManager;
        protected static IPlayer Player;

        protected AbstractGameState() { }

        protected AbstractGameState(LevelManager levelManager, IPlayer player)
        {
            LevelManager ??= levelManager;
            Player ??= player;
        }

        public virtual void Draw(SpriteBatch sb)
        {

        }

        public virtual void Update(GameTime gameTime)
        {
            
        }
    }
}
