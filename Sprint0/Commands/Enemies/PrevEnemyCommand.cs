using Microsoft.Xna.Framework;

namespace Sprint0.Commands.Enemies
{
    public class PrevEnemyCommand : ICommand
    {
        private Game1 game;
        private Vector2 DefaultEnemyPosition;
        int index;

        public PrevEnemyCommand(Game1 game)
        {
            this.game = game;
            DefaultEnemyPosition = new Vector2(500, 200);
            index = 0;
        }
        public void Execute()
        {
            if(game.CurrentEnemyIndex > 0)
            {
                game.CurrentEnemyIndex --;
            }
            else
            {
                game.CurrentEnemyIndex = game.EnemyNames.Length -1;
            }
            game.CurrentEnemy = game.EnemyFactory.GetEnemy(game.EnemyNames[game.CurrentEnemyIndex], DefaultEnemyPosition);
        }
    }
}
