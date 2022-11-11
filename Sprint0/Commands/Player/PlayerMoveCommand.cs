using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerMoveCommand : ICommand
    {
        private readonly IPlayer Player;
        private readonly Types.Direction Direction;

        public PlayerMoveCommand(IPlayer player, Types.Direction direction)
        {
            Player = player;
            Direction = direction;
        }

        public void Execute()
        {
            Player.Move(Direction);
        }
    }
}
