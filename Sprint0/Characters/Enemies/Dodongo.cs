using Microsoft.Xna.Framework;
using Sprint0.Characters.Bosses.States.DodongoStates;
using Sprint0.GameModes;
using Sprint0.Sprites;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies
{
    public class Dodongo : AbstractCharacter
    {
        private double DirectionTimer;
        private readonly double DirectionDelay = 1000;    // Change direction every this many milliseconds.

        public Dodongo(Vector2 position)
        {
            // State fields
            State = new DodongoMovingState(this);

            // Combat fields
            Health = 1;    // Data here: https://strategywiki.org/wiki/The_Legend_of_Zelda/Bosses
            Damage = 2;    // Damage dealt

            // Movement fields
            Position = position;
        }

        public override void Update(GameTime gameTime)
        {
            DirectionTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (DirectionTimer - DirectionDelay > 0)
            {
                DirectionTimer = 0;
                State.ChangeDirection();
            }

            base.Update(gameTime);
        }

        public static ISprite GetSprite(ICharacterState state, Types.Direction direction) 
        {
            return GameModeManager.GetInstance().GameMode.GetDodongoSprite(state, direction);
        }
    }
}
