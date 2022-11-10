using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerArrowAttackCommand : ICommand
    {
        private readonly IPlayer Player;

        public PlayerArrowAttackCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            if (Player.Inventory.HasItem(Types.Item.BOW) && Player.Inventory.HasItem(Types.Item.RUPEE) && Player.Inventory.GetAmount(Types.Item.RUPEE) > 0)
            {
                Player.Inventory.decAmount(Types.Item.RUPEE);
                Player.SecondaryWeapon = Types.Projectile.ARROW_PROJ;
                new PlayerSecondaryAttackCommand(Player).Execute();
            }

            
        }
    }
}
