using Microsoft.Xna.Framework;

namespace Sprint0.Commands.Enemies
{
    public class NextEnemyCommand: ICommand
    {
        private Game1 game;
        private Vector2 DefaultEnemyPosition;
        int index;

        public NextEnemyCommand(Game1 game)
        {
            this.game = game;
            DefaultEnemyPosition = new Vector2(500, 200);
        }
        public void Execute()
        {
            if(game.CurrentEnemyIndex < game.EnemyNames.Length -1)
            {
                game.CurrentEnemyIndex ++;
            }
            else
            {
                game.CurrentEnemyIndex = 0;
            }
            game.CurrentEnemy = game.EnemyFactory.GetEnemy(game.EnemyNames[game.CurrentEnemyIndex], DefaultEnemyPosition);
        }
    }
}
