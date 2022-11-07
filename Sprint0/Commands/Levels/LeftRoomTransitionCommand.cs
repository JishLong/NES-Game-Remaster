using Microsoft.Xna.Framework;
using Sprint0.Commands.Player;
using Sprint0.GameStates.GameStates;
using Sprint0.Player;
using Sprint0.Levels.Utils;

namespace Sprint0.Commands.Levels
{
    public class LeftRoomTransitionCommand: ICommand
    {
        private readonly Game1 Game;
        private Vector2 NewPosition;
        private PlayerRelocateCommand RelocateCommand;
        private LevelResources LevelResources = LevelResources.GetInstance();

        public LeftRoomTransitionCommand(IPlayer player, Game1 game)
        {
            Game = game;
            Vector2 offset = new Vector2(-LevelResources.BlockWidth, LevelResources.BlockHeight / 2);
            NewPosition = LevelResources.RightDoorPosition + offset;
            RelocateCommand = new PlayerRelocateCommand(player, NewPosition);
        }

        public void Execute()
        {
            if (Game.LevelManager.CurrentLevel.CurrentRoom.GetAdjacentRoom(Types.RoomTransition.LEFT) != null)
            Game.CurrentState = new LeftTransitionState();
            RelocateCommand.Execute();
        }
    }
}
