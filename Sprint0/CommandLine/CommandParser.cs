using Microsoft.Xna.Framework.Graphics;
using Sprint0.CommandLine.Handlers;
using System.Collections.Generic;

namespace Sprint0.CommandLine
{
    public class CommandParser
    {
        private readonly HelpCommandHandler HelpCommandHandler;
        private readonly ListCommandHandler ListCommandHandler;
        private readonly SpawnCommandHandler SpawnCommandHandler;
        private readonly InventoryCommandHandler InventoryCommandHandler;
        private readonly GamemodeCommandHandler GamemodeCommandHandler;
        private readonly GodmodeCommandHandler GodmodeCommandHandler;

        private readonly List<string> ErrorMessage;

        public CommandParser(SpriteFont font, int maxTextWidth) 
        {
            HelpCommandHandler = new(font, maxTextWidth);
            ListCommandHandler = new(font, maxTextWidth);
            SpawnCommandHandler = new(font, maxTextWidth);
            InventoryCommandHandler = new(font, maxTextWidth);
            GamemodeCommandHandler = new(font, maxTextWidth);
            GodmodeCommandHandler = new(font, maxTextWidth);

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
                Command = commandLineText[..EndOfCommand];
                Parameters = commandLineText[(EndOfCommand + 1)..];
            }
            
            Command = Command.ToUpper();
            Parameters = Parameters.ToUpper();

            return Command switch
            {
                "HELP" => HelpCommandHandler.HandleCommand(Parameters, game),
                "LIST" => ListCommandHandler.HandleCommand(Parameters, game),
                "SPAWN" => SpawnCommandHandler.HandleCommand(Parameters, game),
                "INVENTORY" => InventoryCommandHandler.HandleCommand(Parameters, game),
                "GAMEMODE" => GamemodeCommandHandler.HandleCommand(Parameters, game),
                "GODMODE" => GodmodeCommandHandler.HandleCommand(Parameters, game),
                _ => ErrorMessage,
            };
        }
    }
}
