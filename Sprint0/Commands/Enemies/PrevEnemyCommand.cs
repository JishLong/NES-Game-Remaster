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
            this.DefaultEnemyPosition = new Vector2(500, 200);
            this.index = 0;
        }
        public void Execute()
        {
            if (this.index > 0)
            {
                index--;
            }
            else
            {
                index = game.EnemyNames.Length - 1;
            }
            game.CurrentEnemy = game.EnemyFactory.GetEnemy(game.EnemyNames[index], DefaultEnemyPosition);
        }
    }
}
