using Sprint0.Player;
using static Sprint0.Types;

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
            if (Player.Inventory.SelectedItem == Item.BLUE_CANDLE)
            {
                Player.SecondaryWeapon = Types.Projectile.FLAME_PROJ;
                new PlayerSecondaryAttackCommand(Player).Execute();
            }
        }
    }
}
