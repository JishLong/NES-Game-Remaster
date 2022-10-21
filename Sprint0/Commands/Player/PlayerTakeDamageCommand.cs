using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerTakeDamageCommand : ICommand
    {
        private readonly IPlayer Player;

        public PlayerTakeDamageCommand(IPlayer player, Types.Direction playerSide)
        {
            Player = player;
            player.FacingDirection = playerSide;
        }

        public void Execute()
        {
            Player.TakeDamage();
        }
    }
}
