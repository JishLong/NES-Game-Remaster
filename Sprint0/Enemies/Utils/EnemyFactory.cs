using Microsoft.Xna.Framework;
using Sprint0.Enemies.Interfaces;
using System;

namespace Sprint0.Enemies.Utils
{
    public class EnemyFactory
    {
        private Types.Enemy[] enemies = (Types.Enemy[])Enum.GetValues(typeof(Types.Enemy));
        private int index = 0;

        private static EnemyFactory instance;

        private EnemyFactory() 
        {
        
        }

        public IEnemy GetEnemy(Types.Enemy enemyType, Vector2 position)
        {
            switch (enemyType)
            {
                case Types.Enemy.BAT:
                    return new Bat(position);
                case Types.Enemy.GEL:
                    return new Gel(position);
                case Types.Enemy.HAND:
                    return new Hand(position);
                case Types.Enemy.RED_GORIYA:
                    return new RedGoriya(position);
                case Types.Enemy.SKELETON:
                    return new Skeleton(position);
                case Types.Enemy.ZOL:
                    return new Zol(position);
                default:
                    Console.Error.Write("The concrete type " + enemyType + " could not be instantiated by the Enemy Factory. Does this type exist?");
                    return null;
            }
        }

        public IEnemy GetNextEnemy(Vector2 position) 
        {
            index = (index + 1) % enemies.Length;
            return GetEnemy(enemies[index], position);
        }

        public IEnemy GetPrevEnemy(Vector2 position) 
        {
            index = (index - 1 + enemies.Length) % enemies.Length;
            return GetEnemy(enemies[index], position);
        }

        public static EnemyFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new EnemyFactory();
            }
            return instance;
        }
    }
}
