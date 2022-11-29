using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Levels.Utils;
using System.Collections.Generic;

namespace Sprint0.CommandLine.Handlers
{
    public class GamemodeCommandHandler
    {
        private readonly SpriteFont ResponseFont;
        private readonly int MaxResponseWidth;

        public GamemodeCommandHandler(SpriteFont font, int maxTextWidth)
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
                    "This command requires exactly one parameter, the <GamemodeType>.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "Try typing \"gamemode normal\" or \"gamemode god\".",
                    ResponseFont, MaxResponseWidth));
                return Response;
            }

            if (Words[0].Equals("NORMAL"))
            {
                foreach (var player in game.PlayerManager)
                {
                    if (player.Gamemode == Types.Gamemode.GOOMBAMODE) player.ToggleGoombification();
                }
                return Utils.GetAlignedText(
                    "Successfully set gamemode to " + Words[0] + ".",
                    ResponseFont, MaxResponseWidth);
            }
            if (Words[0].Equals("GOOMBA"))
            {
                foreach (var player in game.PlayerManager)
                {
                    if (player.Gamemode != Types.Gamemode.GOOMBAMODE) player.ToggleGoombification();
                }
                return Utils.GetAlignedText(
                    "It's time to show that filthy plumber who's boss...",
                    ResponseFont, MaxResponseWidth);
            }
            return Utils.GetAlignedText(
                "Unknown <ObjectType> " + Words[0] + ".",
                ResponseFont, MaxResponseWidth);
        }
    }
}
