using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Levels;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class RoomTransitionState : AbstractGameState
    {
        private readonly Types.Direction Direction;
        private readonly Room CurrentRoom;
        private readonly Room NextRoom;

        private readonly int ShiftAmount;
        private readonly int TransitionFrames;
        private int ShiftedAmount;
        private int FramesPassed;

        public RoomTransitionState(Types.Direction direction)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetRoomTransitionStateMappings(Game, this)),
            };

            Direction = direction;
            ShiftAmount = (Direction == Types.Direction.DOWN || Direction == Types.Direction.UP) ? (int)(176 * Utils.GameScale) : Utils.GameWidth;
            ShiftedAmount = 0;
            TransitionFrames = ShiftAmount / 4;
            CurrentRoom = Game.LevelManager.CurrentLevel.CurrentRoom;
            NextRoom = Game.LevelManager.CurrentLevel.CurrentRoom.GetAdjacentRoom(Utils.DirectionToRoomTransition(direction));
            if (NextRoom == null) Game.CurrentState = new PlayingState();
            FramesPassed = 0;
        }

        public override void Draw(SpriteBatch sb)
        {
            Camera.Move(Types.Direction.DOWN, (int)(44 * Utils.GameScale));
            Game.Player.HUD.Draw(sb);
            Camera.Reset();

            Camera.Move(Direction, ShiftedAmount);
            CurrentRoom.Draw(sb);

            Camera.Move(Utils.GetOppositeDirection(Direction), ShiftAmount);
            NextRoom.Draw(sb);
            Camera.Move(Direction, ShiftAmount);
            Camera.Reset();

            if (FramesPassed == TransitionFrames - 1)
            {
                
                Game.LevelManager.CurrentLevel.CurrentRoom.MakeTransition(Utils.DirectionToRoomTransition(Direction));
                Vector2 DirectionVector = Utils.DirectionToVector(Direction);
                int NewPlayerX = (int)(Game.Player.Position.X + DirectionVector.X * (16 * 2.75 * Utils.GameScale) + ShiftAmount) % ShiftAmount;
                int NewPlayerY = (int)(Game.Player.Position.Y + DirectionVector.Y * (16 * 2.75 * Utils.GameScale) + ShiftAmount) % ShiftAmount;
                Game.Player.Position = new Vector2(NewPlayerX, NewPlayerY);
                Game.CurrentState = new PlayingState();
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ShiftedAmount += ShiftAmount / TransitionFrames;
            FramesPassed++;
        }
    }
}
