using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.Characters;
using Sprint0.Levels;
using System;
using System.Collections.Generic;

namespace Sprint0.Npcs
{
    public class SecretText : AbstractCharacter
    {
        // The dimensions we want the text to fit into
        private static readonly Vector2 TextAreaDims = new(11 * 16 * GameWindow.ResolutionScale, 2 * 16 * GameWindow.ResolutionScale);
        private string Text;

        private List<string> Strings;
        // The number of game frames between each new letter is added to the message
        private static readonly int CharFrames = 4;
        private int MaxChars;

        private int FramesPassed;
        private int NumCharsShown;
        // Y-coordinate offset to help vertically center the text within the [TextAreaDims]
        private int TextHeightOffset;

        public SecretText(Vector2 position)
        {
            Health = 1;
            Position = position;
            Text = "eastmost peninsula is the secret";

            FramesPassed = 0;
            NumCharsShown = 0;
        }

        public override void Draw(SpriteBatch sb)
        {
            if (Strings != null) 
            {
                int numCharsDrawn = 0;
                for (int i = 0; i < Strings.Count; i++)
                {
                    for (int j = 0; j < Strings[i].Length; j++)
                    {
                        if (numCharsDrawn == NumCharsShown) return;
                        numCharsDrawn++;

                        // We want to center the text within the [TextAreaDims] and allow the camera to move it as well
                        int TextWidthOffset = (int)(TextAreaDims.X - (int)FontMappings.GetInstance().MediumFont.MeasureString(Strings[i]).X) / 2;
                        Vector2 StringDims = FontMappings.GetInstance().MediumFont.MeasureString("a");
                        Vector2 TotalOffset = new(TextWidthOffset + StringDims.X * j, TextHeightOffset + StringDims.Y * i);

                        sb.DrawString(FontMappings.GetInstance().MediumFont, Strings[i].Substring(j, 1), Utils.LinkToCamera(Position + TotalOffset),
                            Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.21f);
                    }
                }
            }      
        }

        public override Rectangle GetHitbox()
        {
            // Doesn't need a hitbox, so we'll just return a dud (can't be null)
            return Rectangle.Empty;
        }

        public override void TakeDamage(Types.Direction damageSide, int damage, Room room)
        {
            // Secret message is invincible
        }

        public override void Update(GameTime gameTime)
        {
            if (JustSpawned) 
            {
                JustSpawned = false;
                MaxChars = Text.Length;
                Strings = Utils.GetAlignedText(Text, FontMappings.GetInstance().MediumFont, (int)TextAreaDims.X);
                TextHeightOffset = (int)(TextAreaDims.Y - FontMappings.GetInstance().MediumFont.MeasureString(" ").Y * Strings.Count) / 2;  
            }

            if (NumCharsShown < MaxChars) 
            {
                FramesPassed = (FramesPassed + 1) % CharFrames;
                if (FramesPassed == 0) 
                {
                    NumCharsShown++;
                    AudioManager.GetInstance().PlayOnce(AudioMappings.GetInstance().TextAppear);
                } 
            }
        }

        public void Reset() 
        {
            FramesPassed = 0;
            NumCharsShown = 0;
            JustSpawned = true;
        }

        public void Taunt() 
        {
            string[] taunts =
            {
                "do you value your life?",
                "you've made a fatal mistake...",
                "never attack a god!",
                "your fate is sealed...",
                "rookie mistake...",
                "you'll pay for that!",
                "truly a pity...",
                "die, worthless bug!",
                "respect your elders!",
                "unbelievable.",
                "turn to ash!",
            };

            Text = taunts[new Random().Next(taunts.Length)];
            Reset();
        }
    }
}
