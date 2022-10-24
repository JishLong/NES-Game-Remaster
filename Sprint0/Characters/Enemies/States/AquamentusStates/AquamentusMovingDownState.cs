using Microsoft.Xna.Framework;
using Sprint0.Characters.Bosses.States.AquamentusStates;
using Sprint0.Characters.Enemies;
using Sprint0.Sprites.Characters.Enemies;
using Sprint0.Characters.Enemies.Utils;

namespace Sprint0.Characters.Bosses.AquamentusStates
{
    // [NOTE]: Aquamentus only has a left facing sprite for movement.
    public class AquamentusMovingDownState : AbstractCharacterState
    {
        private Aquamentus Aquamentus;
        private Vector2 DirectionVector = Utils.DirectionToVector(Types.Direction.DOWN);
        private float MovementSpeed = 2f;
        public AquamentusMovingDownState(Aquamentus aquamentus)
        {
            Aquamentus = aquamentus;
            Sprite = new AquamentusSprite();
        }
        public override void Attack()
        {
            Aquamentus.State = new AquamentusMovingDownState(Aquamentus);
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
            Types.Direction direction = CharacterUtils.RandOrthogDirection(Types.Direction.DOWN);
            switch (direction)
            {
                case Types.Direction.LEFT:
                    Aquamentus.State = new AquamentusMovingLeftState(Aquamentus);
                    break;
                case Types.Direction.RIGHT:
                    Aquamentus.State = new AquamentusMovingRightState(Aquamentus);
                    break;
                case Types.Direction.UP:
                    Aquamentus.State = new AquamentusMovingUpState(Aquamentus);
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
