using Microsoft.Xna.Framework;
using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerRelocateCommand : ICommand
    {
        private readonly IPlayer Player;
        private readonly Vector2 NewPosition;

        public PlayerRelocateCommand(IPlayer player, Vector2 newPosition)
        {
            Player = player;
            NewPosition = newPosition;
        }

        public void Execute()
        {
            Player.Position = NewPosition;
        }
    }
}
