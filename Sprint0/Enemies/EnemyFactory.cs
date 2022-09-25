using Microsoft.Xna.Framework;
using System;

namespace Sprint0.Enemies
{
    public class EnemyFactory
    { 
        public IEnemy GetEnemy(string enemyType, Vector2 position)
        {
            switch (enemyType)
            {
                case "SKELETON":
                    return new Skeleton(position);

                case "BAT":
                    return new Bat(position);
                default:
                    Console.Error.Write("The concrete type " + enemyType + " could not be instantiated by the Enemy Factory. Does this type exist?");
                    return null;
            }
        }
    }
}
