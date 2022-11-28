using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using Sprint0.Sprites.HUD;
using Sprint0.Sprites.Player;

namespace Sprint0.Player.Inventory
{

    public class InventorySlots
    {
        private readonly IPlayer Player;

        private readonly ISprite SelectedSlotSprite;
        private int SelectedRow;
        private int SelectedColumn;

        public InventorySlots(IPlayer player)
        {
            Player = player;

            SetSelectedItem();
            SelectedSlotSprite = new SelectedSlotSprite();
        }

        public void Update()
        {
            SelectedSlotSprite.Update();
            SetSelectedItem();
        }

        public void Draw(SpriteBatch sb)
        {
            Vector2 SelectionSquare = new((int)((128 + 24 * SelectedColumn) * GameWindow.ResolutionScale), (int)((48 + 16 * SelectedRow) * GameWindow.ResolutionScale));

            Vector2 Boomerang = new((int)(132 * GameWindow.ResolutionScale), (int)(52 * GameWindow.ResolutionScale));
            Vector2 Bomb = new((int)(156 * GameWindow.ResolutionScale), (int)(48 * GameWindow.ResolutionScale));
            Vector2 Arrow = new((int)(176 * GameWindow.ResolutionScale), (int)(48 * GameWindow.ResolutionScale));
            Vector2 Bow = new((int)(184 * GameWindow.ResolutionScale), (int)(48 * GameWindow.ResolutionScale));
            Vector2 Candle = new((int)(204 * GameWindow.ResolutionScale), (int)(48 * GameWindow.ResolutionScale));
            Vector2 Potion = new((int)(180 * GameWindow.ResolutionScale), (int)(64 * GameWindow.ResolutionScale));

            if (Player.Inventory.HasItem(Types.Item.WOODENBOOMERANG))
                new WoodenBoomerangSprite().Draw(sb, Utils.LinkToCamera(Boomerang), Color.White, 0.18f);
            if (Player.Inventory.HasItem(Types.Item.BOMB))
                new BombSprite().Draw(sb, Utils.LinkToCamera(Bomb), Color.White, 0.18f);
            if (Player.Inventory.HasItem(Types.Item.BOW))
            {
                new ArrowSprite().Draw(sb, Utils.LinkToCamera(Arrow), Color.White, 0.18f);
                new BowSprite().Draw(sb, Utils.LinkToCamera(Bow), Color.White, 0.18f);
            }
            if (Player.Inventory.HasItem(Types.Item.BLUECANDLE))
                new BlueCandleSprite().Draw(sb, Utils.LinkToCamera(Candle), Color.White, 0.18f);
            if (Player.Inventory.HasItem(Types.Item.BLUEPOTION))
                new BluePotionSprite().Draw(sb, Utils.LinkToCamera(Potion), Color.White, 0.18f);

            SelectedSlotSprite.Draw(sb, Utils.LinkToCamera(SelectionSquare), Color.White, 0.18f);
        }

        private void SetSelectedItem()
        {
            SelectedRow = Player.Inventory.SelectedRow;
            SelectedColumn = Player.Inventory.SelectedColumn;
        }
    }
}
