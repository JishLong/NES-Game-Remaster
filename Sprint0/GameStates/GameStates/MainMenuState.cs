using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using System;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class MainMenuState : AbstractGameState
    {
        private readonly Vector2 startTextPosition;
        private readonly Vector2 welcomeTextPosition;
        private Vector2 tipTextPosition;
        private readonly Vector2 flashingTextPosition;

        private string[] Tips;
        private int CurrentTip;
        private readonly Random NumGenerator;
        private readonly int TipFrames;
        private readonly int FlashingFreq;
        private bool IsShowing;
        private int FramesPassed;

        public MainMenuState(Game1 game) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new KeyboardController(KeyboardMappings.GetInstance().GetMainMenuStateMappings(Game)),
            };
            SetTips();
            NumGenerator = new Random();
            CurrentTip = NumGenerator.Next(Tips.Length);

            Vector2 startTextSize = Resources.LargeFont.MeasureString("Press SPACEBAR to start");
            Vector2 welcomeTextSize = Resources.MediumFont.MeasureString("Welcome to the Myth of Zebra!"); 
            Vector2 tipTextSize = Resources.SmallFont.MeasureString(Tips[CurrentTip]);
            Vector2 flashingTextSize = Resources.MediumFont.MeasureString("- TIPS: -");
            startTextPosition = new Vector2(Utils.GameWidth / 2 - startTextSize.X / 2, Utils.GameHeight / 2 - startTextSize.Y / 2);
            welcomeTextPosition = new Vector2(Utils.GameWidth / 2 - welcomeTextSize.X / 2, startTextPosition.Y - welcomeTextSize.Y * 3 / 2);
            tipTextPosition = new Vector2(Utils.GameWidth / 2 - tipTextSize.X / 2, Utils.GameHeight * 9 / 10 - tipTextSize.Y * 3 / 2);
            flashingTextPosition = new Vector2(Utils.GameWidth / 2 - flashingTextSize.X / 2, tipTextPosition.Y - flashingTextSize.Y * 3 / 2);

            TipFrames = 300;
            FlashingFreq = 10;
            IsShowing = true;
            FramesPassed = 0;
        }

        public override void Draw(SpriteBatch sb)
        {
          
            Color TipColor = (FramesPassed < TipFrames / 10) ? Color.Red : Color.White;

            sb.DrawString(Resources.MediumFont, "Welcome to the Myth of Zebra!", welcomeTextPosition, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            sb.DrawString(Resources.LargeFont, "Press SPACEBAR to start", startTextPosition, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            sb.DrawString(Resources.SmallFont, Tips[CurrentTip], tipTextPosition, TipColor, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            if (IsShowing) sb.DrawString(Resources.MediumFont, "- TIPS: -", flashingTextPosition, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);

        }

        public override void Update(GameTime gameTime)
        {
            FramesPassed = (FramesPassed + 1) % TipFrames;
            if (FramesPassed == 0) 
            {
                int PrevTip = CurrentTip;
                do
                {
                    CurrentTip = NumGenerator.Next(Tips.Length);
                }
                while (PrevTip == CurrentTip);
                
                Vector2 tipTextSize = Resources.SmallFont.MeasureString(Tips[CurrentTip]);
                tipTextPosition = new Vector2(Utils.GameWidth / 2 - tipTextSize.X / 2, Utils.GameHeight * 9 / 10 - tipTextSize.Y * 3 / 2);
            }
            if (FramesPassed % (TipFrames / FlashingFreq) == 0) 
            {
                IsShowing = !IsShowing;
            }

            base.Update(gameTime);
        }

        private void SetTips() 
        {
            Tips = new string[] {
                "Killing enemies will make them die",
                "Taking damage causes Lunk to lose health",
                "You can kill enemies by attacking them",
                "The dungeon is very blue",
                "You can beat the game by finding the triangle piece",
                "Grabbing items will put them into your inventory",
                "If Lunk's health reaches zero, he may die",
                "The map shows you a map of the dungeon",
                "The dungeon has multiple rooms (more than one)",
                "Lunk can move if you press certain keyboard keys",
                "An invincible old man lurks in the dungeon...",
                "Going through doors probably takes you to different rooms",
                "Beware! A dragon named Aquafina roams the dungeon...",
                "The skeletons and bats might look cuddly, but they're not",
                "Watch out for creepy hands - they might try to cop a feel!",
                "Lunk can use his weapons if you press certain keyboard keys",
                "Moving around the dungeon is an effective way of exploring",
                "See a basement? Definitely explore it! (don't explore it)",
                "The dungeon is a little dangerous (you'll die instantly)",
                "Enemies can damage Lunk (I think). Watch out!",
            };
        }
    }
}
