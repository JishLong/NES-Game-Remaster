using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Player.Inventory;
using Sprint0.Sprites;
using Sprint0.Sprites.Player;
using System.Collections.Generic;
using System.Data;

namespace Sprint0.GameStates.GameStates
{
    public class InventoryState : AbstractGameState
    {
        private static readonly int HUDHeight = (int)(56 * GameWindow.ResolutionScale);

        private readonly InventoryMap Map;
        private readonly InventorySlots Slots;

        private Rectangle InventoryPosition;
        private Vector2 SelectedItemPosition;
        private Vector2 MapPosition;
        private Vector2 CompassPosition;
        private Rectangle MiniMapPosition;

        public InventoryState(Game1 game) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetInventoryStateMappings(Game, this)),
            };

            Map = new(Game.LevelManager, Game.PlayerManager.GetDefaultPlayer());
            Slots = new(Game.PlayerManager.GetDefaultPlayer());

            SetElementPositions();
        }

        public override void Draw(SpriteBatch sb)
        {
            Camera.GetInstance().Move(Types.Direction.UP, HUDHeight);

            // Inventory layout
            sb.Draw(Resources.GuiSpriteSheet, Utils.LinkToCamera(InventoryPosition), Resources.Inventory, Color.White,
              0f, Vector2.Zero, SpriteEffects.None, 0.19f);

            // Selected item
            ISprite SelectedItemSprite = null;
            if (Game.PlayerManager.GetDefaultPlayer().Inventory.SelectedItem == Types.Item.WOODEN_BOOMERANG)
                SelectedItemSprite = new WoodenBoomerangSprite();
            else if (Game.PlayerManager.GetDefaultPlayer().Inventory.SelectedItem == Types.Item.BOMB)
                SelectedItemSprite = new BombSprite();
            else if (Game.PlayerManager.GetDefaultPlayer().Inventory.SelectedItem == Types.Item.BOW)
                SelectedItemSprite = new BowSprite();
            else if (Game.PlayerManager.GetDefaultPlayer().Inventory.SelectedItem == Types.Item.BLUE_CANDLE)
                SelectedItemSprite = new BlueCandleSprite();
            else if (Game.PlayerManager.GetDefaultPlayer().Inventory.SelectedItem == Types.Item.BLUE_POTION)
                SelectedItemSprite = new BluePotionSprite();
            if (SelectedItemSprite != null) SelectedItemSprite.Draw(sb, Utils.LinkToCamera(SelectedItemPosition), Color.White, 0.18f);

            // Map and compass
            if (Game.PlayerManager.GetDefaultPlayer().Inventory.HasItem(Types.Item.MAP)) new MapSprite()
                    .Draw(sb, Utils.LinkToCamera(MapPosition), Color.White, 0.18f);
            if (Game.PlayerManager.GetDefaultPlayer().Inventory.HasItem(Types.Item.COMPASS)) new CompassSprite()
                    .Draw(sb, Utils.LinkToCamera(CompassPosition), Color.White, 0.18f);

            // Inventory map
            Map.DrawPlayerLocation(sb, Utils.LinkToCamera(MiniMapPosition));
            Map.DrawMap(sb, Utils.LinkToCamera(MiniMapPosition));

            // Inventory slots
            Slots.Draw(sb);

            Camera.GetInstance().Move(Types.Direction.DOWN, (int)(176 * GameWindow.ResolutionScale));
            Game.PlayerManager.GetDefaultPlayer().HUD.Draw(sb);
            Camera.GetInstance().Move(Types.Direction.UP, (int)(120 * GameWindow.ResolutionScale));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Game.PlayerManager.GetDefaultPlayer().HUD.Update();
            Slots.Update();
        }

        private void SetElementPositions() 
        {
            InventoryPosition = new Rectangle(0, 0, GameWindow.DefaultScreenWidth, (int)(176 * GameWindow.ResolutionScale));
            SelectedItemPosition = new((int)(68 * GameWindow.ResolutionScale), (int)(48 * GameWindow.ResolutionScale));
            MapPosition = new((int)(48 * GameWindow.ResolutionScale), (int)(112 * GameWindow.ResolutionScale));
            CompassPosition = new((int)(44 * GameWindow.ResolutionScale), (int)(152 * GameWindow.ResolutionScale));
            MiniMapPosition = new((int)(124 * GameWindow.ResolutionScale),
                (int)(92 * GameWindow.ResolutionScale), (int)(9 * 8 * GameWindow.ResolutionScale), (int)(9 * 8 * GameWindow.ResolutionScale));
        }
    }
}
