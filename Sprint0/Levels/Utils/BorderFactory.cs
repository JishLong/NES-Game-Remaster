using Microsoft.Xna.Framework;
using Sprint0.Levels.Borders;
using System;

namespace Sprint0.Levels.Utils
{
    public class BorderFactory 
    {
        // Single point of use
        private static BorderFactory Instance;

        private BorderFactory() { }

        public IBorder GetBorder(Types.Border borderType)
        {
            switch (borderType)
            {
                case Types.Border.BLUE_BORDER:
                    return new BlueRoomBorder();
                case Types.Border.NONE:
                    return new NoneBorder();
                default:
                    Console.Error.Write("The border of type " + borderType.ToString() +
                        " could not be instantiated by the Border Factory. Does this type exist?");
                    return null;
            }
        }
        public static BorderFactory GetInstance()
        {
            if (Instance == null)
            {
                Instance = new BorderFactory();
            }
            return Instance;
        }
    }
}
