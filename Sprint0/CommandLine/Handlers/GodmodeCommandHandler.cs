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

            if (Words.Length != 1 || Words[0].Equals(""))
            {
                return Utils.GetAlignedText(
                    "This command requires exactly one parameter, <Enable/Disable>.",
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
            return Utils.GetAlignedText(
                "Expected \"Enable\" or \"Disable\".",
                ResponseFont, MaxResponseWidth);
        }
    }
}
