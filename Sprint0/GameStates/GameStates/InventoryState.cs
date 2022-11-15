using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Sprites;
using Sprint0.Sprites.GUI;
using Sprint0.Sprites.Player;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class InventoryState : AbstractGameState
    {
        private Types.Item[,] UsableItems;
        private ISprite SelectedSlotSprite;

        private int SelectedRow;
        private int SelectedColumn;

        public InventoryState(Game1 game) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetInventoryStateMappings(Game, this)),
            };

            UsableItems = game.Player.Inventory.GetUsableItems();
            SetSelectedItem();
            SelectedSlotSprite = new SelectedSlotSprite();
        }

        public override void Draw(SpriteBatch sb)
        {
            Camera.GetInstance().Move(Types.Direction.UP, (int)(56 * Utils.GameScale));
            Vector2 CameraPosition = Camera.GetInstance().Position;

            Rectangle InvArea = new Rectangle((int)CameraPosition.X, (int)CameraPosition.Y, Utils.GameWidth, (int)(176 * Utils.GameScale));

            Vector2 SelectedItem = new((int)(68 * Utils.GameScale), (int)(48 * Utils.GameScale));
            Vector2 Map = new((int)(48 * Utils.GameScale), (int)(112 * Utils.GameScale));
            Vector2 Compass = new((int)(44 * Utils.GameScale), (int)(152 * Utils.GameScale));
            Vector2 Boomerang = new((int)(132 * Utils.GameScale), (int)(52 * Utils.GameScale));
            Vector2 Bomb = new((int)(156 * Utils.GameScale), (int)(48 * Utils.GameScale));
            Vector2 Arrow = new((int)(176 * Utils.GameScale), (int)(48 * Utils.GameScale));
            Vector2 Bow = new((int)(184 * Utils.GameScale), (int)(48 * Utils.GameScale));
            Vector2 Candle = new((int)(204 * Utils.GameScale), (int)(48 * Utils.GameScale));
            Vector2 Potion = new((int)(180 * Utils.GameScale), (int)(64 * Utils.GameScale));

            Vector2 SelectionSquare = new((int)((128 + 24 * SelectedColumn) * Utils.GameScale), (int)((48 + 16 * SelectedRow) * Utils.GameScale));

            Rectangle MapArea = new((int)(CameraPosition.X + 124 * Utils.GameScale),
                (int)(CameraPosition.Y + 92 * Utils.GameScale), (int)(9 * 8 * Utils.GameScale), (int)(9 * 8 * Utils.GameScale));

            sb.Draw(Resources.GuiSpriteSheet, InvArea, Resources.Inventory, Color.White,
              0f, Vector2.Zero, SpriteEffects.None, 0.19f);

            sb.Draw(Resources.ScreenCover, MapArea, new Rectangle(0, 0, 10, 10), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);

            if (Game.Player.Inventory.SelectedItem == Types.Item.WOODEN_BOOMERANG)
                new WoodenBoomerangSprite().Draw(sb, SelectedItem, Color.White, 0.18f);
            else if (Game.Player.Inventory.SelectedItem == Types.Item.BOMB)
                new BombSprite().Draw(sb, SelectedItem, Color.White, 0.18f);
            else if (Game.Player.Inventory.SelectedItem == Types.Item.BOW)
                new BowSprite().Draw(sb, SelectedItem, Color.White, 0.18f);
            else if (Game.Player.Inventory.SelectedItem == Types.Item.BLUE_CANDLE)
                new BlueCandleSprite().Draw(sb, SelectedItem, Color.White, 0.18f);
            else if (Game.Player.Inventory.SelectedItem == Types.Item.BLUE_POTION)
                new BluePotionSprite().Draw(sb, SelectedItem, Color.White, 0.18f);

            if (Game.Player.Inventory.HasItem(Types.Item.MAP)) new MapSprite().Draw(sb, Map, Color.White, 0.18f);
            if (Game.Player.Inventory.HasItem(Types.Item.COMPASS)) new CompassSprite().Draw(sb, Compass, Color.White, 0.18f);
            if (Game.Player.Inventory.HasItem(Types.Item.WOODEN_BOOMERANG)) new WoodenBoomerangSprite().Draw(sb, Boomerang, Color.White, 0.18f);
            if (Game.Player.Inventory.HasItem(Types.Item.BOMB)) new BombSprite().Draw(sb, Bomb, Color.White, 0.18f);
            if (Game.Player.Inventory.HasItem(Types.Item.BOW)) 
            {
                new ArrowSprite().Draw(sb, Arrow, Color.White, 0.18f);
                new BowSprite().Draw(sb, Bow, Color.White, 0.18f);
            } 
            if (Game.Player.Inventory.HasItem(Types.Item.BLUE_CANDLE)) new BlueCandleSprite().Draw(sb, Candle, Color.White, 0.18f);
            if (Game.Player.Inventory.HasItem(Types.Item.BLUE_POTION)) new BluePotionSprite().Draw(sb, Potion, Color.White, 0.18f);

            SelectedSlotSprite.Draw(sb, SelectionSquare, Color.White, 0.18f);

            Camera.GetInstance().Move(Types.Direction.DOWN, (int)(176 * Utils.GameScale)); 
            Game.Player.HUD.Draw(sb);
            Camera.GetInstance().Move(Types.Direction.UP, (int)(120 * Utils.GameScale));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            SelectedSlotSprite.Update();
            SetSelectedItem();
        }

        private void SetSelectedItem() 
        {
            SelectedRow = Game.Player.Inventory.SelectedRow;
            SelectedColumn = Game.Player.Inventory.SelectedColumn;
        }
    }
}
