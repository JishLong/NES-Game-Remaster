using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerSwordAttackCommand : ITargetedCommand
    {
        private IPlayer target;
        public PlayerSwordAttackCommand(IPlayer player)
        {
            target = player;
        }

        public void Execute()
        {
            target.DoPrimaryAttack();
        }

        public void SetTarget<T>(T target)
        {
            this.target = (IPlayer)target;
        }
    }
}
