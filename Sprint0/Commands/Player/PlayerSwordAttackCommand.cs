using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerSwordAttackCommand : ICommand
    {
        private readonly IPlayer Player;

        public PlayerSwordAttackCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            Player.DoPrimaryAttack();
        }
    }
}
