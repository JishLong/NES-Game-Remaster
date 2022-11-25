using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Levels;
using Sprint0.Levels.Utils;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class HandTransitionState : AbstractGameState
    {
        private static readonly int HudAreaHeight = (int)(56 * Utils.GameScale);
        private int AnimationStage;
        private static readonly int ClosingFrames = 80;
        private static readonly int OpeningFrames = 80;

        private readonly LevelResources LevelResources;
        private readonly Room CurrentRoom;
        private readonly Room NextRoom;

        private int FramesPassed;
        private int RectWidth;

        public HandTransitionState(Game1 game) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetRoomTransitionStateMappings(Game, this)),
                new MouseController(MouseMappings.GetInstance().NoMappings)
            };

            LevelResources = LevelResources.GetInstance();
            CurrentRoom = Game.LevelManager.CurrentLevel.CurrentRoom;
            NextRoom = Game.LevelManager.CurrentLevel.Rooms.Find(room => room.Name == "Room" + Game.LevelManager.CurrentLevel.StartingRoomIndex);

            FramesPassed = 0;
            RectWidth = 0;

            AnimationStage = 0;
        }

        public override void Draw(SpriteBatch sb)
        {
            Camera.GetInstance().Move(Types.Direction.UP, HudAreaHeight);
            Game.PlayerManager.GetDefaultPlayer().HUD.Draw(sb);

            Camera.GetInstance().Reset();
            if (AnimationStage == 0) CurrentRoom.Draw(sb);
            else NextRoom.Draw(sb);

            sb.Draw(Resources.ScreenCover, new Rectangle(0, HudAreaHeight, RectWidth, Utils.GameHeight - HudAreaHeight), null,
                Color.Black, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
            sb.Draw(Resources.ScreenCover, new Rectangle(Utils.GameWidth - RectWidth, HudAreaHeight, RectWidth, Utils.GameHeight - HudAreaHeight), null,
                Color.Black, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);

            
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            FramesPassed++;

            switch (AnimationStage) 
            {
                case 0:
                    RectWidth = (int)(Utils.GameWidth * ((float)FramesPassed / ClosingFrames) / 2);
                    if (FramesPassed >= ClosingFrames)
                    {
                        NextRoom.ResetRoom();
                        Game.LevelManager.CurrentLevel.CurrentRoom = NextRoom;
                        foreach (var player in Game.PlayerManager)
                        {
                            player.Position = new Vector2(Resources.BlueTile.Width * Utils.GameScale * 8, Resources.BlueTile.Height * Utils.GameScale * 8);
                        }
                        //Game.Player.Position = new Vector2(Resources.BlueTile.Width * Utils.GameScale * 8, Resources.BlueTile.Height * Utils.GameScale * 8);

                        FramesPassed = 0;
                        AnimationStage++;
                    }
                    break;
                default:
                    RectWidth = (int)(Utils.GameWidth * (1 - (float)FramesPassed / OpeningFrames) / 2);
                    if (FramesPassed >= OpeningFrames) 
                    {
                        Game.CurrentState = new PlayingState(Game);
                    }
                    break;
            }
        }
    }
}
