using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerArrowAttackCommand : ITargetedCommand
    {
        private IPlayer Player;

        public PlayerArrowAttackCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            if (Player.Inventory.SelectedItem == Types.Item.BOW && Player.Inventory.HasItem(Types.Item.RUPEE) 
                && Player.Inventory.GetAmount(Types.Item.RUPEE) > 0)
            { 
                Player.SecondaryWeapon = Types.Projectile.ARROW_PROJ;
                Player.DoSecondaryAttack();
            } 
        }

        public void SetTarget<T>(T target)
        {
            this.Player = (IPlayer)target;
        }
    }
}
