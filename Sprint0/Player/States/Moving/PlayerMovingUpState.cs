using Sprint0.Sprites.Player.Movement;
using Sprint0.Player.State.Arrow;

namespace Sprint0.Player.State.Idle
{
    public class PlayerMovingUpState : AbstractPlayerState
    {
        public PlayerMovingUpState(Player player) : base(player)
        {
            Sprite = new PlayerMovingUp();
        }

        public PlayerMovingUpState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerMovingUp();
        }

        public override void ChangeDirection(Types.Direction direction)
        {
            if (IsChangingDirection) return;
            base.ChangeDirection(direction);

            switch (direction)
            {
                case Types.Direction.LEFT:
                    Player.State = new PlayerMovingLeftState(this);
                    break;
                case Types.Direction.RIGHT:
                    Player.State = new PlayerMovingRightState(this);
                    break;
                case Types.Direction.DOWN:
                    Player.State = new PlayerMovingDownState(this);
                    break;
                default:
                    break;
            }
        }

        public override void DoPrimaryAttack()
        {
            Player.State = new PlayerSwordUpState(this);
        }

        public override void DoSecondaryAttack()
        {
            switch (Player.SecondaryWeapon)
            {
                case Types.PlayerWeapon.BOW:
                    Player.State = new PlayerBowUpState(this);
                    break;
                case Types.PlayerWeapon.STAFF:
                    //Player.State = new PlayerStaffUpState(this);
                    break;
                case Types.PlayerWeapon.BOMB:
                    //Player.State = new PlayerBombUpState(this);
                    break;
                case Types.PlayerWeapon.BOOMERANG:
                    //Player.State = new PlayerBoomerangUpState(this);
                    break;
                default:
                    break;
            }
        }

        public override void StopAction()
        {
            Player.State = new PlayerFacingUpState(this);
        }

        public override void Update()
        {
            base.Update();

            Player.Position += Utils.DirectionToVector(Types.Direction.UP) * Player.MovementSpeed;
        }
    }
}
