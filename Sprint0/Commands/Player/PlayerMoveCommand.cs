using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerMoveCommand : ITargetedCommand
    {
        private readonly Types.Direction Direction;
        private IPlayer target;

        public PlayerMoveCommand(IPlayer player, Types.Direction direction)
        {
            target = player;
            Direction = direction;
        }


        // DANGER: do not call this with a type other than IPlayer
        public void SetTarget<T>(T target)
        {
            this.target = (IPlayer)target;
        }

        public void Execute()
        {
            target.Move(Direction);
        }
    }
}
