using Microsoft.Xna.Framework;
using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerRelocate : ICommand
    {
        private readonly IPlayer Player;
        private Vector2 NewLoc;

        public PlayerRelocate(IPlayer player, Vector2 newLoc)
        {
            Player = player;
            NewLoc = newLoc;
        }

        public void Execute()
        {
            Player.location(this.NewLoc);
        }
    }
}
