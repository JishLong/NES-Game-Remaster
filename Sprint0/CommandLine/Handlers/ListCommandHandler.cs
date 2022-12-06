using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0.CommandLine.Handlers
{
    public class ListCommandHandler
    {
        private readonly SpriteFont ResponseFont;
        private readonly int MaxResponseWidth;

        public ListCommandHandler(SpriteFont font, int maxTextWidth)
        {
            ResponseFont = font;
            MaxResponseWidth = maxTextWidth;
        }

        public List<string> HandleCommand(string parameters, Game1 game)
        {
            List<string> Response = new();
            string[] Words = parameters.Split(' ');

            // Check for correct number of parameters
            if (Words.Length != 1 || Words[0].Equals(""))
            {
                Response.AddRange(Utils.GetAlignedText(
                    "This command requires exactly one parameter, the <ObjectType>.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "Try using one of these for the <ObjectType>:",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\ncharacter\nitem\ngamemode");
                return Response;
            }

            // Check for a correct object type to list out
            if (Words[0].Equals("ITEM"))
            {
                return new List<string>(System.Enum.GetNames(typeof(Types.Item)));
            }
            if (Words[0].Equals("CHARACTER"))
            {
                return new List<string>(System.Enum.GetNames(typeof(Types.Character)));
            }
            if (Words[0].Equals("GAMEMODE"))
            {
                return new List<string>(System.Enum.GetNames(typeof(Types.GameMode)));
            }

            // If we've made it this far, the object type must be wrong
            Response.AddRange(Utils.GetAlignedText(
                    "Unknown <ObjectType> " + Words[0] + ".",
                    ResponseFont, MaxResponseWidth));
            Response.Add("\n\n");
            Response.AddRange(Utils.GetAlignedText(
                "Try using one of these for the <ObjectType>:",
                ResponseFont, MaxResponseWidth));
            Response.Add("\n\ncharacter\nitem\ngamemode");
            return Response;
        }
    }
}
