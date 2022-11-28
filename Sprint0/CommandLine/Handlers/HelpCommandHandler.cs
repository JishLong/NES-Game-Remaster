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
            for (int i = 0; i < parameters.Length; i++) 
            {
                if (parameters[i] != ' ') return ErrorMessage;
            }

            List<string> Response = new();
            Response.AddRange(Utils.GetAlignedText(
                "[ help ] - shows a list of commands, their parameters, and their usages",
                ResponseFont, MaxResponseWidth));
            Response.AddRange(Utils.GetAlignedText(
                "[ list <ObjectType> ] - shows a list of all objects of type <ObjectType>",
                ResponseFont, MaxResponseWidth));
            Response.AddRange(Utils.GetAlignedText(
                "[ spawn <ObjectType> <Object> <X-Coordinate> <Y-Coordinate> ] - spawns an object in the current room",
                ResponseFont, MaxResponseWidth));

            return Response;
        }
    }
}
