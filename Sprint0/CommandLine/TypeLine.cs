using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.CommandLine
{
    public class TypeLine
    {
        // How quickly the text cursor flashes on the screen; LOWER number = more flashing
        private static readonly int FlashingFrames = 15;
        private int FlashingFramesPassed;
        private bool IsShowing;

        // The frame delay for holding down a key before it starts being spammed
        private static readonly int CharPauseFrames = 20;
        private int CharPauseFramesPassed;
        // The frame delay between each key appearing when it's being spammed
        private static readonly int CharSpamFrames = 3;
        private int CharSpamFramesPassed;

        // Helps determine when a key can be spammed and when it cannot 
        private bool KeyIsHeld;
        private char PrevChar;

        // How big the text appears on the screen; bigger number = bigger elements
        private readonly float TextScaling;
        public string Text { get; private set; }

        // The positions of things on the screen
        private readonly Rectangle Position;
        private Vector2 TextPosition;
        private Rectangle TextCursorPosition;

        public TypeLine(Rectangle position, float textScaling) 
        {
            FlashingFramesPassed = 0;
            IsShowing = false;

            KeyIsHeld = false;
            PrevChar = '\0';

            Position = position;
            TextScaling = textScaling;
            Text = "";

            Vector2 CharSize = FontMappings.GetInstance().SmallFont.MeasureString(" ") * GameWindow.ResolutionScale * TextScaling;
            // The zelda font has a strange height, so the text is actually placed a little further down to better center it
            TextPosition = new Vector2(CharSize.X / 2, Position.Y + CharSize.Y / 8);
            TextCursorPosition = new Rectangle((int)(CharSize.X / 2), Position.Y + Position.Height / 6,
                (int)CharSize.X / 2, Position.Height * 3 / 4);    
        }

        public void Draw(SpriteBatch sb) 
        {
            // Draw the text
            sb.DrawString(FontMappings.GetInstance().SmallFont, Text, TextPosition, Color.White, 0f, new Vector2(0, 0),
                GameWindow.ResolutionScale * TextScaling, SpriteEffects.None, 0.03f);

            // Draw the little text cursor
            if (IsShowing) sb.Draw(ImageMappings.GetInstance().GuiElementsSpriteSheet, TextCursorPosition, 
                ImageMappings.GetInstance().ScreenCover, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 0.03f);
        }

        public void Update()
        {
            FlashingFramesPassed++;
            if (FlashingFramesPassed % FlashingFrames == 0) IsShowing = !IsShowing;

            // If a key is still being held down, type it out
            if (KeyIsHeld) TypeChar(PrevChar);
        }

        public void TypeChar(char character)
        {
            // Check if this is a key that has JUST been pressed
            if (character != PrevChar || KeyIsHeld == false) 
            {
                // Reset the "key spam timer"
                PrevChar = character;
                KeyIsHeld = true;
                CharPauseFramesPassed = 0;
                CharSpamFramesPassed = 0;

                // If the character is a backspace, remove a character
                if (character == '\b')
                {
                    if (Text.Length > 0) Text = Text.Remove(Text.Length - 1);
                }
                // Otherwise, add the character
                else Text += char.ToLower(character);

                // Update the flashing text cursor's position
                SetCursorPosition();
            }

            // If this key has been held down, see if it's ready to be "spammed" yet
            if (CharPauseFramesPassed < CharPauseFrames) CharPauseFramesPassed++;
            else
            {
                CharSpamFramesPassed++;
                if (CharSpamFramesPassed % CharSpamFrames == 0) 
                {
                    // Key "spam"
                    if (character == '\b')
                    {
                        if (Text.Length > 0) Text = Text.Remove(Text.Length - 1);
                    }
                    else Text += char.ToLower(character);

                    // Update the flashing text cursor's position
                    SetCursorPosition();
                }  
            }
        }

        public void ReleaseChar() 
        {
            KeyIsHeld = false;
        }

        public void ResetText() 
        {
            Text = "";
            SetCursorPosition();
        }

        private void SetCursorPosition()
        {
            Vector2 CharSize = FontMappings.GetInstance().SmallFont.MeasureString(" ") * GameWindow.ResolutionScale * TextScaling;
            Vector2 CommandSize = FontMappings.GetInstance().SmallFont.MeasureString(Text) * GameWindow.ResolutionScale * TextScaling;
            TextCursorPosition = new Rectangle((int)(CharSize.X / 2 + CommandSize.X), Position.Y + Position.Height / 6,
                (int)CharSize.X / 2, Position.Height * 3 / 4);
        }
    }
}
