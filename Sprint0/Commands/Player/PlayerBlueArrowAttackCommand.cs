using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerBlueArrowAttackCommand : ICommand
    {
        private readonly IPlayer Player;

        public PlayerBlueArrowAttackCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            Player.SecondaryWeapon = Types.PlayerWeapon.BLUEARROW;
            new PlayerSecondaryAttackCommand(Player).Execute();
        }
    }
}
