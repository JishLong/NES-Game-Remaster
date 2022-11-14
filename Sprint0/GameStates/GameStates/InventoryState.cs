using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Sprites.Player;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class InventoryState : AbstractGameState
    {
        public InventoryState(Game1 game) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetInventoryStateMappings(Game, this)),
            };     
        }

        public override void Draw(SpriteBatch sb)
        {
            Camera.GetInstance().Move(Types.Direction.UP, (int)(56 * Utils.GameScale));
            Vector2 CameraPosition = Camera.GetInstance().Position;

            Rectangle InvArea = new Rectangle((int)CameraPosition.X, (int)CameraPosition.Y, Utils.GameWidth, (int)(176 * Utils.GameScale));
            Vector2 UseItem = new((int)(68 * Utils.GameScale), (int)(48 * Utils.GameScale));
            Vector2 Map = new((int)(48 * Utils.GameScale), (int)(112 * Utils.GameScale));
            Vector2 Compass = new((int)(44 * Utils.GameScale), (int)(152 * Utils.GameScale));
            Vector2 Boomerang = new((int)(132 * Utils.GameScale), (int)(52 * Utils.GameScale));
            Vector2 Bomb = new((int)(156 * Utils.GameScale), (int)(48 * Utils.GameScale));
            Vector2 Arrow = new((int)(176 * Utils.GameScale), (int)(48 * Utils.GameScale));
            Vector2 Bow = new((int)(184 * Utils.GameScale), (int)(48 * Utils.GameScale));
            Vector2 Candle = new((int)(204 * Utils.GameScale), (int)(48 * Utils.GameScale));
            Vector2 Potion = new((int)(180 * Utils.GameScale), (int)(64 * Utils.GameScale));

            sb.Draw(Resources.GuiSpriteSheet, InvArea, Resources.Inventory, Color.White,
              0f, Vector2.Zero, SpriteEffects.None, 0.19f); 
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

            Camera.GetInstance().Move(Types.Direction.DOWN, (int)(176 * Utils.GameScale)); 
            Game.Player.HUD.Draw(sb);
            Camera.GetInstance().Move(Types.Direction.UP, (int)(120 * Utils.GameScale));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
