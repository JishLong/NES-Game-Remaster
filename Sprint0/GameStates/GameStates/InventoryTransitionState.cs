using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Levels;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class InventoryTransitionState : AbstractGameState
    {
        private readonly IGameState InventoryState;
        private readonly IGameState PlayingState;

        private readonly Types.Direction Direction;

        private readonly int ShiftAmount;
        private readonly int TransitionFrames;
        private int ShiftedAmount;
        private int FramesPassed;

        public InventoryTransitionState(Types.Direction direction)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetInventoryTransitionStateMappings(Game, this)),
            };

            Direction = direction;
            InventoryState = new InventoryState();
            PlayingState = new PlayingState();

            ShiftAmount = (int)(176 * Utils.GameScale);
            ShiftedAmount = 0;
            TransitionFrames = ShiftAmount / 8;
            FramesPassed = 0;
        }

        public override void Draw(SpriteBatch sb)
        {
            Camera.Move(Direction, ShiftedAmount);
            if (Direction == Types.Direction.UP) PlayingState.Draw(sb);
            else if (Direction == Types.Direction.DOWN) InventoryState.Draw(sb);
            Camera.Move(Utils.GetOppositeDirection(Direction), ShiftAmount);
            if (Direction == Types.Direction.UP) InventoryState.Draw(sb);
            else if (Direction == Types.Direction.DOWN) PlayingState.Draw(sb);
            Camera.Reset();           
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ShiftedAmount += ShiftAmount / TransitionFrames;
            FramesPassed++;

            if (FramesPassed >= TransitionFrames - 1)
            {
                if (Direction == Types.Direction.UP) Game.CurrentState = InventoryState;
                else Game.CurrentState = PlayingState;
            }
        }
    }
}
