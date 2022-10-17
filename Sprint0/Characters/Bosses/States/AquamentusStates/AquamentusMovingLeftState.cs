using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Bosses.States;
using Sprint0.Characters.Bosses.States.AquamentusStates;
using Sprint0.Sprites.Characters.Bosses;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Bosses.AquamentusStates
{
    // [NOTE]: Aquamentus only has a left facing moving state. (i.e. default moving state is AquamentusMovingLeftState)
    // If needed (probably not), more direction states with different functionality can be implemented.
    public class AquamentusMovingLeftState : AbstractBossState
    {
        private Aquamentus Aquamentus;
        private Vector2 DirectionVector = ToVector(Direction.Left);
        private float MovementSpeed = 2f;
        public AquamentusMovingLeftState(Aquamentus aquamentus)
        {
            Aquamentus = aquamentus;
            Sprite = new AquamentusSprite();
        }
        public override void Attack()
        {
            Aquamentus.State = new AquamentusMovingLeftState(Aquamentus);
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
            Direction direction = RandOrthogDirection(Direction.Left);
            switch (direction)
            {
                case Direction.Right:
                    Aquamentus.State = new AquamentusMovingLeftState(Aquamentus);
                    break;
                case Direction.Up:
                    Aquamentus.State = new AquamentusMovingLeftState(Aquamentus);
                    break;
                case Direction.Down:
                    Aquamentus.State = new AquamentusMovingLeftState(Aquamentus);
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
