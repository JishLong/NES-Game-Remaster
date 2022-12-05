using Sprint0.Player;
using static Sprint0.Types;

namespace Sprint0.Commands.Player
{
    public class PlayerFlameAttackCommand : ITargetedCommand
    {
        private readonly IPlayer Player;

        public PlayerFlameAttackCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            if (Player.Inventory.SelectedItem == Item.BLUECANDLE)
            {
                Player.SecondaryWeapon = Types.Projectile.FLAME_PROJ;
                Player.DoSecondaryAttack();
            }
        }

        public void SetTarget<T>(T target)
        {
            throw new System.NotImplementedException();
        }
    }
}
