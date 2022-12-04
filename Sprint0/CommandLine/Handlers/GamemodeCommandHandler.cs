using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.GameModes;
using Sprint0.GameModes.GameModes;
using Sprint0.GameStates.GameStates;
using Sprint0.Levels.Utils;
using Sprint0.Player;
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
                (game.CurrentState as CommandLineState).SetNextState(new GameModeTransitionState(game, new DefaultMode()));
                return Utils.GetAlignedText(
                    "Successfully set gamemode to " + Words[0] + ".",
                    ResponseFont, MaxResponseWidth);
            }
            if (Words[0].Equals("GOOMBA"))
            {
                //GameModeManager.GetInstance().ChangeGameMode(new GoombaMode(), game);
                return Utils.GetAlignedText(
                    "It's time to show that filthy plumber who's boss...",
                    ResponseFont, MaxResponseWidth);
            }
            if (Words[0].Equals("MARIO"))
            {
                //GameModeManager.GetInstance().ChangeGameMode(new MarioMode(), game);
                return Utils.GetAlignedText(
                    "It's a me!",
                    ResponseFont, MaxResponseWidth);
            }
            if (Words[0].Equals("MINECRAFT"))
            {
                (game.CurrentState as CommandLineState).SetNextState(new GameModeTransitionState(game, new MinecraftMode()));
                return Utils.GetAlignedText(
                    "Awww man...",
                    ResponseFont, MaxResponseWidth);
            }
            return Utils.GetAlignedText(
                "Unknown <ObjectType> " + Words[0] + ".",
                ResponseFont, MaxResponseWidth);
        }
    }
}
