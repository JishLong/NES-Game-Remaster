using Sprint0.Player;
using static Sprint0.Types;

namespace Sprint0.Commands.Player
{
    public class PlayerBoomerangAttackCommand : ITargetedCommand
    {
        private readonly IPlayer Player;

        public PlayerBoomerangAttackCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            if (Player.Inventory.SelectedItem == Item.WOODENBOOMERANG)
            {
                Player.SecondaryWeapon = Types.Projectile.BOOMERANG_PROJ;
                Player.DoSecondaryAttack();
            }
        }

        public void SetTarget<T>(T target)
        {
            throw new System.NotImplementedException();
        }
    }
}
