using Sprint0.Player.State.Arrow;
using Sprint0.Sprites.Player.Movement;

namespace Sprint0.Player.State.Idle
{
    public class PlayerMovingRightState : AbstractPlayerState
    {
        public PlayerMovingRightState(Player player) : base(player)
        {
            Sprite = new PlayerMovingRight();
        }

        public PlayerMovingRightState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerMovingRight();
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
                case Types.Direction.UP:
                    Player.State = new PlayerMovingUpState(this);
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
            Player.State = new PlayerSwordRightState(this);
        }

        public override void DoSecondaryAttack()
        {
            switch (Player.SecondaryWeapon)
            {
                case Types.PlayerWeapon.BOW:
                    Player.State = new PlayerBowRightState(this);
                    break;
                case Types.PlayerWeapon.STAFF:
                    //Player.State = new PlayerStaffRightState(this);
                    break;
                case Types.PlayerWeapon.BOMB:
                    //Player.State = new PlayerBombRightState(this);
                    break;
                case Types.PlayerWeapon.BOOMERANG:
                    //Player.State = new PlayerBoomerangRightState(this);
                    break;
                default:
                    break;
            }
        }

        public override void StopAction()
        {
            Player.State = new PlayerFacingRightState(this);
        }

        public override void Update()
        {
            base.Update();

            Player.Position += Utils.DirectionToVector(Types.Direction.RIGHT) * Player.MovementSpeed;
        }
    }
}
