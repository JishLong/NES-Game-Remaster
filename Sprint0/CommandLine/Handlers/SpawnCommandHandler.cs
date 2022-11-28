using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Characters.Utils;
using Sprint0.Items;
using Sprint0.Items.Utils;
using System.Collections.Generic;
using System.Numerics;

namespace Sprint0.CommandLine.Handlers
{
    public class SpawnCommandHandler
    {
        private readonly SpriteFont ResponseFont;
        private readonly int MaxResponseWidth;

        public SpawnCommandHandler(SpriteFont font, int maxTextWidth)
        {
            ResponseFont = font;
            MaxResponseWidth = maxTextWidth;
        }

        public List<string> HandleCommand(string parameters, Game1 game)
        {
            string[] Words = parameters.Split(' ');

            // Check for correct parameter setup (must be 4 parameters)
            if (Words.Length != 4 || Words[0].Equals(""))
            {
                List<string> Response = new();
                Response.AddRange(Utils.GetAlignedText(
                    "This command requires exactly four parameters, which are:",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "<ObjectType> - the type of object that will be spawned.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "<Object> - the object of type <ObjectType> that will be spawned.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "<X-Coordinate> - the x-coordinate (in room tiles) of the object that will be spawned.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "<Y-Coordinate> - the y-coordinate (in room tiles) of the object that will be spawned.",
                    ResponseFont, MaxResponseWidth));
                return Response;
            }

            // Check for correct x-coordinate - must be able to spawn within the dungeon room
            if (!int.TryParse(Words[2], out int XCoord))
            {
                return Utils.GetAlignedText(
                    "A numerical value is required for <X-Coordinate>. Instead, found: " + Words[2] + ".",
                    ResponseFont, MaxResponseWidth);
            }
            if (XCoord < 1 || XCoord > 12) 
            {
                return Utils.GetAlignedText(
                    "The <X-Coordinate> must be between 1 and 12. Instead, found: " + Words[2] + ".",
                    ResponseFont, MaxResponseWidth);
            }

            // Check for correct y-coordinate - must be able to spawn within the dungeon room
            if (!int.TryParse(Words[3], out int YCoord))
            {
                return Utils.GetAlignedText(
                    "A numerical value is required for <Y-Coordinate>. Instead, found: " + Words[3] + ".",
                    ResponseFont, MaxResponseWidth);
            }
            if (YCoord < 1 || YCoord > 7)
            {
                return Utils.GetAlignedText(
                    "The <Y-Coordinate> must be between 1 and 7. Instead, found: " + Words[3] + ".",
                    ResponseFont, MaxResponseWidth);
            }

            // Check for a correct object to spawn - can either be an item or a character
            bool ObjectExists;
            if (Words[0].Equals("ITEM"))
            {
                // If the item exists, spawn it in
                ObjectExists = System.Enum.TryParse(Words[1], out Types.Item ItemType);
                IItem Item = ItemFactory.GetInstance().GetItem(ItemType,
                    new Vector2(16 * GameWindow.ResolutionScale * (1 + XCoord), 16 * GameWindow.ResolutionScale * (1 + YCoord)));
                game.LevelManager.CurrentLevel.CurrentRoom.AddItemToRoom(Item);              
            }
            else if (Words[0].Equals("CHARACTER"))
            {
                // If the character exists, spawn it in
                ObjectExists = System.Enum.TryParse(Words[1], out Types.Character CharacterType);
                ICharacter Character = CharacterFactory.GetInstance().GetCharacter(CharacterType,
                    new Vector2(16 * GameWindow.ResolutionScale * (1 + XCoord), 16 * GameWindow.ResolutionScale * (1 + YCoord)));
                game.LevelManager.CurrentLevel.CurrentRoom.AddCharacterToRoom(Character);
            }
            else 
            {
                return Utils.GetAlignedText(
                    "Unknown <ObjectType> " + Words[0] + ".",
                    ResponseFont, MaxResponseWidth);
            }

            // Check to see if the object actually existed
            if (!ObjectExists) 
            {
                return Utils.GetAlignedText(
                    "Unknown " + Words[0] + " " + Words[1] + ".",
                    ResponseFont, MaxResponseWidth);
            }
            return Utils.GetAlignedText(
                "Successfully spawned " + Words[1] + " at " + Words[2] + " " + Words[3] + ".",
                ResponseFont, MaxResponseWidth);
        }
    }
}
