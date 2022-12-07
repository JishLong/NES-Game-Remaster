using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Levels;
using Sprint0.Player;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class RoomTransitionState : AbstractGameState
    {
        private static readonly int HUDHeight = (int)(56 * GameWindow.ResolutionScale);

        private readonly Types.Direction Direction;
        private readonly int ShiftAmount;
        private readonly int TransitionFrames;
        private readonly IPlayer TargetPlayer;
        private readonly Room CurrentRoom;
        private readonly Room NextRoom;

        private int ShiftedAmount;
        private int FramesPassed;
        

        public RoomTransitionState(Game1 game, Types.Direction direction, IPlayer player) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetRoomTransitionStateMappings(Game, this)),
                new MouseController(MouseMappings.GetInstance().NoMappings, game)
            };

            Direction = direction;
            ShiftAmount = (Direction == Types.Direction.DOWN || Direction == Types.Direction.UP) ? (int)(176 * GameWindow.ResolutionScale) : 
                GameWindow.DefaultScreenWidth;
            TransitionFrames = ShiftAmount / 6;
            TargetPlayer = player;

            CurrentRoom = Game.LevelManager.CurrentLevel.CurrentRoom;
            NextRoom = Game.LevelManager.CurrentLevel.CurrentRoom.GetAdjacentRoom(Utils.DirectionToRoomTransition(direction));
            if (NextRoom == null) Game.CurrentState = new PlayingState(Game);

            ShiftedAmount = 0;
            FramesPassed = 0;
        }

        public override void Draw(SpriteBatch sb)
        {
            // Draw the HUD
            Camera.GetInstance().Move(Types.Direction.UP, HUDHeight);
            Game.PlayerManager.GetDefaultPlayer().HUD.Draw(sb);
            Camera.GetInstance().Move(Types.Direction.DOWN, HUDHeight);
            
            // If we're moving in some direction, then the current room will go off-screen in the opposite direction
            Camera.GetInstance().Move(Utils.GetOppositeDirection(Direction), ShiftedAmount);
            CurrentRoom.Draw(sb);

            // Draw the incoming room
            Camera.GetInstance().Move(Direction, ShiftAmount);
            NextRoom.Draw(sb);

            // Reset the camera - better to retrace steps than to hard reset
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
                Game.LevelManager.CurrentLevel.CurrentRoom.MakeTransition(Utils.DirectionToRoomTransition(Direction));
                Vector2 DirectionVector = Utils.DirectionToVector(Direction);

                foreach (var player in Game.PlayerManager)
                {
                    // Very precise player positioning so they spawn exactly inside the door in the next room
                    int NewPlayerX = (int)(TargetPlayer.Position.X + DirectionVector.X * 
                        (16 * 2.75 * GameWindow.ResolutionScale) + ShiftAmount) % ShiftAmount;
                    int NewPlayerY = (int)(TargetPlayer.Position.Y + DirectionVector.Y * 
                        (16 * 2.75 * GameWindow.ResolutionScale) + ShiftAmount) % ShiftAmount;
                    player.Position = new Vector2(NewPlayerX, NewPlayerY);
                }

                Game.CurrentState = new PlayingState(Game);
            }
        }
    }
}
