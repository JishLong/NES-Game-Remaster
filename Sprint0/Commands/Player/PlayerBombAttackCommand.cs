using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerBombAttackCommand : ICommand
    {
        private readonly IPlayer Player;

        public PlayerBombAttackCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            Player.SecondaryWeapon = Types.PlayerWeapon.BOMB;
            new PlayerSecondaryAttackCommand(Player).Execute();
        }
    }
}
