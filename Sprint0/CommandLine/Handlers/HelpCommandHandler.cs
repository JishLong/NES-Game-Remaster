using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0.CommandLine.Handlers
{
    public class HelpCommandHandler
    {
        private readonly SpriteFont ResponseFont;
        private readonly int MaxResponseWidth;

        public HelpCommandHandler(SpriteFont font, int maxTextWidth) 
        {
            ResponseFont = font;
            MaxResponseWidth = maxTextWidth;
        }

        public List<string> HandleCommand(string parameters, Game1 game)
        {
            // Check for the correct number of parameters
            string[] Words = parameters.Split(' ');

            if (Words.Length > 1)
            {
                return Utils.GetAlignedText(
                    "Too many parameters. Expected either no parameters or an <OptionalPageNumber>.",
                    ResponseFont, MaxResponseWidth);
            }

            // Check for a page number
            int PageNumber;
            if (Words[0].Equals("")) PageNumber = 1;
            else if (!int.TryParse(Words[0], out PageNumber))
            {
                return Utils.GetAlignedText(
                    "A numerical value is required for <OptionalPageNumber>. Instead, found: " + Words[0] + ".",
                    ResponseFont, MaxResponseWidth);
            }
            if (PageNumber < 1 || PageNumber > 2) 
            {
                return Utils.GetAlignedText(
                    "Page number out of range. Try a page number between 1 and 2.",
                    ResponseFont, MaxResponseWidth);
            }

            // List out each command depending on the page number
            List<string> Response = new();
            if (PageNumber == 1)
            {
                Response.AddRange(Utils.GetAlignedText(
                    "- Help Page - 1 of 2 -",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "[ gamemode <GameModeType> ] - changes the gamemode to <GameModeType>.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "[ godmode <enable/disable> ] - enables or disables godmode.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "[ help <OptionalPageNumber> ] - shows a list of commands, their parameters, and their usages.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "[ inventory <add/remove> <ItemType> <Amount> ] - adds or removes items from the player's inventory.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "[ kill <ObjectType> <OptionalObject> ] - kills all <OptionalObject> of type <ObjectType> in the current room, " +
                    "or, if not specified, simply kills all objects of type <ObjectType> in the current room.",
                    ResponseFont, MaxResponseWidth));
            }
            else if (PageNumber == 2)
            {
                Response.AddRange(Utils.GetAlignedText(
                    "- Help Page - 2 of 2 -",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "[ list <ObjectType> ] - shows a list of all objects of type <ObjectType>.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "[ sethealth <HealthAmount> <MaxHealthAmount ] - sets both the player's health and max health values.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "[ spawn <ObjectType> <Object> <Amount> <X-Coordinate> <Y-Coordinate> ] - spawns objects in the current room.",
                    ResponseFont, MaxResponseWidth));
            }
            return Response;
        }
    }
}
