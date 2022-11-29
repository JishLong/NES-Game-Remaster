using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0.CommandLine.Handlers
{
    public class HelpCommandHandler
    {
        private readonly SpriteFont ResponseFont;
        private readonly int MaxResponseWidth;

        private readonly List<string> ErrorMessage;

        public HelpCommandHandler(SpriteFont font, int maxTextWidth) 
        {
            ResponseFont = font;
            MaxResponseWidth = maxTextWidth;

            ErrorMessage = Utils.GetAlignedText(
                "Incorrect usage. This command doesn't use any parameters, simply type \"help\".", 
                font, maxTextWidth);
        }

        public List<string> HandleCommand(string parameters, Game1 game)
        {
            string[] Words = parameters.Split(' ');

            if (Words.Length > 1)
            {
                return Utils.GetAlignedText(
                    "Too many parameters. Expected either no parameters or an <OptionalPageNumber>.",
                    ResponseFont, MaxResponseWidth);
            }

            int PageNumber = 0;
            if (Words[0].Equals("")) PageNumber = 1;
            else if (!int.TryParse(Words[0], out PageNumber))
            {
                return Utils.GetAlignedText(
                    "A numerical value is required for <OptionalPageNumber>. Instead, found: " + Words[0] + ".",
                    ResponseFont, MaxResponseWidth);
            }
            if (PageNumber < 1 || PageNumber > 1) 
            {
                return Utils.GetAlignedText(
                    "Page number out of range. Try a page number between 1 and 1.",
                    ResponseFont, MaxResponseWidth);
            }

            List<string> Response = new();
            if (PageNumber == 1)
            {
                
                Response.AddRange(Utils.GetAlignedText(
                    "- Help Page - 1 of 1 -",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "[ gamemode <GamemodeType> ] - Changes the player's gamemode to <GamemodeType>.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "[ godmode <Enable/Disable> ] - Enables or disables godmode.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "[ help <OptionalPageNumber> ] - shows a list of commands, their parameters, and their usages.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "[ inventory <Add/Remove> <ItemType> <Amount> ] - adds or removes items from the player's inventory.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "[ list <ObjectType> ] - shows a list of all objects of type <ObjectType>.",
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
