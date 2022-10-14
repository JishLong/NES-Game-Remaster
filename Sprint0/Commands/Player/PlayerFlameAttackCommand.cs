using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerFlameAttackCommand : ICommand
    {
        private readonly IPlayer Player;

        public PlayerFlameAttackCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            Player.SecondaryWeapon = Types.PlayerWeapon.FLAME;
            new PlayerSecondaryAttackCommand(Player).Execute();
        }
    }
}
