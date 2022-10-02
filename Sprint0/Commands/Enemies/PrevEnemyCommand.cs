using Microsoft.Xna.Framework;
using Sprint0.Enemies.Utils;

namespace Sprint0.Commands.Enemies
{
    public class PrevEnemyCommand : ICommand
    {
        private Game1 game;
        private Vector2 DefaultEnemyPosition;

        public PrevEnemyCommand(Game1 game)
        {
            this.game = game;
            this.DefaultEnemyPosition = new Vector2(500, 200);
        }

        public void Execute()
        {
            game.CurrentEnemy = EnemyFactory.GetInstance().GetPrevEnemy(DefaultEnemyPosition);
        }
    }
}
