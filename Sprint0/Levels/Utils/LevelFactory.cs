using Microsoft.Xna.Framework;
using System;

namespace Sprint0.Levels.Utils
{
    public class LevelFactory 
    {
        // Single point of use
        private static LevelFactory Instance;

        private LevelFactory() { }

        public Level GetLevel(Types.Level levelType)
        {
            switch (levelType)
            {
                case Types.Level.LEVEL1:
                    return new Level("Level1", 2, 15);
                case Types.Level.LEVEL2:
                    return new Level("Level2", 1, 18);
                default:
                    Console.Error.Write("The level of type " + levelType.ToString() +
                        " could not be instantiated by the Level Factory. Does this type exist?");
                    return null;
            }
        }
        public static LevelFactory GetInstance()
        {
            if (Instance == null)
            {
                Instance = new LevelFactory();
            }
            return Instance;
        }
    }
}
