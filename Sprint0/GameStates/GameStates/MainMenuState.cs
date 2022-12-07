using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input.ClientInputHandlers;
using Sprint0.Input;
using System;
using System.Collections.Generic;
using Sprint0.Assets;

namespace Sprint0.GameStates.GameStates
{
    public class MainMenuState : AbstractGameState
    {
        private readonly IInputHandler ClientInputHandler;
        private readonly Random NumGenerator;

        // The number of frames each tip stays on the screen before a new one appears
        private readonly int TipFrames = 300;
        // How quickly the "tips" text flashes on the screen; Higher number = more flashing
        private readonly int FlashingFreq = 20;
        // How big the text appears on the screen; lower number = bigger text
        private readonly int TextScaling = 3;

        // The positions of each element on the screen
        private Vector2 WelcomeTextPosition;
        private Vector2 TitleTextPosition;
        private Vector2 StartTextPosition;
        private Vector2 FlashingTextPosition;
        private Vector2 TipTextPosition;

        // The tips that can show on the screen
        private string[] Tips;
        private int CurrentTip;

        // Logical variables to help check for certain conditions
        private bool IsShowing;
        private int FramesPassed;

        public MainMenuState(Game1 game) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetMainMenuStateMappings(Game)),
                new MouseController(MouseMappings.GetInstance().NoMappings, game)
            };

            NumGenerator = new();
            ClientInputHandler = new MainMenuClientInputHandler(game);

            // Set up the tips
            SetTips();
            CurrentTip = NumGenerator.Next(Tips.Length);

            SetElementPositions();

            IsShowing = true;
            FramesPassed = 0;
        }

        public override void Draw(SpriteBatch sb)
        {
            Color TipColor = (FramesPassed < TipFrames / 10) ? Color.Red : Color.White;

            sb.DrawString(FontMappings.GetInstance().SmallFont, "Welcome to...", WelcomeTextPosition, Color.White, 0f, new Vector2(0, 0),
                GameWindow.ResolutionScale / TextScaling, SpriteEffects.None, 0f);
            sb.DrawString(FontMappings.GetInstance().LargeFont, "The Myth of Zebra!", TitleTextPosition, Color.Aqua, 0f, new Vector2(0, 0),
                GameWindow.ResolutionScale / TextScaling, SpriteEffects.None, 0f);
            sb.DrawString(FontMappings.GetInstance().SmallFont, "Press SPACEBAR to start", StartTextPosition, Color.White, 0f, new Vector2(0, 0),
                GameWindow.ResolutionScale / TextScaling, SpriteEffects.None, 0f);
            if (IsShowing) sb.DrawString(FontMappings.GetInstance().MediumFont, "- TIPS: -", FlashingTextPosition, Color.White, 0f, new Vector2(0, 0),
                GameWindow.ResolutionScale / TextScaling, SpriteEffects.None, 0f);
            sb.DrawString(FontMappings.GetInstance().SmallFont, Tips[CurrentTip], TipTextPosition, TipColor, 0f, new Vector2(0, 0),
                GameWindow.ResolutionScale / TextScaling, SpriteEffects.None, 0f);
        }

        public override void Update(GameTime gameTime)
        {
            ClientInputHandler.Update();
            FramesPassed = (FramesPassed + 1) % TipFrames;

            if (FramesPassed == 0)
            {
                // Pick a new tip to show on the screen
                int PrevTip = CurrentTip;
                do
                {
                    CurrentTip = NumGenerator.Next(Tips.Length);
                }
                while (PrevTip == CurrentTip);

                // Set up the tip's position on the screen
                Vector2 tipTextSize = FontMappings.GetInstance().SmallFont.MeasureString(Tips[CurrentTip]);
                TipTextPosition = new Vector2(GameWindow.DefaultScreenWidth / 2 - tipTextSize.X * GameWindow.ResolutionScale / TextScaling / 2,
                    GameWindow.DefaultScreenHeight * 4 / 5 - tipTextSize.Y * GameWindow.ResolutionScale / TextScaling / 2);
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

        private void SetElementPositions()
        {
            Vector2 welcomeTextSize = FontMappings.GetInstance().SmallFont.MeasureString("Welcome to...");
            Vector2 titleTextSize = FontMappings.GetInstance().LargeFont.MeasureString("The Myth of Zebra!");
            Vector2 startTextSize = FontMappings.GetInstance().SmallFont.MeasureString("Press SPACEBAR to start");
            Vector2 flashingTextSize = FontMappings.GetInstance().MediumFont.MeasureString("- TIPS: -");
            Vector2 tipTextSize = FontMappings.GetInstance().SmallFont.MeasureString(Tips[CurrentTip]);

            WelcomeTextPosition = new Vector2(GameWindow.DefaultScreenWidth / 2 - welcomeTextSize.X * GameWindow.ResolutionScale / TextScaling / 2,
                GameWindow.DefaultScreenHeight / 5 - welcomeTextSize.Y * GameWindow.ResolutionScale / TextScaling / 2);
            TitleTextPosition = new Vector2(GameWindow.DefaultScreenWidth / 2 - titleTextSize.X * GameWindow.ResolutionScale / TextScaling / 2,
                GameWindow.DefaultScreenHeight / 4 - titleTextSize.Y * GameWindow.ResolutionScale / TextScaling / 2);
            StartTextPosition = new Vector2(GameWindow.DefaultScreenWidth / 2 - startTextSize.X * GameWindow.ResolutionScale / TextScaling / 2,
                GameWindow.DefaultScreenHeight / 2 - startTextSize.Y * GameWindow.ResolutionScale / TextScaling / 2);
            FlashingTextPosition = new Vector2(GameWindow.DefaultScreenWidth / 2 - flashingTextSize.X * GameWindow.ResolutionScale / TextScaling / 2,
                GameWindow.DefaultScreenHeight * 3 / 4 - flashingTextSize.Y * GameWindow.ResolutionScale / TextScaling / 2);
            TipTextPosition = new Vector2(GameWindow.DefaultScreenWidth / 2 - tipTextSize.X * GameWindow.ResolutionScale / TextScaling / 2,
                GameWindow.DefaultScreenHeight * 4 / 5 - tipTextSize.Y * GameWindow.ResolutionScale / TextScaling / 2);
        }

        public override void HandleClientInput(dynamic input, string id)
        {
            ClientInputHandler.HandleInput(input, id);
        }
    }
}
