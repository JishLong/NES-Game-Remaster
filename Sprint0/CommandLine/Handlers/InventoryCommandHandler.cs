using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0.CommandLine.Handlers
{
    public class InventoryCommandHandler
    {
        private readonly SpriteFont ResponseFont;
        private readonly int MaxResponseWidth;

        public InventoryCommandHandler(SpriteFont font, int maxTextWidth)
        {
            ResponseFont = font;
            MaxResponseWidth = maxTextWidth;
        }

        public List<string> HandleCommand(string parameters, Game1 game)
        {
            string[] Words = parameters.Split(' ');

            // Check for correct parameter setup (must be 4 parameters)
            if (Words.Length != 3 || Words[0].Equals(""))
            {
                List<string> Response = new();
                Response.AddRange(Utils.GetAlignedText(
                    "This command requires exactly three parameters, which are:",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "<add/remove> - whether an item will be added or removed from the player's inventory.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "<ItemType> - the type of item that will be added or removed.",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "<Amount> - the amount of <ItemType> that will be added or removed.",
                    ResponseFont, MaxResponseWidth));
                return Response;
            }

            // Check for numerical amount value
            if (!int.TryParse(Words[2], out int Amount))
            {
                return Utils.GetAlignedText(
                    "A numerical value is required for <Amount>. Instead, found: " + Words[2] + ".",
                    ResponseFont, MaxResponseWidth);
            }

            // Check for a correct item
            bool ObjectExists = System.Enum.TryParse(Words[1], out Types.Item ItemType);
            if (!ObjectExists)
            {
                List<string> Response = new();

                Response.AddRange(Utils.GetAlignedText(
                    "Unknown <ItemType> " + Words[1] + ".",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(Utils.GetAlignedText(
                    "Try using one of these for the <ItemType>:",
                    ResponseFont, MaxResponseWidth));
                Response.Add("\n\n");
                Response.AddRange(new List<string>(System.Enum.GetNames(typeof(Types.Item))));
                return Response;
            }

            // Check to see if we're adding or removing the item
            Player.Inventory.Inventory Inventory = game.PlayerManager.GetDefaultPlayer().Inventory;
            if (Words[0].Equals("ADD"))
            {
                List<string> Response;
                if (Inventory.GetAmount(ItemType) + Amount > 99)
                {
                    Response = Utils.GetAlignedText(
                        "Maximum amount of " + Words[1] + " reached. Player now has 99 of " + Words[1] + ".",
                        ResponseFont, MaxResponseWidth);
                }
                else
                {
                    Response = Utils.GetAlignedText(
                        "Successfully added " + Words[2] + " of " + Words[1] + " to player's inventory.",
                        ResponseFont, MaxResponseWidth);
                }
                Inventory.AddToInventory(ItemType, Amount);
                return Response;
            }
            if (Words[0].Equals("REMOVE"))
            {
                List<string> Response;
                if (Inventory.GetAmount(ItemType) - Amount < 0)
                {   
                    Response = Utils.GetAlignedText(
                        "Minimum amount of " + Words[1] + " reached. Player now has 0 of " + Words[1] + ".",
                        ResponseFont, MaxResponseWidth);
                }
                else
                {                   
                    Response = Utils.GetAlignedText(
                        "Successfully added " + Words[2] + " of " + Words[1] + " to player's inventory.",
                        ResponseFont, MaxResponseWidth);
                }
                Inventory.RemoveFromInventory(ItemType, Amount);
                return Response;
            }

            // If we've made it this far, the user mistyped "add" or "remove"
            return Utils.GetAlignedText(
                "Expected to <add> or <remove> for <add/remove>. Instead, found " + Words[0] + ".",
                ResponseFont, MaxResponseWidth);
        }
    }
}
