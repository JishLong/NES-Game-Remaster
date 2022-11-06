using Sprint0.Player;

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
            Player.SecondaryWeapon = Types.Projectile.BOOMERANG_PROJ;
            new PlayerSecondaryAttackCommand(Player).Execute();
        }
    }
}
