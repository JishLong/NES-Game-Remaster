using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;using Sprint0.Items;
using System.Collections.Generic;

namespace Sprint0.CommandLine.Handlers
{
    public class KillCommandHandler
    {
        private readonly SpriteFont ResponseFont;
        private readonly int MaxResponseWidth;

        public KillCommandHandler(SpriteFont font, int maxTextWidth)
        {
            ResponseFont = font;
            MaxResponseWidth = maxTextWidth;
        }

        public List<string> HandleCommand(string parameters, Game1 game)
        {
            List<string> Response = new();
            string[] Words = parameters.Split(' ');

            // Check for correct number of parameters
            if (Words.Length < 1 || Words.Length > 2 || Words[0].Equals(""))
            {
                Response.AddRange(Utils.GetAlignedText(
                    "This command requires one or two parameters, the <ObjectType>, and an optional <Object>. If the optional " +
                    "<Object> isn't specified, all instances of <ObjectType> in the room will be removed.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "Try using one of these for the <ObjectType>:",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\ncharacter\nitem\nplayer");
                return Response;
            }

            // Check for a correct object type to list out
            if (Words[0].Equals("ITEM"))
            {
                List<IItem> Items = game.LevelManager.CurrentLevel.CurrentRoom.Items;

                // Check to see if the user specified a certain item to remove
                if (Words.Length == 2)
                {
                    // If the item exists, attempt to remove it
                    bool ObjectExists = System.Enum.TryParse(Words[1], out Types.Item ItemType);
                    if (ObjectExists)
                    {
                        for (int i = Items.Count - 1; i >= 0; i--)
                        {
                            if (Items[i].GetItemType() == ItemType) Items.RemoveAt(i);
                        }
                        return Utils.GetAlignedText(
                        "Successfully destroyed all " + Words[1] + "s in the current room.",
                        ResponseFont, MaxResponseWidth);
                    }
                    // If it doesn't, list out some potential items to help out the user
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
                // Otherwise, just destroy all the items
                else 
                {
                    game.LevelManager.CurrentLevel.CurrentRoom.Items.Clear();
                    return Utils.GetAlignedText(
                        "Successfully destroyed all items in the current room.",
                        ResponseFont, MaxResponseWidth);
                }
            }
            if (Words[0].Equals("CHARACTER"))
            {
                List<ICharacter> Characters = game.LevelManager.CurrentLevel.CurrentRoom.Characters;

                // Check to see if the user specified a certain character to remove
                if (Words.Length == 2)
                {
                    // If the character exists, attempt to remove it
                    bool ObjectExists = System.Enum.TryParse(Words[1], out Types.Character CharacterType);
                    if (ObjectExists)
                    {
                        for (int i = Characters.Count - 1; i >= 0; i--)
                        {
                            if (Characters[i].GetCharacterType() == CharacterType)
                                Characters[i].TakeDamage(Types.Direction.NO_DIRECTION, int.MaxValue, game.LevelManager.CurrentLevel.CurrentRoom);
                        }
                        return Utils.GetAlignedText(
                        "Successfully killed all " + Words[1] + "s in the current room.",
                        ResponseFont, MaxResponseWidth);
                    }
                    // If it doesn't, list out some potential characters to help out the user
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
                // Otherwise, just destroy all the characters
                else
                {
                    for (int i = Characters.Count - 1; i >= 0; i--)
                    {
                        Characters[i].TakeDamage(Types.Direction.NO_DIRECTION, int.MaxValue, game.LevelManager.CurrentLevel.CurrentRoom);
                    }
                    game.LevelManager.CurrentLevel.CurrentRoom.Characters.Clear();
                    return Utils.GetAlignedText(
                        "Successfully killed all characters in the current room.",
                        ResponseFont, MaxResponseWidth);
                }
            }
            if (Words[0].Equals("PLAYER"))
            {
                // Make sure there isn't a specified object for player, since that wouldn't make any sense
                if (Words.Length == 2) 
                {
                    Response.AddRange(Utils.GetAlignedText(
                        "Unknown <Object> " + Words[1] + ".",
                        ResponseFont, MaxResponseWidth));
                    Response.Add("\n\n");
                    Response.AddRange(Utils.GetAlignedText(
                        "There is only one type of player, so an <Object> cannot be specified for the <ObjectType> player.",
                        ResponseFont, MaxResponseWidth));
                    return Response;
                }
                game.PlayerManager.GetDefaultPlayer().ChangeHealth(int.MinValue, int.MinValue, game);
                return Utils.GetAlignedText(
                    "You've successfully killed yourself. Happy now? You're probably not even reading this because you're dead.",
                    ResponseFont, MaxResponseWidth);
            }

            // If we've made it this far, the object type must be wrong
            Response.AddRange(Utils.GetAlignedText(
                    "Unknown <ObjectType> " + Words[0] + ".",
                    ResponseFont, MaxResponseWidth));
            Response.Add("\n\n");
            Response.AddRange(Utils.GetAlignedText(
                "Try using one of these for the <ObjectType>:",
                ResponseFont, MaxResponseWidth));
            Response.Add("\n\ncharacter\nitem\nplayer");
            return Response;
        }
    }
}
