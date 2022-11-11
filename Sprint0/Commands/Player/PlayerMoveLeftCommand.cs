using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerMoveLeftCommand : ICommand
    {
        private readonly IPlayer Player;

        public PlayerMoveLeftCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            Player.Move(Types.Direction.LEFT);
        }
    }
}
