using Microsoft.Xna.Framework;
using System;

namespace Sprint0.Items.Utils
{
    public class ItemFactory
    {
        public static readonly Vector2 DefaultItemPosition = new Vector2(600, 200);

        // Single point of use
        private static ItemFactory Instance;

        // Used for switching between different items in-game
        private Types.Item[] Items = (Types.Item[])Enum.GetValues(typeof(Types.Item));
        private int CurrentItem = 0;

        private ItemFactory() { }

        public IItem GetItem(Types.Item itemType, Vector2 position)
        {
            switch (itemType)
            {
                case Types.Item.ARROW:
                    return new Arrow(position);
                case Types.Item.BLUE_CANDLE:
                    return new BlueCandle(position);
                case Types.Item.BLUE_POTION:
                    return new BluePotion(position);
                case Types.Item.BOMB:
                    return new Bomb(position);
                case Types.Item.BOW:
                    return new Bow(position);
                case Types.Item.CLOCK:
                    return new Clock(position);
                case Types.Item.COMPASS:
                    return new Compass(position);
                case Types.Item.FAIRY:
                    return new Fairy(position);
                case Types.Item.HEART:
                    return new Heart(position);
                case Types.Item.HEART_CONTAINER:
                    return new HeartContainer(position);
                case Types.Item.KEY:
                    return new Key(position);
                case Types.Item.MAP:
                    return new Map(position);
                case Types.Item.RUPEE:
                    return new Rupee(position);
                case Types.Item.TRIFORCE_PIECE:
                    return new TriforcePiece(position);
                case Types.Item.WOODEN_BOOMERANG:
                    return new WoodenBoomerang(position);
                default:
                    Console.Error.Write("The item of type " + itemType.ToString() +
                        " could not be instantiated by the Item Factory. Does this type exist?");
                    return null;
            }
        }

        // Returns an instance of the next item type in the [Items] array
        public IItem GetNextItem(Vector2 position)
        {
            CurrentItem = (CurrentItem + 1) % Items.Length;
            return GetItem(Items[CurrentItem], position);
        }

        // Returns an instance of the previous item type in the [Items] array
        public IItem GetPrevItem(Vector2 position)
        {
            CurrentItem = (CurrentItem - 1 + Items.Length) % Items.Length;
            return GetItem(Items[CurrentItem], position);
        }

        // Returns an instance of the beginning item type in the [Items array]
        public IItem GetBeginningItem(Vector2 position) 
        {
            CurrentItem = 0;
            return GetItem(Items[CurrentItem], position);
        }

        public static ItemFactory GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ItemFactory();
            }
            return Instance;
        }
    }
}
