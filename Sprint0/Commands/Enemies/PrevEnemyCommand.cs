using Sprint0.Enemies.Utils;

namespace Sprint0.Commands.Enemies
{
    public class PrevEnemyCommand : ICommand
    {
        private Game1 Game;

        public PrevEnemyCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.CurrentEnemy = EnemyFactory.GetInstance().GetPrevEnemy(EnemyFactory.DefaultEnemyPosition);
        }
    }
}
