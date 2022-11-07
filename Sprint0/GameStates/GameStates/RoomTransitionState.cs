using Microsoft.Xna.Framework.Graphics;
using Sprint0.Levels;

namespace Sprint0.GameStates.GameStates
{
    public class RoomTransitionState : AbstractGameState
    {
        private readonly Types.Direction Direction;
        private readonly Room CurrentRoom;
        private readonly Room NextRoom;

        private readonly int ShiftAmount;
        private readonly int TransitionFrames;
        private int FramesPassed;

        public RoomTransitionState(Types.Direction direction)
        {
            Controllers = new System.Collections.Generic.List<IController>();

            Direction = direction;
            ShiftAmount = (Direction == Types.Direction.DOWN || Direction == Types.Direction.UP) ? Utils.GameHeight : Utils.GameWidth;
            TransitionFrames = ShiftAmount / 4;
            CurrentRoom = Game.LevelManager.CurrentLevel.CurrentRoom;
            NextRoom = Game.LevelManager.CurrentLevel.CurrentRoom.GetAdjacentRoom(Utils.DirectionToRoomTransition(direction));
            FramesPassed = 0;
        }

        public override void Draw(SpriteBatch sb)
        {
            FramesPassed++;

            Camera.Move(Direction, ShiftAmount / TransitionFrames);
            CurrentRoom.Draw(sb);

            Camera.Move(Utils.GetOppositeDirection(Direction), ShiftAmount);
            NextRoom.Draw(sb);
            Camera.Move(Direction, ShiftAmount);

            if (FramesPassed == TransitionFrames - 1)
            {
                Camera.Reset();
                Game.LevelManager.CurrentLevel.CurrentRoom.MakeTransition(Utils.DirectionToRoomTransition(Direction));
                Game.UnpauseGame();
            }
        }
    }
}
