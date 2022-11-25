using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Player.Inventory;
using Sprint0.Sprites.Player;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class InventoryState : AbstractGameState
    {
        private readonly InventoryMap Map;
        private readonly InventorySlots Slots;

        public InventoryState(Game1 game) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetInventoryStateMappings(Game, this)),
            };

            Map = new(Game.LevelManager, Game.PlayerManager.GetDefaultPlayer());
            Slots = new(Game.PlayerManager.GetDefaultPlayer());
        }

        public override void Draw(SpriteBatch sb)
        {
            Camera.GetInstance().Move(Types.Direction.UP, (int)(56 * Utils.GameScale));
            Vector2 CameraPosition = Camera.GetInstance().Position;

            // Positions for some things in the inventory
            Rectangle InvArea = new Rectangle((int)CameraPosition.X, (int)CameraPosition.Y, Utils.GameWidth, (int)(176 * Utils.GameScale));
            Vector2 SelectedItem = new((int)(68 * Utils.GameScale), (int)(48 * Utils.GameScale));
            Vector2 MapPosition = new((int)(48 * Utils.GameScale), (int)(112 * Utils.GameScale));
            Vector2 Compass = new((int)(44 * Utils.GameScale), (int)(152 * Utils.GameScale));
            Rectangle MapArea = new((int)(124 * Utils.GameScale),
                (int)(92 * Utils.GameScale), (int)(9 * 8 * Utils.GameScale), (int)(9 * 8 * Utils.GameScale));

            // Inventory layout
            sb.Draw(Resources.GuiSpriteSheet, InvArea, Resources.Inventory, Color.White,
              0f, Vector2.Zero, SpriteEffects.None, 0.19f);

            // Selected item
            if (Game.PlayerManager.GetDefaultPlayer().Inventory.SelectedItem == Types.Item.WOODEN_BOOMERANG)
                new WoodenBoomerangSprite().Draw(sb, SelectedItem, Color.White, 0.18f);
            else if (Game.PlayerManager.GetDefaultPlayer().Inventory.SelectedItem == Types.Item.BOMB)
                new BombSprite().Draw(sb, SelectedItem, Color.White, 0.18f);
            else if (Game.PlayerManager.GetDefaultPlayer().Inventory.SelectedItem == Types.Item.BOW)
                new BowSprite().Draw(sb, SelectedItem, Color.White, 0.18f);
            else if (Game.PlayerManager.GetDefaultPlayer().Inventory.SelectedItem == Types.Item.BLUE_CANDLE)
                new BlueCandleSprite().Draw(sb, SelectedItem, Color.White, 0.18f);
            else if (Game.PlayerManager.GetDefaultPlayer().Inventory.SelectedItem == Types.Item.BLUE_POTION)
                new BluePotionSprite().Draw(sb, SelectedItem, Color.White, 0.18f);

            // Map and compass
            if (Game.PlayerManager.GetDefaultPlayer().Inventory.HasItem(Types.Item.MAP)) new MapSprite().Draw(sb, MapPosition, Color.White, 0.18f);
            if (Game.PlayerManager.GetDefaultPlayer().Inventory.HasItem(Types.Item.COMPASS)) new CompassSprite().Draw(sb, Compass, Color.White, 0.18f);

            // Inventory map
            Map.DrawPlayerLocation(sb, MapArea);
            Map.DrawMap(sb, MapArea);

            // Inventory slots
            Slots.Draw(sb);

            Camera.GetInstance().Move(Types.Direction.DOWN, (int)(176 * Utils.GameScale)); 
            Game.PlayerManager.GetDefaultPlayer().HUD.Draw(sb);
            Camera.GetInstance().Move(Types.Direction.UP, (int)(120 * Utils.GameScale));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Game.PlayerManager.GetDefaultPlayer().HUD.Update();
            Slots.Update();
        }
    }
}
