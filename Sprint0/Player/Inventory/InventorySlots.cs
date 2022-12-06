using Microsoft.Xna.Framework;
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
            Rectangle SpriteHitbox = SelectedSlotSprite.GetHitbox(SelectedSlotArea.Location.ToVector2());
            Vector2 SpritePosition = Utils.CenterRectangles(SelectedSlotArea, SpriteHitbox.Width, SpriteHitbox.Height);
            SelectedSlotSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.17f);

            // Items in each slot
            ISprite ItemSprite;
            if (Player.Inventory.HasItem(Types.Item.WOODENBOOMERANG))
            {
                ItemSprite = new WoodenBoomerangSprite();
                SpriteHitbox = ItemSprite.GetHitbox(BoomerangArea.Location.ToVector2());
                SpritePosition = Utils.CenterRectangles(BoomerangArea, SpriteHitbox.Width, SpriteHitbox.Height);
                ItemSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.18f);
            }
            if (Player.Inventory.HasItem(Types.Item.BOMB))
            {
                ItemSprite = new BombSprite();
                SpriteHitbox = ItemSprite.GetHitbox(BombArea.Location.ToVector2());
                SpritePosition = Utils.CenterRectangles(BombArea, SpriteHitbox.Width, SpriteHitbox.Height);
                ItemSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.18f);
            }
            // If the player has a bow, we'll essentially "give" them the arrow - both the bow and arrow get drawn
            if (Player.Inventory.HasItem(Types.Item.BOW))
            {
                ItemSprite = new BowSprite();
                SpriteHitbox = ItemSprite.GetHitbox(BowArea.Location.ToVector2());
                SpritePosition = Utils.CenterRectangles(BowArea, SpriteHitbox.Width, SpriteHitbox.Height);
                ItemSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.18f);

                ItemSprite = new ArrowSprite();
                SpriteHitbox = ItemSprite.GetHitbox(ArrowArea.Location.ToVector2());
                SpritePosition = Utils.CenterRectangles(ArrowArea, SpriteHitbox.Width, SpriteHitbox.Height);
                ItemSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.18f);
            }
            if (Player.Inventory.HasItem(Types.Item.BLUECANDLE))
            {
                ItemSprite = new BlueCandleSprite();
                SpriteHitbox = ItemSprite.GetHitbox(CandleArea.Location.ToVector2());
                SpritePosition = Utils.CenterRectangles(CandleArea, SpriteHitbox.Width, SpriteHitbox.Height);
                ItemSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.18f);
            }
            if (Player.Inventory.HasItem(Types.Item.BLUEPOTION))
            {
                ItemSprite = new BluePotionSprite();
                SpriteHitbox = ItemSprite.GetHitbox(PotionArea.Location.ToVector2());
                SpritePosition = Utils.CenterRectangles(PotionArea, SpriteHitbox.Width, SpriteHitbox.Height);
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
