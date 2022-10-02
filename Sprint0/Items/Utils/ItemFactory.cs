using Microsoft.Xna.Framework;
using System;

namespace Sprint0.Items.Utils
{
    public class ItemFactory
    {
        private Types.Item[] Items = (Types.Item[])Enum.GetValues(typeof(Types.Item));
        private int Index = 0;

        private static ItemFactory Instance;

        private ItemFactory()
        {

        }

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
                    Console.Error.Write("The concrete type " + itemType + " could not be instantiated by the Block Factory. Does this type exist?");
                    return null;
            }
        }

        public IItem GetNextItem(Vector2 position)
        {
            Index = (Index + 1) % Items.Length;
            return GetItem(Items[Index], position);
        }

        public IItem GetPrevItem(Vector2 position)
        {
            Index = (Index - 1 + Items.Length) % Items.Length;
            return GetItem(Items[Index], position);
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
