using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerMoveDownCommand : ICommand
    {
        private readonly IPlayer Player;

        public PlayerMoveDownCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            Player.Move(Types.Direction.DOWN);
        }
    }
}
