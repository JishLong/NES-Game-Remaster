using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Player.Inventory;
using Sprint0.Sprites;
using Sprint0.Sprites.Items;
using Sprint0.Sprites.Player;
using Sprint0.Sprites.Projectiles.Player;
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
        private Rectangle SelectedItemArea;
        private Rectangle MapArea;
        private Rectangle CompassArea;
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
            sb.Draw(ImageMappings.GetInstance().GuiSpriteSheet, Utils.LinkToCamera(InventoryPosition), ImageMappings.GetInstance().Inventory, Color.White,
              0f, Vector2.Zero, SpriteEffects.None, 0.19f);

            // Selected weapon
            ISprite ItemSprite;
            Rectangle SpriteDrawbox;
            Vector2 SpritePosition;
            ItemSprite = Game.PlayerManager.GetDefaultPlayer().Inventory.SelectedItem switch
            {
                Types.Item.BOW => new BowSprite(),
                Types.Item.WOODENBOOMERANG => new WoodenBoomerangSprite(),
                Types.Item.BOMB => new BombSprite(),
                Types.Item.BLUECANDLE => new BlueCandleSprite(),
                Types.Item.BLUEPOTION => new BluePotionSprite(),
                _ => null
            };
            if (ItemSprite != null)
            {
                SpriteDrawbox = ItemSprite.GetDrawbox(SelectedItemArea.Location.ToVector2());
                SpritePosition = Utils.CenterRectangles(SelectedItemArea, SpriteDrawbox.Width, SpriteDrawbox.Height);
                ItemSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.18f);
            }

            // Map and compass
            if (Game.PlayerManager.GetDefaultPlayer().Inventory.HasItem(Types.Item.MAP)) 
            {
                ItemSprite = new MapSprite();
                SpriteDrawbox = ItemSprite.GetDrawbox(MapArea.Location.ToVector2());
                SpritePosition = Utils.CenterRectangles(MapArea, SpriteDrawbox.Width, SpriteDrawbox.Height);
                ItemSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.18f);
            }
            if (Game.PlayerManager.GetDefaultPlayer().Inventory.HasItem(Types.Item.COMPASS))
            {
                ItemSprite = new CompassSprite();
                SpriteDrawbox = ItemSprite.GetDrawbox(CompassArea.Location.ToVector2());
                SpritePosition = Utils.CenterRectangles(CompassArea, SpriteDrawbox.Width, SpriteDrawbox.Height);
                ItemSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.18f);
            }

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
            SelectedItemArea = new((int)(68 * GameWindow.ResolutionScale), (int)(48 * GameWindow.ResolutionScale),
                (int)(8 * GameWindow.ResolutionScale), (int)(16 * GameWindow.ResolutionScale));
            MapArea = new((int)(48 * GameWindow.ResolutionScale), (int)(112 * GameWindow.ResolutionScale),
                (int)(8 * GameWindow.ResolutionScale), (int)(16 * GameWindow.ResolutionScale));
            CompassArea = new((int)(44 * GameWindow.ResolutionScale), (int)(152 * GameWindow.ResolutionScale),
                (int)(15 * GameWindow.ResolutionScale), (int)(16 * GameWindow.ResolutionScale));
            MiniMapPosition = new((int)(124 * GameWindow.ResolutionScale),
                (int)(92 * GameWindow.ResolutionScale), (int)(9 * 8 * GameWindow.ResolutionScale), (int)(9 * 8 * GameWindow.ResolutionScale));
        }
    }
}
