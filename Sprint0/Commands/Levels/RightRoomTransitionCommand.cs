using Sprint0.GameStates.GameStates;
using Sprint0.Player;

namespace Sprint0.Commands.Levels
{
    public class RightRoomTransitionCommand: ICommand
    {
        private readonly Game1 Game;

        public RightRoomTransitionCommand(IPlayer player, Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            if (Game.LevelManager.CurrentLevel.CurrentRoom.GetAdjacentRoom(Types.RoomTransition.RIGHT) != null)
                Game.CurrentState = new RightTransitionState();
        }
    }
}
