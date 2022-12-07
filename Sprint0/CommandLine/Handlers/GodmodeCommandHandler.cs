using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0.CommandLine.Handlers
{
    public class GodmodeCommandHandler
    {
        private readonly SpriteFont ResponseFont;
        private readonly int MaxResponseWidth;

        public GodmodeCommandHandler(SpriteFont font, int maxTextWidth)
        {
            ResponseFont = font;
            MaxResponseWidth = maxTextWidth;
        }

        public List<string> HandleCommand(string parameters, Game1 game)
        {
            string[] Words = parameters.Split(' ');

            // Check for the correct number of parameters
            if (Words.Length != 1 || Words[0].Equals(""))
            {
                return Utils.GetAlignedText(
                    "This command requires exactly one parameter, <enable/disable>.",
                    ResponseFont, MaxResponseWidth);
            }

            if (Words[0].Equals("ENABLE"))
            {
                foreach (var player in game.PlayerManager)
                {
                    player.GodmodeEnabled = true;
                    return Utils.GetAlignedText(
                        "Godmode successfully enabled.",
                        ResponseFont, MaxResponseWidth);
                }
            }
            if (Words[0].Equals("DISABLE"))
            {
                foreach (var player in game.PlayerManager)
                {
                    player.GodmodeEnabled = false;
                    return Utils.GetAlignedText(
                        "Godmode successfully disabled.",
                        ResponseFont, MaxResponseWidth);
                }
            }

            // If it's made it this far, the user typed in something wrong for the one parameter
            return Utils.GetAlignedText(
                "Expected \"enable\" or \"disable\" for <enable/disable>. Instead, found " + Words[0] + ".",
                ResponseFont, MaxResponseWidth);
        }
    }
}
