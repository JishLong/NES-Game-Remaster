using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerMoveUpCommand : ICommand
    {
        private readonly IPlayer Player;

        public PlayerMoveUpCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            Player.ChangeDirection(Types.Direction.UP);
        }
    }
}
