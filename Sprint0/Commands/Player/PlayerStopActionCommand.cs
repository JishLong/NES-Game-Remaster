using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerStopActionCommand : ITargetedCommand
    {
        private IPlayer target;

        public PlayerStopActionCommand(IPlayer player)
        {
            target = player;
        }

        public void SetTarget<T>(T target)
        {
            this.target = (IPlayer)target;
        }

        public void Execute()
        {
            target.StopAction();
        }
    }
}
