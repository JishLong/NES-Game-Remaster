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
        /*private readonly IGameState InventoryState;
        private readonly IGameState PlayingState;

        private readonly Types.Direction Direction;
        private readonly Room CurrentRoom;

        private readonly int ShiftAmount;
        private readonly int TransitionFrames;
        private int ShiftedAmount;
        private int FramesPassed;

        public InventoryTransitionState(Types.Direction direction)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetInventoryTransitionStateMappings()),
            };

            Direction = direction;
            InventoryState = new InventoryState();
            PlayingState = new PlayingState();

            ShiftAmount = (int)(176 * Utils.GameScale);
            ShiftedAmount = 0;
            TransitionFrames = ShiftAmount / 4;
            CurrentRoom = Game.LevelManager.CurrentLevel.CurrentRoom;
            FramesPassed = 0;
        }

        public override void Draw(SpriteBatch sb)
        {

            if (Direction == Types.Direction.UP)
            {
                Camera.Move(Utils.GetOppositeDirection(Direction), Utils.GameHeight);
                Camera.Move(Direction, ShiftedAmount);
                InventoryState.Draw(sb);
                Camera.Move(Direction, Utils.GameHeight);
                //Camera.Move(Direction, ShiftedAmount);
                //Camera.Move(Types.Direction.DOWN, (int)(44 * Utils.GameScale));
                //Game.HUD.Draw(sb);
                //Camera.Move(Types.Direction.UP, (int)(44 * Utils.GameScale));
                CurrentRoom.Draw(sb);

                //Camera.Move(Utils.GetOppositeDirection(Direction), ShiftAmount);
                //InventoryState.Draw(sb);
            }
            else if (Direction == Types.Direction.DOWN) 
            {
                Camera.Move(Direction, ShiftedAmount);
                InventoryState.Draw(sb);

                Camera.Move(Utils.GetOppositeDirection(Direction), ShiftAmount);
                Camera.Move(Types.Direction.DOWN, (int)(44 * Utils.GameScale));
                Game.HUD.Draw(sb);
                Camera.Move(Types.Direction.UP, (int)(44 * Utils.GameScale));
                CurrentRoom.Draw(sb);
                
            }

            Camera.Reset();

            if (FramesPassed == TransitionFrames - 1)
            {
                if (Direction == Types.Direction.UP) Game.CurrentState = InventoryState;
                else Game.CurrentState = PlayingState;

            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ShiftedAmount += ShiftAmount / TransitionFrames;
            FramesPassed++;
        }*/
    }
}
