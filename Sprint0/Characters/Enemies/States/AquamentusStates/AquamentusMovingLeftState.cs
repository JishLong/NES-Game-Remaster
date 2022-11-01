using Microsoft.Xna.Framework;
using Sprint0.Characters.Bosses.States.AquamentusStates;
using Sprint0.Characters.Enemies;
using Sprint0.Characters.Utils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Bosses.AquamentusStates
{
    // [NOTE]: Aquamentus only has a left facing sprite for movement.
    public class AquamentusMovingLeftState : AbstractCharacterState
    {
        private readonly Aquamentus Aquamentus;
        private Vector2 DirectionVector = Sprint0.Utils.DirectionToVector(Types.Direction.LEFT);
        private readonly float MovementSpeed = 1f;
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
            // UpLeft for logic purposes.
            Types.Direction direction = CharacterUtils.RandOrthogDirection(Types.Direction.LEFT);
            switch (direction)
            {
                case Types.Direction.RIGHT:
                    Aquamentus.State = new AquamentusMovingRightState(Aquamentus);
                    break;
                case Types.Direction.UP:
                    Aquamentus.State = new AquamentusMovingUpState(Aquamentus);
                    break;
                case Types.Direction.DOWN:
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
