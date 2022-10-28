using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Levels;
using Sprint0.Player;
using Sprint0.Projectiles.Tools;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class PlayingState : AbstractGameState
    {
        private static List<IController> Controllers;

        public PlayingState() { }

        public PlayingState(LevelManager levelManager, IPlayer player) : base(levelManager, player)
        {
            Controllers ??= new List<IController>()
            {
                new KeyboardController(KeyboardMappings.GetInstance().PlayingStateMappings),
                new MouseController(MouseMappings.GetInstance().PlayingStateMappings),
                new ProjectileController(LevelManager),
                new CollisionController(LevelManager, Player)
            };
        }

        public override void Draw(SpriteBatch sb)
        {
            LevelManager.Draw(sb);
            Player.Draw(sb);
        }

        public override void Update(GameTime gameTime)
        {
            LevelManager.Update(gameTime);
            Player.Update();
            foreach (var controller in Controllers)
            {
                controller.Update();
            }
        }
    }
}
