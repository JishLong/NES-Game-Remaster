using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0.CommandLine.Handlers
{
    public class SetHealthCommandHandler
    {
        private readonly SpriteFont ResponseFont;
        private readonly int MaxResponseWidth;

        public SetHealthCommandHandler(SpriteFont font, int maxTextWidth)
        {
            ResponseFont = font;
            MaxResponseWidth = maxTextWidth;
        }

        public List<string> HandleCommand(string parameters, Game1 game)
        {
            string[] Words = parameters.Split(' ');

            // Check for the correct parameter formatting
            if (Words.Length != 2)
            {
                return Utils.GetAlignedText(
                    "Two parameters are required, the <HealthAmount>, and the <MaxHealthAmount>.",
                    ResponseFont, MaxResponseWidth);
            }

            // Check for a correct numerical value for the health amount;
            if (!int.TryParse(Words[0], out int HealthAmount))
            {
                return Utils.GetAlignedText(
                    "A numerical value is required for <HealthAmount>. Instead, found: " + Words[0] + ".",
                    ResponseFont, MaxResponseWidth);
            }
            if (HealthAmount < 0 || HealthAmount > 99)
            {
                return Utils.GetAlignedText(
                    "Health amount out of range. Try a number between 0 and 99.",
                    ResponseFont, MaxResponseWidth);
            }

            // Check for a correct numerical value for the max health amount;
            if (!int.TryParse(Words[1], out int MaxHealthAmount))
            {
                return Utils.GetAlignedText(
                    "A numerical value is required for <HealthAmount>. Instead, found: " + Words[1] + ".",
                    ResponseFont, MaxResponseWidth);
            }
            if (MaxHealthAmount < 0 || MaxHealthAmount > 99)
            {
                return Utils.GetAlignedText(
                    "Max Health amount out of range. Try a number between 0 and 99.",
                    ResponseFont, MaxResponseWidth);
            }

            // Make sure the health isn't more than the max health, since that wouldn't make any sense
            if (HealthAmount > MaxHealthAmount)
            {
                return Utils.GetAlignedText(
                    "Error: <HealthAmount> greater than <MaxHealthAmount>. Could not set player's health.",
                    ResponseFont, MaxResponseWidth);
            }

            foreach (var player in game.PlayerManager) 
            {
                player.ChangeHealth(HealthAmount, MaxHealthAmount, game, Types.Direction.NO_DIRECTION, true);
            }

            // Let user know the operation was successful
            return Utils.GetAlignedText(
                "Successfully set player's health to " + Words[0] + " and max health to " + Words[1] + ".",
                ResponseFont, MaxResponseWidth);
        }
    }
}
