using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerSecondaryAttackCommand : ICommand
    {
        private readonly IPlayer Player;

        public PlayerSecondaryAttackCommand(IPlayer player)
        {
            Player = player;
        }

        public void Execute()
        {
            Player.DoSecondaryAttack();
        }
    }
}
