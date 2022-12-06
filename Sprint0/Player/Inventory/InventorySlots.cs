﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using Sprint0.Sprites.Gui;
using Sprint0.Sprites.Items;

namespace Sprint0.Player.Inventory
{

    public class InventorySlots
    {
        private readonly IPlayer Player;
        private readonly ISprite SelectedSlotSprite;

        private readonly Rectangle BoomerangArea;
        private readonly Rectangle BombArea;
        private readonly Rectangle ArrowArea;
        private readonly Rectangle BowArea;
        private readonly Rectangle CandleArea;
        private readonly Rectangle PotionArea;

        private int SelectedRow;
        private int SelectedColumn;

        public InventorySlots(IPlayer player)
        {
            Player = player;
            SelectedSlotSprite = new SelectedSlotSprite();

            BoomerangArea = new((int)(132 * GameWindow.ResolutionScale), (int)(48 * GameWindow.ResolutionScale),
                (int)(8 * GameWindow.ResolutionScale), (int)(16 * GameWindow.ResolutionScale));
            BombArea = new((int)(156 * GameWindow.ResolutionScale), (int)(48 * GameWindow.ResolutionScale),
                (int)(8 * GameWindow.ResolutionScale), (int)(16 * GameWindow.ResolutionScale));
            ArrowArea = new((int)(176 * GameWindow.ResolutionScale), (int)(48 * GameWindow.ResolutionScale),
                (int)(8 * GameWindow.ResolutionScale), (int)(16 * GameWindow.ResolutionScale));
            BowArea = new((int)(184 * GameWindow.ResolutionScale), (int)(48 * GameWindow.ResolutionScale),
                (int)(8 * GameWindow.ResolutionScale), (int)(16 * GameWindow.ResolutionScale));
            CandleArea = new((int)(204 * GameWindow.ResolutionScale), (int)(48 * GameWindow.ResolutionScale),
                (int)(8 * GameWindow.ResolutionScale), (int)(16 * GameWindow.ResolutionScale));
            PotionArea = new((int)(180 * GameWindow.ResolutionScale), (int)(64 * GameWindow.ResolutionScale),
                (int)(8 * GameWindow.ResolutionScale), (int)(16 * GameWindow.ResolutionScale));

            SetSelectedItem();
        }

        public void Update()
        {
            SelectedSlotSprite.Update();
            SetSelectedItem();
        }

        public void Draw(SpriteBatch sb)
        {
            // Selection square
            Rectangle SelectedSlotArea = new((int)((128 + 24 * SelectedColumn) * GameWindow.ResolutionScale), 
                (int)((48 + 16 * SelectedRow) * GameWindow.ResolutionScale),
                (int)(16 * GameWindow.ResolutionScale), (int)(16 * GameWindow.ResolutionScale));
            Rectangle SpriteDrawbox = SelectedSlotSprite.GetDrawbox(SelectedSlotArea.Location.ToVector2());
            Vector2 SpritePosition = Utils.CenterRectangles(SelectedSlotArea, SpriteDrawbox.Width, SpriteDrawbox.Height);
            SelectedSlotSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.17f);

            // Items in each slot
            ISprite ItemSprite;
            if (Player.Inventory.HasItem(Types.Item.WOODENBOOMERANG))
            {
                ItemSprite = new WoodenBoomerangSprite();
                SpriteDrawbox = ItemSprite.GetDrawbox(BoomerangArea.Location.ToVector2());
                SpritePosition = Utils.CenterRectangles(BoomerangArea, SpriteDrawbox.Width, SpriteDrawbox.Height);
                ItemSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.18f);
            }
            if (Player.Inventory.HasItem(Types.Item.BOMB))
            {
                ItemSprite = new BombSprite();
                SpriteDrawbox = ItemSprite.GetDrawbox(BombArea.Location.ToVector2());
                SpritePosition = Utils.CenterRectangles(BombArea, SpriteDrawbox.Width, SpriteDrawbox.Height);
                ItemSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.18f);
            }
            // If the player has a bow, we'll essentially "give" them the arrow - both the bow and arrow get drawn
            if (Player.Inventory.HasItem(Types.Item.BOW))
            {
                ItemSprite = new BowSprite();
                SpriteDrawbox = ItemSprite.GetDrawbox(BowArea.Location.ToVector2());
                SpritePosition = Utils.CenterRectangles(BowArea, SpriteDrawbox.Width, SpriteDrawbox.Height);
                ItemSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.18f);

                ItemSprite = new ArrowSprite();
                SpriteDrawbox = ItemSprite.GetDrawbox(ArrowArea.Location.ToVector2());
                SpritePosition = Utils.CenterRectangles(ArrowArea, SpriteDrawbox.Width, SpriteDrawbox.Height);
                ItemSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.18f);
            }
            if (Player.Inventory.HasItem(Types.Item.BLUECANDLE))
            {
                ItemSprite = new BlueCandleSprite();
                SpriteDrawbox = ItemSprite.GetDrawbox(CandleArea.Location.ToVector2());
                SpritePosition = Utils.CenterRectangles(CandleArea, SpriteDrawbox.Width, SpriteDrawbox.Height);
                ItemSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.18f);
            }
            if (Player.Inventory.HasItem(Types.Item.BLUEPOTION))
            {
                ItemSprite = new BluePotionSprite();
                SpriteDrawbox = ItemSprite.GetDrawbox(PotionArea.Location.ToVector2());
                SpritePosition = Utils.CenterRectangles(PotionArea, SpriteDrawbox.Width, SpriteDrawbox.Height);
                ItemSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.18f);
            }
        }

        private void SetSelectedItem()
        {
            SelectedRow = Player.Inventory.SelectedRow;
            SelectedColumn = Player.Inventory.SelectedColumn;
        }
    }
}
