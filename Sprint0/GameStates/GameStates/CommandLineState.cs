using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.CommandLine;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Input.ClientInputHandlers;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class CommandLineState : AbstractGameState
    {
        private readonly IInputHandler ClientInputHandler;
        private readonly TypeLine CommandLine;
        private readonly CommandParser CommandParser;

        // How quickly the text cursor flashes on the screen; LOWER number = more flashing
        private static readonly int FlashingFreq = 15;
        // How big the text appears on the screen; bigger number = bigger elements
        private static readonly float TextScaling = 0.4f;

        // The positions of elements on the screen
        private Rectangle TextLinePosition;
        private Rectangle ResponseLinePosition;
        private Vector2 ResponseTextPosition;

        // Logical variables to help check for certain conditions
        private bool IsShowing;
        private int FramesPassed;
        private List<string> Response;

        private IGameState NextGameState;

        public CommandLineState(Game1 game) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetCommandLineStateMappings(Game, this)),
                new MouseController(MouseMappings.GetInstance().NoMappings)
            };

            NextGameState = new PlayingState(game);

            TextLinePosition = new(0, GameWindow.DefaultScreenHeight * 18 / 20, GameWindow.DefaultScreenWidth, GameWindow.DefaultScreenHeight / 20);
            Vector2 CharSize = FontMappings.GetInstance().SmallFont.MeasureString(" ") * GameWindow.ResolutionScale * TextScaling;
            ResponseLinePosition = new Rectangle(0, (int)(GameWindow.DefaultScreenHeight / 20),
                GameWindow.DefaultScreenWidth, GameWindow.DefaultScreenHeight * 16 / 20);
            // The zelda font has a strange height, so the text is actually placed a little further down to better center it
            ResponseTextPosition = new Vector2(CharSize.X / 2, ResponseLinePosition.Y + CharSize.Y / 8);
            CommandLine = new(TextLinePosition, TextScaling);
            CommandParser = new(FontMappings.GetInstance().SmallFont, (int)(TextLinePosition.Width / (GameWindow.ResolutionScale * TextScaling)));

            IsShowing = true;
            FramesPassed = 0;
            Response = new List<string>{ "type \"help\" for a list of commands" };
        }

        public override void Draw(SpriteBatch sb)
        {
            // Draw the game state that was just paused
            NextGameState.Draw(sb);
            sb.Draw(ImageMappings.GetInstance().GuiElementsSpriteSheet, new Rectangle(0, 0, GameWindow.DefaultScreenWidth, GameWindow.DefaultScreenHeight),
                ImageMappings.GetInstance().ScreenCover, Color.White * 0.5f, 0f, Vector2.Zero, SpriteEffects.None, 0.05f);

            // Draw the response line - where responses to commands are written out
            sb.Draw(ImageMappings.GetInstance().GuiElementsSpriteSheet, ResponseLinePosition, ImageMappings.GetInstance().ScreenCover, Color.Black * 0.75f, 0f, new Vector2(0, 0), SpriteEffects.None, 0.04f);

            // Draw the response
            Vector2 CharSize = FontMappings.GetInstance().SmallFont.MeasureString(" ") * GameWindow.ResolutionScale * TextScaling;
            for (int i = 0; i < Response.Count; i++) 
            {
                sb.DrawString(FontMappings.GetInstance().SmallFont, Response[i], ResponseTextPosition + new Vector2(0, CharSize.Y * i), 
                    Color.Aqua, 0f, new Vector2(0, 0), GameWindow.ResolutionScale * TextScaling, SpriteEffects.None, 0.03f);
            }            

            // Draw the text line panel
            sb.Draw(ImageMappings.GetInstance().GuiElementsSpriteSheet, TextLinePosition, ImageMappings.GetInstance().ScreenCover, Color.Black * 0.75f, 0f, new Vector2(0, 0), SpriteEffects.None, 0.04f);

            CommandLine.Draw(sb);
        }

        public override void Update(GameTime gameTime)
        {
            FramesPassed++;
            if (FramesPassed % FlashingFreq == 0) IsShowing = !IsShowing;

            CommandLine.Update();

            base.Update(gameTime);
        }

        public void TypeKey(char key) 
        {
            /* If the key is ENTER, we want to try and execute the command if something is typed
             * If nothing has been typed, we'll close the command line
             */
            if (key == '\r')
            {
                if (CommandLine.Text.Length == 0) Game.CurrentState = NextGameState;
                else
                {
                    Response = CommandParser.ParseCommand(CommandLine.Text, Game);
                    CommandLine.ResetText();
                }
            }
            else CommandLine.TypeChar(key);
        }

        public void ReleaseKey() 
        {
            CommandLine.ReleaseChar();
        }

        public void SetNextState(IGameState nextGameState) 
        {
            NextGameState = nextGameState;
        }
    }
}
