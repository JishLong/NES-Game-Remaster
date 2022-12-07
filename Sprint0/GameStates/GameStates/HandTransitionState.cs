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
    public class HandTransitionState : AbstractGameState
    {
        private static readonly int HUDHeight = (int)(56 * GameWindow.ResolutionScale);
        // Number of frames it takes to close the "curtains"
        private static readonly int ClosingFrames = 80;
        // Number of frames it takes for the "curtains" to open again
        private static readonly int OpeningFrames = 80;

        private readonly LevelResources LevelResources;
        private readonly Room CurrentRoom;
        private readonly Room NextRoom;

        private int FramesPassed;
        private int AnimationStage;
        private int CurtainWidth;

        public HandTransitionState(Game1 game) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetRoomTransitionStateMappings(Game, this)),
            };

            LevelResources = LevelResources.GetInstance();
            CurrentRoom = Game.LevelManager.CurrentLevel.CurrentRoom;
            NextRoom = Game.LevelManager.CurrentLevel.Rooms.Find(room => room.Name == "Room" + Game.LevelManager.CurrentLevel.StartingRoomIndex);

            FramesPassed = 0;
            AnimationStage = 0;
            CurtainWidth = 0;       
        }

        public override void Draw(SpriteBatch sb)
        {
            // Draw the HUD
            Camera.GetInstance().Move(Types.Direction.UP, HUDHeight);
            Game.PlayerManager.GetDefaultPlayer().HUD.Draw(sb);
            Camera.GetInstance().Move(Types.Direction.DOWN, HUDHeight);

            // Draw the game
            if (AnimationStage == 0) CurrentRoom.Draw(sb);
            else NextRoom.Draw(sb);

            // Draw the curtains
            sb.Draw(ImageMappings.GetInstance().GuiElementsSpriteSheet, 
                new Rectangle(0, HUDHeight, CurtainWidth, GameWindow.DefaultScreenHeight - HUDHeight), ImageMappings.GetInstance().ScreenCover,
                Color.Black, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
            sb.Draw(ImageMappings.GetInstance().GuiElementsSpriteSheet, new Rectangle(GameWindow.DefaultScreenWidth - CurtainWidth, HUDHeight, CurtainWidth, 
                GameWindow.DefaultScreenHeight - HUDHeight), ImageMappings.GetInstance().ScreenCover, Color.Black, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);

            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            FramesPassed++;

            switch (AnimationStage) 
            {
                case 0:
                    CurtainWidth = (int)(GameWindow.DefaultScreenWidth * ((float)FramesPassed / ClosingFrames) / 2);
                    if (FramesPassed >= ClosingFrames)
                    {
                        NextRoom.ResetRoom();
                        Game.LevelManager.CurrentLevel.CurrentRoom = NextRoom;
                        foreach (var player in Game.PlayerManager)
                        {
                            player.Position = new Vector2(LevelResources.BlockWidth * 8, 
                                LevelResources.BlockHeight * 8);
                        }

                        FramesPassed = 0;
                        AnimationStage++;
                    }
                    break;
                default:
                    CurtainWidth = (int)(GameWindow.DefaultScreenWidth * (1 - (float)FramesPassed / OpeningFrames) / 2);
                    if (FramesPassed >= OpeningFrames) 
                    {
                        Game.CurrentState = new PlayingState(Game);
                    }
                    break;
            }
        }
    }
}
