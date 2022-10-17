using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerStopActionCommand : ICommand
    {
        private readonly IPlayer Player;

        public PlayerStopActionCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            Player.StopAction();
        }
    }
}
