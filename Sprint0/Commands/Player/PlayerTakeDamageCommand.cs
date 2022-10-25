using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerTakeDamageCommand : ICommand
    {
        private readonly IPlayer Player;
        private readonly Types.Direction PlayerSide;
        private readonly int Damage;

        public PlayerTakeDamageCommand(IPlayer player, Types.Direction playerSide, int damage)
        {
            Player = player;
            PlayerSide = playerSide;
            Damage = damage;
        }

        public void Execute()
        {
            Player.TakeDamage(Damage);
        }
    }
}
