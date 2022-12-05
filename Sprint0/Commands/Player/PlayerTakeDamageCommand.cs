using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerTakeDamageCommand : ITargetedCommand
    {
        private readonly IPlayer Player;
        private readonly Types.Direction PlayerSide;
        private readonly int Damage;
        private readonly Game1 Game;

        public PlayerTakeDamageCommand(IPlayer player, Types.Direction playerSide, int damage, Game1 game)
        {
            Player = player;
            PlayerSide = playerSide;
            Damage = damage;
            Game = game;
        }

        public void Execute()
        {
            Player.ChangeHealth(-Damage, 0, Game);
        }

        public void SetTarget<T>(T target)
        {
            throw new System.NotImplementedException();
        }
    }
}
