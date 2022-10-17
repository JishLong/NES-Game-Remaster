using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Bosses.States;
using Sprint0.Characters.Bosses.States.AquamentusStates;
using Sprint0.Sprites.Characters.Bosses;
using static Sprint0.Characters.Bosses.Utils.BossUtils;

namespace Sprint0.Characters.Bosses.AquamentusStates
{
    // [NOTE]: Aquamentus only has a left facing sprite for movement.
    public class AquamentusMovingUpState : AbstractBossState
    {
        private Aquamentus Aquamentus;
        private Vector2 DirectionVector = ToVector(Direction.Up);
        private float MovementSpeed = 2f;
        public AquamentusMovingUpState(Aquamentus aquamentus)
        {
            Aquamentus = aquamentus;
            Sprite = new AquamentusSprite();
        }
        public override void Attack()
        {
            Aquamentus.State = new AquamentusMovingUpState(Aquamentus);
        }
        public override void Move()
        {
            Aquamentus.Position += DirectionVector * MovementSpeed;
        }
        public override void Freeze()
        {
            Aquamentus.State = new AquamentusFrozenState(Aquamentus);
        }
        public override void ChangeDirection()
        {
            // UpLeft for logic purposes.
            Direction direction = RandOrthogDirection(Direction.Up);
            switch (direction)
            {
                case Direction.Left:
                    Aquamentus.State = new AquamentusMovingLeftState(Aquamentus);
                    break;
                case Direction.Right:
                    Aquamentus.State = new AquamentusMovingRightState(Aquamentus);
                    break;
                case Direction.Down:
                    Aquamentus.State = new AquamentusMovingDownState(Aquamentus);
                    break;
            }
        }
        public override void Update(GameTime gameTime)
        {
            Move();
            Sprite.Update();
        }
    }
}
