using Microsoft.Xna.Framework;
using Sprint0.Bosses.Interfaces;
using System;

namespace Sprint0.Bosses.Utils
{
    public class BossFactory
    {
        public IBoss GetBoss(string bossType, Vector2 position)
        {
            switch (bossType)
            {
                case "DODONGO":
                    return new Dodongo(position);

                case "AQUAMENTUS":
                    return new Aquamentus(position);

                default:
                    Console.Error.Write("Type " + bossType + " does not exist.");
                    return null;
            }
        }
    }
}