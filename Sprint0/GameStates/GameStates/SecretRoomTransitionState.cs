using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Levels;
using Sprint0.Levels.Utils;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class SecretRoomTransitionState : AbstractGameState
    {
        private static readonly int HUDHeight = (int)(56 * GameWindow.ResolutionScale);
        private static readonly int FadeOutFrames = 75;

        private readonly LevelResources LevelResources;
        private readonly Room CurrentRoom;
        private readonly Room NextRoom;

        private int FramesPassed;
        private float FadeAmount;

        public SecretRoomTransitionState(Game1 game) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetRoomTransitionStateMappings(Game, this)),
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
            // Draw the HUD
            Camera.GetInstance().Move(Types.Direction.UP, HUDHeight);
            Game.PlayerManager.GetDefaultPlayer().HUD.Draw(sb);
            Camera.GetInstance().Move(Types.Direction.DOWN, HUDHeight);

            // Draw the game
            CurrentRoom.Draw(sb);

            // Draw a cover over everything that slowly gets more opaque - fade effect
            sb.Draw(ImageMappings.GetInstance().GuiElementsSpriteSheet, 
                new Rectangle(0, 0, GameWindow.DefaultScreenWidth, GameWindow.DefaultScreenHeight), ImageMappings.GetInstance().ScreenCover,
                Color.Black * FadeAmount, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);

            if (FramesPassed > FadeOutFrames)
            {
                // Go into the secret room
                Game.LevelManager.CurrentLevel.CurrentRoom.MakeTransition(Types.RoomTransition.SECRET);
                NextRoom.Draw(sb);

                // Set the player at a specific location (was this way in the original game)
                int NewPlayerX = LevelResources.BlockWidth * 3;
                int NewPlayerY = LevelResources.BlockHeight * 2;
                foreach (var player in Game.PlayerManager)
                {
                    player.Position = new Vector2(NewPlayerX, NewPlayerY);
                }

                // Resume playing game
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
