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
            string[] Words = parameters.Split(' ');

            if (Words.Length != 1 || Words[0].Equals(""))
            {
                List<string> Response = new();
                Response.AddRange(Utils.GetAlignedText(
                    "This command requires exactly one parameter, the <ObjectType>.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "Try typing \"list item\" or \"list character\".",
                    ResponseFont, MaxResponseWidth));
                return Response;
            }

            if (Words[0].Equals("ITEM"))
            {
                return new List<string>(System.Enum.GetNames(typeof(Types.Item)));
            }
            if (Words[0].Equals("CHARACTER"))
            {
                return new List<string>(System.Enum.GetNames(typeof(Types.Character)));
            }
            return Utils.GetAlignedText(
                "Unknown <ObjectType> " + Words[0] + ".",
                ResponseFont, MaxResponseWidth);
        }
    }
}
