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
        private readonly Types.Direction Direction;
        private readonly Room CurrentRoom;
        private readonly Room NextRoom;

        private readonly int ShiftAmount;
        private readonly int TransitionFrames;
        private int ShiftedAmount;
        private int FramesPassed;
        private readonly IPlayer targetPlayer;

        public RoomTransitionState(Game1 game, Types.Direction direction, IPlayer player) : base(game)
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

            this.targetPlayer = player;

            CurrentRoom = Game.LevelManager.CurrentLevel.CurrentRoom;
            NextRoom = Game.LevelManager.CurrentLevel.CurrentRoom.GetAdjacentRoom(Utils.DirectionToRoomTransition(direction));
            if (NextRoom == null) Game.CurrentState = new PlayingState(Game);  
        }

        public override void Draw(SpriteBatch sb)
        {
            Camera.GetInstance().Move(Types.Direction.UP, (int)(56 * Utils.GameScale));
            Game.PlayerManager.GetDefaultPlayer().HUD.Draw(sb);
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

                foreach (var player in Game.PlayerManager)
                {
                    int NewPlayerX = (int)(targetPlayer.Position.X + DirectionVector.X * (16 * 2.75 * Utils.GameScale) + ShiftAmount) % ShiftAmount;
                    int NewPlayerY = (int)(targetPlayer.Position.Y + DirectionVector.Y * (16 * 2.75 * Utils.GameScale) + ShiftAmount) % ShiftAmount;
                    player.Position = new Vector2(NewPlayerX, NewPlayerY);
                }

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
