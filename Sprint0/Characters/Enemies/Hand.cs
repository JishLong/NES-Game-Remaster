using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States.HandStates;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies
{
    public class Hand : AbstractCharacter
    {
        private double DirectionTimer = 0;
        private readonly double DirectionDelay = 1000;    // Change direction every this many milliseconds.

        public Hand(Vector2 position)
        {
            // The hand sprite is the same no matter its state, so we'll just instantiate it here
            // NOTE: THIS WILL CHANGE LATER, HAND SHOULD HAVE DIFFERENT SPRITES
            Sprite = new HandSprite();

            // State
            State = new HandMovingState(this, false);

            // Combat
            Health = 2;
            Damage = 1;

            // Movement
            Position = position;
        }

        public override void Update(GameTime gameTime)
        {
            DirectionTimer += gameTime.ElapsedGameTime.TotalMilliseconds; ;
            if ((DirectionTimer - DirectionDelay) > 0)
            {
                DirectionTimer = 0;
                State.ChangeDirection();
            }

            base.Update(gameTime);
        }
    }
}
