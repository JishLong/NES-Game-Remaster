using Sprint0.Player;
using static Sprint0.Types;

namespace Sprint0.Commands.Player
{
    public class PlayerBoomerangAttackCommand : ICommand
    {
        private readonly IPlayer Player;

        public PlayerBoomerangAttackCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            if (Player.Inventory.SelectedItem == Item.WOODEN_BOOMERANG)
            {
                Player.SecondaryWeapon = Types.Projectile.BOOMERANG_PROJ;
                new PlayerSecondaryAttackCommand(Player).Execute();
            }
        }
    }
}
