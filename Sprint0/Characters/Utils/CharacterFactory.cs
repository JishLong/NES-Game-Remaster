using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies;
using Sprint0.Npcs;
using System;

namespace Sprint0.Characters.Utils
{
    public class CharacterFactory
    {
        // Single point of use
        private static CharacterFactory Instance;

        private CharacterFactory() { }

        public ICharacter GetCharacter(Types.Character characterType, Vector2 position, Types.Direction direction = Types.Direction.NO_DIRECTION,
            bool clockwise = false, string text = "")
        {
            switch (characterType)
            {
                case Types.Character.AQUAMENTUS:
                    return new Aquamentus(position);
                case Types.Character.BAT:
                    return new Bat(position);
                case Types.Character.BLADETRAP:
                    return new BladeTrap(position);
                case Types.Character.DODONGO:
                    return new Dodongo(position);
                case Types.Character.FLAME:
                    return new Flame(position);
                case Types.Character.GEL:
                    return new Gel(position);
                case Types.Character.HAND:
                    return new Hand(position, direction, clockwise);
                case Types.Character.OLDMAN:
                    return new OldMan(position);
                case Types.Character.REDGORIYA:
                    return new RedGoriya(position);
                case Types.Character.SECRETTEXT1:
                    return new SecretText(position, "EASTMOST PENINSULA IS THE SECRET.");
                case Types.Character.SECRETTEXT2:
                    return new SecretText(position, "DODONGO DISLIKES SMOKE.");
                case Types.Character.SKELETON:
                    return new Skeleton(position);
                case Types.Character.SNAKE:
                    return new Snake(position);
                case Types.Character.ZOL:
                    return new Zol(position); 
                default:
                    Console.Error.Write("The character of type " + characterType.ToString() +
                        " could not be instantiated by the Character Factory. Does this type exist?");
                    return null;
            }
        }

        public static CharacterFactory GetInstance()
        {
            Instance ??= new CharacterFactory();
            return Instance;
        }
    }
}
