using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerArrowAttackCommand : ICommand
    {
        private readonly IPlayer Player;

        public PlayerArrowAttackCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            // soon
        }
    }
}
