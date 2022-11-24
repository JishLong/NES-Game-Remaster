using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerBlueArrowAttackCommand : ITargetedCommand
    {
        private readonly IPlayer Player;

        public PlayerBlueArrowAttackCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            // Blue arrows aren't in the first dungeon, but this can stay for now

            /*Player.SecondaryWeapon = Types.Projectile.BLUE_ARROW_PROJ;
            Player.DoSecondaryAttack();*/
        }

        public void SetTarget<T>(T target)
        {
            
        }
    }
}
