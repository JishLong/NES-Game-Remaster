using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States.SkeletonStates;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies
{
    public class Skeleton : AbstractCharacter
    {
        private double DirectionTimer = 0;
        private readonly double DirectionDelay = 1500;    // Change direction every this many milliseconds.

        public Skeleton(Vector2 position) : base(Types.Character.SKELETON)
        {
            // The skeleton sprite is the same no matter its state, so we'll just instantiate it here
            Sprite = new SkeletonSprite();

            // State
            State = new SkeletonMovingState(this);

            // Combat
            Health = 2;
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
