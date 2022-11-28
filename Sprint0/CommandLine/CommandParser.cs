using Microsoft.Xna.Framework.Graphics;
using Sprint0.CommandLine.Handlers;
using System.Collections.Generic;

namespace Sprint0.CommandLine
{
    public class CommandParser
    {
        private readonly HelpCommandHandler HelpCommandHandler;

        private readonly List<string> ErrorMessage;

        public CommandParser(SpriteFont font, int maxTextWidth) 
        {
            HelpCommandHandler = new(font, maxTextWidth);

            ErrorMessage = Utils.GetAlignedText("Unknown command. Type \"help\" for a list of commands.", font, maxTextWidth);
        }

        public List<string> ParseCommand(string commandLineText, Game1 game) 
        {
            if (commandLineText.Length < 1) return ErrorMessage;

            string Command;
            string Parameters = "";
            int EndOfCommand = commandLineText.IndexOf(' ');

            if (EndOfCommand == -1) Command = commandLineText;
            else 
            {
                Command = commandLineText.Substring(0, EndOfCommand);
                Parameters = commandLineText.Substring(EndOfCommand);
            }
            
            Command = Command.ToLower();
            Parameters = Parameters.ToLower();

            return Command switch
            {
                "help" => HelpCommandHandler.HandleCommand(Parameters, game),
                _ => ErrorMessage,
            };
        }
    }
}
