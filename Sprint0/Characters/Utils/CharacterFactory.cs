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

        public ICharacter GetCharacter(Types.Character characterType, Vector2 position)
        {
            switch (characterType)
            {
                case Types.Character.BAT:
                    return new Bat(position);
                case Types.Character.GEL:
                    return new Gel(position);
                case Types.Character.HAND:
                    return new Hand(position);
                case Types.Character.RED_GORIYA:
                    return new RedGoriya(position);
                case Types.Character.SKELETON:
                    return new Skeleton(position);
                case Types.Character.ZOL:
                    return new Zol(position);
                case Types.Character.AQUAMENTUS:
                    return new Aquamentus(position);
                case Types.Character.DODONGO:
                    return new Dodongo(position);
                case Types.Character.FLAME:
                    return new Flame(position);
                case Types.Character.OLDMAN:
                    return new OldMan(position);
                case Types.Character.SNAKE:
                    return new Snake(position);
                case Types.Character.BLADE_TRAP:
                    return new BladeTrap(position);
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
