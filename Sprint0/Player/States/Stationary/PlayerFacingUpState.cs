using Sprint0.Sprites.Player.Stationary;
using Sprint0.Player.State.Arrow;
using Sprint0.Player.States.BlueArrow;
using Sprint0.Player.States.Flame;
using Sprint0.Player.States.Boomerang;

namespace Sprint0.Player.State.Idle
{
    public class PlayerFacingUpState : AbstractPlayerState
    {
        public PlayerFacingUpState(Player player) : base(player)
        {
            Sprite = new PlayerFacingUp();
        }

        public PlayerFacingUpState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerFacingUp();
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
            Player.State = new PlayerSwordUpState(this);
        }

        public override void DoSecondaryAttack()
        {
            switch (Player.SecondaryWeapon)
            {
                case Types.PlayerWeapon.ARROW:
                    Player.State = new PlayerArrowUpState(this);
                    break;
                case Types.PlayerWeapon.BLUEARROW:
                    Player.State = new PlayerBlueArrowUpState(this);
                    break;
                case Types.PlayerWeapon.BOMB:
                    Player.State = new PlayerBombUpState(this);
                    break;
                case Types.PlayerWeapon.BOOMERANG:
                    Player.State = new PlayerBoomerangUpState(this);
                    break;
                case Types.PlayerWeapon.FLAME:
                    Player.State = new PlayerFlameUpState(this);
                    break;
                default:
                    break;
            }
        }
    }
}
