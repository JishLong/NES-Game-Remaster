using Sprint0.GameStates.GameStates;
using Sprint0.Player;

namespace Sprint0.Commands.Levels
{
    public class RoomTransitionCommand: ITargetedCommand
    {
        private readonly Game1 Game;
        private readonly Types.Direction Direction;
        private IPlayer player;

        public RoomTransitionCommand(Game1 game, Types.Direction direction, IPlayer target)
        {
            Game = game;
            Direction = direction;
            this.player = target;
        }

        public void Execute()
        {
            Game.CurrentState = new RoomTransitionState(Game, Direction, player);
        }

        public void SetTarget<T>(T target)
        {
            this.player = (IPlayer)target;
        }
    }
}
