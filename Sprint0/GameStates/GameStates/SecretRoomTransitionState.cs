using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Levels;
using Sprint0.Levels.Utils;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class SecretRoomTransitionState : AbstractGameState
    {
        private LevelResources LevelResources;
        private readonly Room CurrentRoom;
        private readonly Room NextRoom;

        private int FramesPassed;
        private int FadeOutFrames;
        private float FadeAmount;

        public SecretRoomTransitionState()
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetRoomTransitionStateMappings(Game, this)),
            };

            LevelResources = LevelResources.GetInstance();
            CurrentRoom = Game.LevelManager.CurrentLevel.CurrentRoom;
            NextRoom = Game.LevelManager.CurrentLevel.CurrentRoom.GetAdjacentRoom(Types.RoomTransition.SECRET);
            if (NextRoom == null) Game.CurrentState = new PlayingState();
            FramesPassed = 0;
            FadeAmount = 0f;
            FadeOutFrames = 75;
        }

        public override void Draw(SpriteBatch sb)
        {
            Camera.Move(Types.Direction.DOWN, (int)(44 * Utils.GameScale));
            Game.Player.HUD.Draw(sb);
            Camera.Reset();

            CurrentRoom.Draw(sb);
            sb.Draw(Resources.ScreenCover, new Rectangle(0, 0, Utils.GameWidth, Utils.GameHeight), null, Color.Black * FadeAmount, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
            if (FramesPassed > FadeOutFrames)
            {
                Game.LevelManager.CurrentLevel.CurrentRoom.MakeTransition(Types.RoomTransition.SECRET);
                NextRoom.Draw(sb);
                int NewPlayerX = LevelResources.BlockWidth * 3;
                int NewPlayerY = LevelResources.BlockHeight * 2;
                Game.Player.Position = new Vector2(NewPlayerX, NewPlayerY);
                Game.CurrentState = new PlayingState();
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
