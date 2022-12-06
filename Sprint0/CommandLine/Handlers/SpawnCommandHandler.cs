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
            List<string> Response = new();
            string[] Words = parameters.Split(' ');

            // Check for correct parameter setup (must be 4 parameters)
            if (Words.Length != 5 || Words[0].Equals(""))
            { 
                Response.AddRange(Utils.GetAlignedText(
                    "This command requires exactly five parameters, which are:",
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
                    "<Amount> - the amount of objects that will be spawned.",
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

            // Check for numerical amount value - must be between 1 and 99
            if (!int.TryParse(Words[2], out int Amount))
            {
                return Utils.GetAlignedText(
                    "A numerical value is required for <Amount>. Instead, found: " + Words[2] + ".",
                    ResponseFont, MaxResponseWidth);
            }
            if (Amount < 1 || Amount > 99)
            {
                return Utils.GetAlignedText(
                    "The <Amount> must be between 1 and 99. Instead, found: " + Words[2] + ".",
                    ResponseFont, MaxResponseWidth);
            }

            // Check for correct x-coordinate - must be able to spawn within the dungeon room
            if (!int.TryParse(Words[3], out int XCoord))
            {
                return Utils.GetAlignedText(
                    "A numerical value is required for <X-Coordinate>. Instead, found: " + Words[3] + ".",
                    ResponseFont, MaxResponseWidth);
            }
            if (XCoord < 1 || XCoord > 12) 
            {
                return Utils.GetAlignedText(
                    "The <X-Coordinate> must be between 1 and 12. Instead, found: " + Words[3] + ".",
                    ResponseFont, MaxResponseWidth);
            }

            // Check for correct y-coordinate - must be able to spawn within the dungeon room
            if (!int.TryParse(Words[4], out int YCoord))
            {
                return Utils.GetAlignedText(
                    "A numerical value is required for <Y-Coordinate>. Instead, found: " + Words[4] + ".",
                    ResponseFont, MaxResponseWidth);
            }
            if (YCoord < 1 || YCoord > 7)
            {
                return Utils.GetAlignedText(
                    "The <Y-Coordinate> must be between 1 and 7. Instead, found: " + Words[4] + ".",
                    ResponseFont, MaxResponseWidth);
            }

            // Check for a correct object to spawn - can either be an item or a character
            bool ObjectExists;
            if (Words[0].Equals("ITEM"))
            {
                // If the item exists, attempt to spawn it in
                ObjectExists = System.Enum.TryParse(Words[1], out Types.Item ItemType);
                if (ObjectExists) 
                {
                    for (int i = 0; i < Amount; i++)
                    {
                        IItem Item = ItemFactory.GetInstance().GetItem(ItemType,
                            new Vector2(16 * GameWindow.ResolutionScale * (1 + XCoord), 16 * GameWindow.ResolutionScale * (1 + YCoord)));
                        game.LevelManager.CurrentLevel.CurrentRoom.AddItemToRoom(Item);
                    }
                }
                else
                {
                    Response.AddRange(Utils.GetAlignedText(
                    "Unknown <Object> " + Words[1] + ".",
                    ResponseFont, MaxResponseWidth));
                    Response.Add("\n\n");
                    Response.AddRange(Utils.GetAlignedText(
                        "Try using one of these items for the <Object>:",
                        ResponseFont, MaxResponseWidth));
                    Response.Add("\n\n");
                    Response.AddRange(new List<string>(System.Enum.GetNames(typeof(Types.Item))));
                    return Response;
                }
            }
            else if (Words[0].Equals("CHARACTER"))
            {
                // If the character exists, attempt to spawn it in
                ObjectExists = System.Enum.TryParse(Words[1], out Types.Character CharacterType);
                if (ObjectExists)
                {
                    for (int i = 0; i < Amount; i++)
                    {
                        ICharacter Character = CharacterFactory.GetInstance().GetCharacter(CharacterType,
                            new Vector2(16 * GameWindow.ResolutionScale * (1 + XCoord), 16 * GameWindow.ResolutionScale * (1 + YCoord)));
                        game.LevelManager.CurrentLevel.CurrentRoom.AddCharacterToRoom(Character);
                    }
                }
                else 
                {
                    Response.AddRange(Utils.GetAlignedText(
                    "Unknown <Object> " + Words[1] + ".",
                    ResponseFont, MaxResponseWidth));
                    Response.Add("\n\n");
                    Response.AddRange(Utils.GetAlignedText(
                        "Try using one of these characters for the <Object>:",
                        ResponseFont, MaxResponseWidth));
                    Response.Add("\n\n");
                    Response.AddRange(new List<string>(System.Enum.GetNames(typeof(Types.Character))));
                    return Response;
                }
            }
            // If this happened, the object type must be wrong
            else 
            {
                Response.AddRange(Utils.GetAlignedText(
                    "Unknown <ObjectType> " + Words[0] + ".",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "Try using one of these for the <ObjectType>:",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\ncharacter\nitem");
                return Response;
            }

            // If we got here, then everything must have been successful
            return Utils.GetAlignedText(
                "Successfully spawned " + Words[2] + " " + Words[1] + "s at " + Words[3] + " " + Words[4] + ".",
                ResponseFont, MaxResponseWidth);
        }
    }
}
