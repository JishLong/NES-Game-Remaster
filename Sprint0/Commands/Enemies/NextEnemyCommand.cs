using Microsoft.Xna.Framework;

namespace Sprint0.Commands.Enemies
{
    public class NextEnemyCommand: ICommand
    {
        private Game1 game;
        private Vector2 DefaultEnemyPosition;

        public NextEnemyCommand(Game1 game)
        {
            this.game = game;
            this.DefaultEnemyPosition = new Vector2(500, 200);
        }
        public void Execute()
        {
            game.currentEnemyIndex = (game.currentEnemyIndex + 1) % game.EnemyNames.Length;
            game.CurrentEnemy = game.EnemyFactory.GetEnemy(game.EnemyNames[game.currentEnemyIndex], DefaultEnemyPosition);
        }
    }
}
