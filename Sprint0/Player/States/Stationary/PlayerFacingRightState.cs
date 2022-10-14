using Sprint0.Player.State.Arrow;
using Sprint0.Sprites.Player.Stationary;

namespace Sprint0.Player.State.Idle
{
    public class PlayerFacingRightState : AbstractPlayerState
    {
        public PlayerFacingRightState(Player player) : base(player)
        {
            Sprite = new PlayerFacingRight();
        }

        public PlayerFacingRightState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerFacingRight();
        }

        public override void ChangeDirection(Types.Direction direction)
        {
            switch (direction)
            {
                case Types.Direction.LEFT:
                    Player.State = new PlayerMovingLeftState(this);
                    break;
                case Types.Direction.RIGHT:
                    Player.State = new PlayerMovingRightState(this);
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
    }
}
