using Sprint0.Enemies.Utils;

namespace Sprint0.Commands.Enemies
{
    public class NextEnemyCommand: ICommand
    {
        private Game1 Game;

        public NextEnemyCommand(Game1 game)
        {
            Game = game;
        }
        public void Execute()
        {
            Game.CurrentEnemy = EnemyFactory.GetInstance().GetNextEnemy(EnemyFactory.DefaultEnemyPosition);
        }
    }
}
