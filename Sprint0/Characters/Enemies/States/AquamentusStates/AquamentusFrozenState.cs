using Microsoft.Xna.Framework;
using Sprint0.Characters.Bosses.AquamentusStates;
using Sprint0.Characters.Enemies;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Bosses.States.AquamentusStates
{
    public class AquamentusFrozenState : AbstractCharacterState
    {
        private readonly Aquamentus Aquamentus;
        private double FrozenTimer;
        private readonly double FrozenDelay = 5000;
        public AquamentusFrozenState(Aquamentus aquamentus)
        {
            Aquamentus = aquamentus;
            Sprite = new AquamentusSprite();
        }
        public override void Attack()
        {
            // Do nothing. (Cant attack after frozen.)
        }
        public override void Move()
        {
            Aquamentus.State = new AquamentusMovingLeftState(Aquamentus);
        }
        public override void Freeze()
        {
            // Already frozen.
        }
        public override void ChangeDirection()
        {
            // Do nothing. Cant change direction while frozen.
        }
        public override void Update(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            FrozenTimer += elapsedTime;

            if ((FrozenTimer - FrozenDelay) > 0)
            {
                Move();
            }
            Sprite.Update();
        }
    }
}

