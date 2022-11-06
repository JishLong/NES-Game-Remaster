using Microsoft.Xna.Framework.Graphics;
using Sprint0.Levels;

namespace Sprint0.GameStates.GameStates
{
    public class UpTransitionState : AbstractGameState
    {
        private readonly Room CurrentRoom;
        private readonly Room NextRoom;

        private readonly int TransitionFrames = Utils.GameHeight / 4;
        private int FramesPassed;

        public UpTransitionState()
        {
            Controllers = new System.Collections.Generic.List<IController>();

            CurrentRoom = Game.LevelManager.CurrentLevel.CurrentRoom;
            NextRoom = Game.LevelManager.CurrentLevel.CurrentRoom.GetAdjacentRoom(Types.RoomTransition.UP);
            FramesPassed = 0;
        }

        public override void Draw(SpriteBatch sb)
        {
            FramesPassed++;

            Camera.Move(Types.Direction.UP, Utils.GameHeight / TransitionFrames);
            CurrentRoom.Draw(sb);

            Camera.Move(Types.Direction.DOWN, Utils.GameHeight);
            NextRoom.Draw(sb);
            Camera.Move(Types.Direction.UP, Utils.GameHeight);

            if (FramesPassed == TransitionFrames - 1)
            {
                Camera.Reset();
                Game.LevelManager.CurrentLevel.CurrentRoom.MakeTransition(Types.RoomTransition.UP);
                Game.UnpauseGame();
            }
        }
    }
}
