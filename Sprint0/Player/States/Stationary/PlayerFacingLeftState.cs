using Sprint0.Sprites.Player.Stationary;
using Sprint0.Player.State.Bow;

namespace Sprint0.Player.State.Idle
{
    public class PlayerFacingLeftState : AbstractPlayerState
    {
        public PlayerFacingLeftState(Player player) : base(player)
        {
            Sprite = new PlayerFacingLeft();
        }

        public PlayerFacingLeftState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerFacingLeft();
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
            Player.State = new PlayerSwordLeftState(this);
        }

        public override void DoSecondaryAttack()
        {
            switch (Player.SecondaryWeapon)
            {
                case Types.PlayerWeapon.BOW:
                    Player.State = new PlayerBowLeftState(this);
                    break;
                case Types.PlayerWeapon.STAFF:
                    //Player.State = new PlayerStaffLeftState(this);
                    break;
                case Types.PlayerWeapon.BOMB:
                    //Player.State = new PlayerBombLeftState(this);
                    break;
                case Types.PlayerWeapon.BOOMERANG:
                    //Player.State = new PlayerBoomerangLeftState(this);
                    break;
                default:
                    break;
            }
        }
    }
}
