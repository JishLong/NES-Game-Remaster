using Microsoft.Xna.Framework;
using Sprint0.Enemies.Interfaces;
using System;

namespace Sprint0.Enemies.Utils
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

                case "HAND":
                    return new Hand(position);

                case "GEL":
                    return new Gel(position);

                case "RED_GORIYA":
                    return new RedGoriya(position);

                case "ZOL":
                    return new Zol(position);

                default:
                    Console.Error.Write("The concrete type " + enemyType + " could not be instantiated by the Enemy Factory. Does this type exist?");
                    return null;
            }
        }
    }
}
