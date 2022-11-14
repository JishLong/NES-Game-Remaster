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

        public RoomTransitionState(Game1 game, Types.Direction direction) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetRoomTransitionStateMappings(Game, this)),
                new MouseController(MouseMappings.GetInstance().NoMappings)
            };

            Direction = direction;
            ShiftAmount = (Direction == Types.Direction.DOWN || Direction == Types.Direction.UP) ? (int)(176 * Utils.GameScale) : Utils.GameWidth;
            ShiftedAmount = 0;
            TransitionFrames = ShiftAmount / 6;
            FramesPassed = 0;

            CurrentRoom = Game.LevelManager.CurrentLevel.CurrentRoom;
            NextRoom = Game.LevelManager.CurrentLevel.CurrentRoom.GetAdjacentRoom(Utils.DirectionToRoomTransition(direction));
            if (NextRoom == null) Game.CurrentState = new PlayingState(Game);  
        }

        public override void Draw(SpriteBatch sb)
        {
            Camera.GetInstance().Move(Types.Direction.UP, (int)(44 * Utils.GameScale));
            Game.Player.HUD.Draw(sb);
            Camera.GetInstance().Reset();

            Camera.GetInstance().Move(Utils.GetOppositeDirection(Direction), ShiftedAmount);
            CurrentRoom.Draw(sb);

            Camera.GetInstance().Move(Direction, ShiftAmount);
            NextRoom.Draw(sb);
            Camera.GetInstance().Reset();

            if (FramesPassed >= TransitionFrames - 1)
            {
                Game.LevelManager.CurrentLevel.CurrentRoom.MakeTransition(Utils.DirectionToRoomTransition(Direction));
                Vector2 DirectionVector = Utils.DirectionToVector(Direction);

                int NewPlayerX = (int)(Game.Player.Position.X + DirectionVector.X * (16 * 2.75 * Utils.GameScale) + ShiftAmount) % ShiftAmount;
                int NewPlayerY = (int)(Game.Player.Position.Y + DirectionVector.Y * (16 * 2.75 * Utils.GameScale) + ShiftAmount) % ShiftAmount;
                Game.Player.Position = new Vector2(NewPlayerX, NewPlayerY);

                Game.CurrentState = new PlayingState(Game);               
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
