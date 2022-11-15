using Sprint0.Player;
using static Sprint0.Types;

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
            if (Player.Inventory.SelectedItem == Item.BOMB && Player.Inventory.GetAmount(Types.Item.BOMB) > 0)
            {
                Player.SecondaryWeapon = Types.Projectile.BOMB_PROJ;
                Player.DoSecondaryAttack();
            }
        }
    }
}
