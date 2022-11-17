using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Levels;
using Sprint0.Levels.Utils;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class ExitSecretRoomTransitionState : AbstractGameState
    {
        private static readonly int HudAreaHeight = 56;
        private static readonly int FadeOutFrames = 75;

        private readonly LevelResources LevelResources;
        private readonly Room CurrentRoom;
        private readonly Room NextRoom;

        private int FramesPassed;
        private float FadeAmount;

        public ExitSecretRoomTransitionState(Game1 game) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetRoomTransitionStateMappings(Game, this)),
                new MouseController(MouseMappings.GetInstance().NoMappings)
            };

            LevelResources = LevelResources.GetInstance();
            CurrentRoom = Game.LevelManager.CurrentLevel.CurrentRoom;
            NextRoom = Game.LevelManager.CurrentLevel.CurrentRoom.GetAdjacentRoom(Types.RoomTransition.SECRET);
            if (NextRoom == null) Game.CurrentState = new PlayingState(Game);

            FramesPassed = 0;
            FadeAmount = 0f;
        }

        public override void Draw(SpriteBatch sb)
        {
            Camera.GetInstance().Move(Types.Direction.UP, (int)(HudAreaHeight * Utils.GameScale));
            Game.Player.HUD.Draw(sb);

            Camera.GetInstance().Reset();
            CurrentRoom.Draw(sb);

            sb.Draw(Resources.ScreenCover, new Rectangle(0, 0, Utils.GameWidth, Utils.GameHeight), null, 
                Color.Black * FadeAmount, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);

            if (FramesPassed > FadeOutFrames)
            {
                Game.LevelManager.CurrentLevel.CurrentRoom.MakeTransition(Types.RoomTransition.SECRET);
                NextRoom.Draw(sb);

                int NewPlayerX = LevelResources.BlockWidth * 5;
                int NewPlayerY = LevelResources.BlockHeight * 7;
                Game.Player.Position = new Vector2(NewPlayerX, NewPlayerY);

                Game.CurrentState = new PlayingState(Game);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            FramesPassed++;
            FadeAmount += 1f / FadeOutFrames;
        }
    }
}
