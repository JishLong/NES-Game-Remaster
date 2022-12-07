using Microsoft.Xna.Framework.Graphics;
using Sprint0.GameModes.GameModes;
using Sprint0.GameStates.GameStates;
using System.Collections.Generic;

namespace Sprint0.CommandLine.Handlers
{
    public class SetLevelCommandHandler
    {
        private readonly SpriteFont ResponseFont;
        private readonly int MaxResponseWidth;

        public SetLevelCommandHandler(SpriteFont font, int maxTextWidth)
        {
            ResponseFont = font;
            MaxResponseWidth = maxTextWidth;
        }

        public List<string> HandleCommand(string parameters, Game1 game)
        {
            string[] Words = parameters.Split(' ');

            // Check for the correct parameter formatting
            if (Words.Length != 1)
            {
                return Utils.GetAlignedText(
                    "One parameter, <LevelName> is required.",
                    ResponseFont, MaxResponseWidth);
            }

            if (Words[0] != "LEVEL1" && Words[0] != "LEVEL2")
            {
                return Utils.GetAlignedText("Invalid level specified: " + "\"" + Words[0] + "\"",
                    ResponseFont, MaxResponseWidth);
            }

            Types.Level levelType = Types.Level.LEVEL1;
            switch (Words[0])
            {
                case "LEVEL1":
                    (game.CurrentState as CommandLineState).SetNextState(new GameModeTransitionState(game, new DefaultMode()));
                    levelType = Types.Level.LEVEL1;
                    break;
                case "LEVEL2":
                    (game.CurrentState as CommandLineState).SetNextState(new GameModeTransitionState(game, new MoonMode()));
                    levelType = Types.Level.LEVEL2;
                    break;
            }

            game.LevelManager.LoadLevel(levelType);
            

            // Let user know the operation was successful
            return Utils.GetAlignedText(
                "Successfully set level to " + Words[0] + ".",
                ResponseFont, MaxResponseWidth);
        }
    }
}
