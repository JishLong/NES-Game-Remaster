using Sprint0.Characters.Bosses;

namespace Sprint0.Commands.Characters
{
    public class BossTakeDamageCommand
    {
        private readonly IBoss Boss;
        private readonly int Damage;

        public BossTakeDamageCommand(IBoss boss, int damage)
        {
            Boss = boss;
            Damage = damage;
        }

        public void Execute()
        {
            Boss.TakeDamage(Damage);
        }
    }
}
