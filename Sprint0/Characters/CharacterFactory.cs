using Microsoft.Xna.Framework;
using Sprint0.Bosses;
using Sprint0.Enemies;
using Sprint0.Npcs;
using System;

namespace Sprint0.Characters
{
    public class CharacterFactory
    {
        public static readonly Vector2 DefaultCharacterPosition = new Vector2(350, 200);

        // Single point of use
        private static CharacterFactory Instance;

        // Used for switching between different enemies in-game
        private Types.Character[] Enemies = (Types.Character[])Enum.GetValues(typeof(Types.Character));
        private int CurrentCharacter = 0;

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
                default:
                    Console.Error.Write("The enemy of type " + characterType.ToString() +
                        " could not be instantiated by the Character Factory. Does this type exist?");
                    return null;
            }
        }

        // Returns an instance of the next enemy type in the [Enemies] array
        public ICharacter GetNextCharacter(Vector2 position)
        {
            CurrentCharacter = (CurrentCharacter + 1) % Enemies.Length;
            return GetCharacter(Enemies[CurrentCharacter], position);
        }

        // Returns an instance of the previous enemy type in the [Enemies] array
        public ICharacter GetPrevCharacter(Vector2 position)
        {
            CurrentCharacter = (CurrentCharacter - 1 + Enemies.Length) % Enemies.Length;
            return GetCharacter(Enemies[CurrentCharacter], position);
        }

        public ICharacter GetBeginningCharacter(Vector2 position) 
        {
            CurrentCharacter = 0;
            return GetCharacter(Enemies[CurrentCharacter], position);
        }

        public static CharacterFactory GetInstance()
        {
            if (Instance == null)
            {
                Instance = new CharacterFactory();
            }
            return Instance;
        }
    }
}
