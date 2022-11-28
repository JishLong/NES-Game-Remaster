using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Input.ClientInputHandlers;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class CommandLineState : AbstractGameState
    {
        private readonly IInputHandler ClientInputHandler;
        private readonly IGameState PlayingGameState;

        // How quickly the text cursor flashes on the screen; LOWER number = more flashing
        private static readonly int FlashingFreq = 15;
        // How big the text appears on the screen; bigger number = bigger elements
        private static readonly float TextScaling = 0.4f;

        // The positions of elements on the screen
        private Rectangle ResponseLinePosition;
        private Vector2 ResponseTextPosition;
        private Rectangle TextLinePosition;
        private Vector2 CommandTextPosition;
        private Rectangle TextCursorPosition;

        // Logical variables to help check for certain conditions
        private bool IsShowing;
        private int FramesPassed;
        private string Response;
        private string Command;

        public CommandLineState(Game1 game) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetCommandLineStateMappings(Game, this)),
                new MouseController(MouseMappings.GetInstance().NoMappings)
            };

            PlayingGameState = new PlayingState(game);

            SetElementPositions();

            IsShowing = true;
            FramesPassed = 0;
            Response = "type \"help\" for a list of commands";
            Command = "";
        }

        public override void Draw(SpriteBatch sb)
        {
            // Draw the game state that was just paused
            PlayingGameState.Draw(sb);
            sb.Draw(Resources.ScreenCover, new Rectangle(0, 0, GameWindow.DefaultScreenWidth, GameWindow.DefaultScreenHeight),
                null, Color.White * 0.5f, 0f, Vector2.Zero, SpriteEffects.None, 0.05f);

            // Draw the response line - where responses to commands are written out
            sb.Draw(Resources.ScreenCover, ResponseLinePosition, null, Color.Black * 0.5f, 0f, new Vector2(0, 0), SpriteEffects.None, 0.04f);

            // Draw the response
            sb.DrawString(Resources.SmallFont, Response, ResponseTextPosition, Color.White, 0f, new Vector2(0, 0),
                GameWindow.ResolutionScale * TextScaling, SpriteEffects.None, 0.03f);

            // Draw the text line panel
            sb.Draw(Resources.ScreenCover, TextLinePosition, null, Color.Black * 0.5f, 0f, new Vector2(0, 0), SpriteEffects.None, 0.04f);

            // Draw the command
            sb.DrawString(Resources.SmallFont, Command, CommandTextPosition, Color.White, 0f, new Vector2(0, 0),
                GameWindow.ResolutionScale * TextScaling, SpriteEffects.None, 0.03f);

            // Draw the little text cursor
            if (IsShowing) sb.Draw(Resources.ScreenCover, TextCursorPosition, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 0.03f);
        }

        public void SetElementPositions()
        {
            Vector2 CharSize = Resources.SmallFont.MeasureString(" ") * GameWindow.ResolutionScale * TextScaling;

            ResponseLinePosition = new Rectangle(0, (int)(56 * GameWindow.ResolutionScale + GameWindow.DefaultScreenHeight / 20),
                GameWindow.DefaultScreenWidth, GameWindow.DefaultScreenHeight * 11 / 20);
            TextLinePosition = new Rectangle(
                0, GameWindow.DefaultScreenHeight * 18 / 20, GameWindow.DefaultScreenWidth, GameWindow.DefaultScreenHeight / 20);
            
            // The zelda font has a strange height, so the text is actually placed a little further down to better center it
            ResponseTextPosition = new Vector2(CharSize.X / 2, ResponseLinePosition.Y + CharSize.Y / 8);
            CommandTextPosition = new Vector2(CharSize.X / 2, TextLinePosition.Y + CharSize.Y / 8);
            TextCursorPosition = new Rectangle((int)CharSize.X / 2, TextLinePosition.Y + TextLinePosition.Height / 6, 
                (int)CharSize.X / 2, TextLinePosition.Height * 3 / 4);
        }

        public override void Update(GameTime gameTime)
        {
            FramesPassed++;
            if (FramesPassed % FlashingFreq == 0)
            {
                IsShowing = !IsShowing;
            }

            base.Update(gameTime);
        }

        public void AddToCommand(string character) 
        {
            if (character.Equals("Enter"))
            {
                if (Command.Length == 0) Game.CurrentState = PlayingGameState;
                else
                {
                    //parse command
                    Command = "";
                }
            }
            else if (character.Equals("Back"))
            {
                int ShortenedCommand = Command.Length - 1;
                if (ShortenedCommand >= 0)
                    Command = Command[0..ShortenedCommand];
            }
            else 
            {
                if (character.Equals("Space")) character = " ";
                else if (character.Length == 2) character = character[1..];
                Command += character;
            }
            Vector2 CharSize = Resources.SmallFont.MeasureString(" ") * GameWindow.ResolutionScale * TextScaling;
            Vector2 CommandSize = Resources.SmallFont.MeasureString(Command) * GameWindow.ResolutionScale * TextScaling;
            TextCursorPosition = new Rectangle((int)(CharSize.X / 2 + CommandSize.X), TextLinePosition.Y + TextLinePosition.Height / 6, 
                (int)CharSize.X / 2, TextLinePosition.Height * 3 / 4);
        }
    }
}
