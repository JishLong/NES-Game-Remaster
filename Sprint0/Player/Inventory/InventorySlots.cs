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
            Vector2 SelectionSquare = new((int)((128 + 24 * SelectedColumn) * Utils.GameScale), (int)((48 + 16 * SelectedRow) * Utils.GameScale));

            Vector2 Boomerang = new((int)(132 * Utils.GameScale), (int)(52 * Utils.GameScale));
            Vector2 Bomb = new((int)(156 * Utils.GameScale), (int)(48 * Utils.GameScale));
            Vector2 Arrow = new((int)(176 * Utils.GameScale), (int)(48 * Utils.GameScale));
            Vector2 Bow = new((int)(184 * Utils.GameScale), (int)(48 * Utils.GameScale));
            Vector2 Candle = new((int)(204 * Utils.GameScale), (int)(48 * Utils.GameScale));
            Vector2 Potion = new((int)(180 * Utils.GameScale), (int)(64 * Utils.GameScale));

            if (Player.Inventory.HasItem(Types.Item.WOODEN_BOOMERANG))
                new WoodenBoomerangSprite().Draw(sb, Boomerang, Color.White, 0.18f);
            if (Player.Inventory.HasItem(Types.Item.BOMB))
                new BombSprite().Draw(sb, Bomb, Color.White, 0.18f);
            if (Player.Inventory.HasItem(Types.Item.BOW))
            {
                new ArrowSprite().Draw(sb, Arrow, Color.White, 0.18f);
                new BowSprite().Draw(sb, Bow, Color.White, 0.18f);
            }
            if (Player.Inventory.HasItem(Types.Item.BLUE_CANDLE))
                new BlueCandleSprite().Draw(sb, Candle, Color.White, 0.18f);
            if (Player.Inventory.HasItem(Types.Item.BLUE_POTION))
                new BluePotionSprite().Draw(sb, Potion, Color.White, 0.18f);

            SelectedSlotSprite.Draw(sb, SelectionSquare, Color.White, 0.18f);
        }

        private void SetSelectedItem()
        {
            SelectedRow = Player.Inventory.SelectedRow;
            SelectedColumn = Player.Inventory.SelectedColumn;
        }
    }
}
