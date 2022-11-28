using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class InventoryTransitionState : AbstractGameState
    {
        private static readonly int ShiftAmount = (int)(176 * GameWindow.ResolutionScale);
        private static readonly int TransitionFrames = ShiftAmount / 8;

        private readonly Types.Direction Direction;
        private readonly IGameState InventoryState;
        private readonly IGameState PlayingState;

        private int ShiftedAmount;
        private int FramesPassed;

        public InventoryTransitionState(Game1 game, Types.Direction direction) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetInventoryTransitionStateMappings(Game, this)),
                new MouseController(MouseMappings.GetInstance().NoMappings)
            };

            Direction = direction;
            InventoryState = new InventoryState(game);
            PlayingState = new PlayingState(game);

            ShiftedAmount = 0;
            FramesPassed = 0;
        }

        public override void Draw(SpriteBatch sb)
        {
            /* If we're moving up into the inventory, the camera should move below the screen and draw the playing state,
             * then move up and draw the inventory state
             * 
             * If we're moving down back to the game, the camera should move above the screen and draw the inventory state,
             * then move down and draw the playing state
             */
            Camera.GetInstance().Move(Utils.GetOppositeDirection(Direction), ShiftedAmount);
            if (Direction == Types.Direction.UP) PlayingState.Draw(sb);
            else if (Direction == Types.Direction.DOWN) InventoryState.Draw(sb);

            Camera.GetInstance().Move(Direction, ShiftAmount);
            if (Direction == Types.Direction.UP) InventoryState.Draw(sb);
            else if (Direction == Types.Direction.DOWN) PlayingState.Draw(sb);

            // Reset camera - better to trace back steps than to hard reset its position
            Camera.GetInstance().Move(Utils.GetOppositeDirection(Direction), ShiftAmount);
            Camera.GetInstance().Move(Direction, ShiftedAmount);
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
