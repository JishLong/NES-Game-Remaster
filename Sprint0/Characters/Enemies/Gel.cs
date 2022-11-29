using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States.GelStates;
using Sprint0.GameModes;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies
{
    public class Gel : AbstractCharacter
    {
        private double DirectionTimer = 0;
        private readonly double DirectionDelay = 1000;    // Change direction every this many milliseconds.

        public Gel(Vector2 position)
        {
            // State
            State = new GelMovingState(this);

            // The gel sprite is the same no matter its state, so we'll just instantiate it here
            Sprite = GameModeManager.GetInstance().GameMode.GetGelSprite(State, Types.Direction.UP);

            // Combat
            Health = 1;
            Damage = 1;

            // Movement
            Position = position;
        }

        public override void Update(GameTime gameTime)
        {
            DirectionTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if ((DirectionTimer - DirectionDelay) > 0)
            {
                DirectionTimer = 0;
                State.ChangeDirection();
            }

            base.Update(gameTime);
        }
    }
}
