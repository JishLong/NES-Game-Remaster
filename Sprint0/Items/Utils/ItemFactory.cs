using Microsoft.Xna.Framework;
using Sprint0.Items.Items;
using System;

namespace Sprint0.Items.Utils
{
    public class ItemFactory
    {
        // Single point of use
        private static ItemFactory Instance;

        private ItemFactory() { }

        public IItem GetItem(Types.Item itemType, Vector2 position)
        {
            switch (itemType)
            {
                case Types.Item.ARROW:
                    return new Arrow(position);
                case Types.Item.BLUECANDLE:
                    return new BlueCandle(position);
                case Types.Item.BLUEPOTION:
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
                case Types.Item.HEARTCONTAINER:
                    return new HeartContainer(position);
                case Types.Item.KEY:
                    return new Key(position);
                case Types.Item.MAP:
                    return new Map(position);
                case Types.Item.RUPEE:
                    return new Rupee(position);
                case Types.Item.TRIFORCEPIECE:
                    return new TriforcePiece(position);
                case Types.Item.WOODENBOOMERANG:
                    return new WoodenBoomerang(position);
                case Types.Item.VALUABLERUPEE:
                    return new ValuableRupee(position);
                default:
                    Console.Error.Write("The item of type " + itemType.ToString() +
                        " could not be instantiated by the Item Factory. Does this type exist?");
                    return null;
            }
        }

        public static ItemFactory GetInstance()
        {
            Instance ??= new ItemFactory();
            return Instance;
        }
    }
}
