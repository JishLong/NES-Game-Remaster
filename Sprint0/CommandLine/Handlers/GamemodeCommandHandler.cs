using Microsoft.Xna.Framework.Graphics;
using Sprint0.GameModes.GameModes;
using Sprint0.GameStates.GameStates;
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
            List<string> Response = new();
            string[] Words = parameters.Split(' ');

            // Check for the correct number of parameters
            if (Words.Length != 1 || Words[0].Equals(""))
            {
                Response.AddRange(Utils.GetAlignedText(
                    "This command requires exactly one parameter, the <GameModeType>.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "Try using one of these for the <GameModeType>:",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(new List<string>(System.Enum.GetNames(typeof(Types.GameMode))));
                return Response;
            }

            // Check for a gamemode type
            if (Words[0].Equals("DEFAULTMODE"))
            {
                (game.CurrentState as CommandLineState).SetNextState(new GameModeTransitionState(game, new DefaultMode()));
                return Utils.GetAlignedText(
                    "Successfully set gamemode to " + Words[0] + ".",
                    ResponseFont, MaxResponseWidth);
            }

            if (Words[0].Equals("MOONMODE"))
            {
                (game.CurrentState as CommandLineState).SetNextState(new GameModeTransitionState(game, new MoonMode()));
                return Utils.GetAlignedText(
                    "Successfully set gamemode to " + Words[0] + ".",
                    ResponseFont, MaxResponseWidth);
            }

            if (Words[0].Equals("GOOMBAMODE"))
            {
                (game.CurrentState as CommandLineState).SetNextState(new GameModeTransitionState(game, new GoombaMode()));
                return Utils.GetAlignedText(
                    "It's time to show that filthy plumber who's boss...",
                    ResponseFont, MaxResponseWidth);
            }
            if (Words[0].Equals("MARIOMODE"))
            {
                (game.CurrentState as CommandLineState).SetNextState(new GameModeTransitionState(game, new MarioMode()));
                return Utils.GetAlignedText(
                    "It's a me!",
                    ResponseFont, MaxResponseWidth);
            }
            if (Words[0].Equals("MINECRAFTMODE"))
            {
                (game.CurrentState as CommandLineState).SetNextState(new GameModeTransitionState(game, new MinecraftMode()));
                return Utils.GetAlignedText(
                    "Awww man...",
                    ResponseFont, MaxResponseWidth);
            }

            // If it's made it this far, the gamemode type must have been wrong
            Response.AddRange(Utils.GetAlignedText(
                "Unknown <GameModeType> " + Words[0] + ".",
                ResponseFont, MaxResponseWidth));
            Response.Add("\n\n");
            Response.AddRange(Utils.GetAlignedText(
                "Try using one of these for the <GameModeType>:",
                ResponseFont, MaxResponseWidth));
            Response.Add("\n\n");
            Response.AddRange(new List<string>(System.Enum.GetNames(typeof(Types.GameMode))));
            return Response;
        }
    }
}
