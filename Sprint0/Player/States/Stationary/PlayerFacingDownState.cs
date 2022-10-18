using Sprint0.Sprites.Player.Stationary;
using Sprint0.Player.State.Arrow;
using Sprint0.Player.States.BlueArrow;
using Sprint0.Player.States.Flame;
using Sprint0.Player.States.Boomerang;

namespace Sprint0.Player.State.Idle
{
    public class PlayerFacingDownState : AbstractPlayerState
    {
        public PlayerFacingDownState(Player player) : base(player)
        {
            Sprite = new PlayerFacingDown();
        }

        public PlayerFacingDownState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerFacingDown();
        }

        public override void ChangeDirection(Types.Direction direction)
        {
            base.ChangeDirection(direction);

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
            base.DoPrimaryAttack();
            Player.State = new PlayerSwordDownState(this);
        }

        public override void DoSecondaryAttack()
        {
            switch (Player.SecondaryWeapon)
            {
                case Types.PlayerWeapon.ARROW:
                    Player.State = new PlayerArrowDownState(this);
                    break;
                case Types.PlayerWeapon.BLUEARROW:
                    Player.State = new PlayerBlueArrowDownState(this);
                    break;
                case Types.PlayerWeapon.BOMB:
                    Player.State = new PlayerBombDownState(this);
                    break;
                case Types.PlayerWeapon.BOOMERANG:
                    Player.State = new PlayerBoomerangDownState(this);
                    break;
                case Types.PlayerWeapon.FLAME:
                    Player.State = new PlayerFlameDownState(this);
                    break;
                default:
                    break;
            }
        }
    }
}
