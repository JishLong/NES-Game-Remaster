using Sprint0.Blocks.Utils;
using Sprint0.Characters;
using Sprint0.Items.Utils;
using Sprint0.Projectiles;
using Sprint0.Player;

namespace Sprint0.Commands
{
    public class ResetCommand : ICommand
    {
        private Game1 Game;
        private IPlayer Player;

        public ResetCommand(Game1 game, IPlayer player)
        {
            Game = game;
            Player = player;
        }

        public void Execute()
        {
            Player.Reset();
        }
    }
}
