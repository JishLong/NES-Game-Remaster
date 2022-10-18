using Sprint0.Characters.Enemies;
using Sprint0.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.Characters
{
    public class EnemyTakeDamageCommand : ICommand
    {
        private readonly IEnemy Enemy;
        private readonly int Damage;

        public EnemyTakeDamageCommand(IEnemy enemy, int damage)
        {
            Enemy = enemy;
            Damage = damage;
        }

        public void Execute()
        {
            Enemy.TakeDamage(Damage);
        }
    }
}
