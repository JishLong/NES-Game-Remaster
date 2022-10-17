using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerTakeDamageCommand : ICommand
    {
        private readonly IPlayer Player;

        public PlayerTakeDamageCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            Player.TakeDamage();
        }
    }
}
