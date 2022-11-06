using Microsoft.Xna.Framework.Graphics;
using Sprint0.Levels;

namespace Sprint0.GameStates.GameStates
{
    public class RightTransitionState : AbstractGameState
    {
        private readonly Room CurrentRoom;
        private readonly Room NextRoom;

        private readonly int TransitionFrames = Utils.GameWidth / 4;
        private int FramesPassed;

        public RightTransitionState()
        {
            Controllers = new System.Collections.Generic.List<IController>();

            CurrentRoom = Game.LevelManager.CurrentLevel.CurrentRoom;
            NextRoom = Game.LevelManager.CurrentLevel.CurrentRoom.GetAdjacentRoom(Types.RoomTransition.RIGHT);
            FramesPassed = 0;
        }

        public override void Draw(SpriteBatch sb)
        {
            FramesPassed++;

            Camera.Move(Types.Direction.RIGHT, Utils.GameWidth / TransitionFrames);
            CurrentRoom.Draw(sb);

            Camera.Move(Types.Direction.LEFT, Utils.GameWidth);
            NextRoom.Draw(sb);
            Camera.Move(Types.Direction.RIGHT, Utils.GameWidth);

            if (FramesPassed == TransitionFrames - 1)
            {
                Camera.Reset();
                Game.LevelManager.CurrentLevel.CurrentRoom.MakeTransition(Types.RoomTransition.RIGHT);
                Game.UnpauseGame();
            }
        }
    }
}
