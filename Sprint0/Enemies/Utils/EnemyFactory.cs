using Microsoft.Xna.Framework;
using Sprint0.Enemies.Interfaces;
using System;

namespace Sprint0.Enemies.Utils
{
    public class EnemyFactory
    {
        public static readonly Vector2 DefaultEnemyPosition = new Vector2(350, 200);

        // Single point of use
        private static EnemyFactory Instance;

        // Used for switching between different enemies in-game
        private Types.Enemy[] Enemies = (Types.Enemy[])Enum.GetValues(typeof(Types.Enemy));
        private int CurrentEnemy = 0;

        private EnemyFactory() { }

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
                    Console.Error.Write("The enemy of type " + enemyType.ToString() +
                        " could not be instantiated by the Enemy Factory. Does this type exist?");
                    return null;
            }
        }

        // Returns an instance of the next enemy type in the [Enemies] array
        public IEnemy GetNextEnemy(Vector2 position) 
        {
            CurrentEnemy = (CurrentEnemy + 1) % Enemies.Length;
            return GetEnemy(Enemies[CurrentEnemy], position);
        }

        // Returns an instance of the previous enemy type in the [Enemies] array
        public IEnemy GetPrevEnemy(Vector2 position) 
        {
            CurrentEnemy = (CurrentEnemy - 1 + Enemies.Length) % Enemies.Length;
            return GetEnemy(Enemies[CurrentEnemy], position);
        }

        public static EnemyFactory GetInstance()
        {
            if (Instance == null)
            {
                Instance = new EnemyFactory();
            }
            return Instance;
        }
    }
}
