using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerMoveRightCommand : ICommand
    {
        private readonly IPlayer Player;

        public PlayerMoveRightCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            Player.ChangeDirection(Types.Direction.RIGHT);
        }
    }
}
