using Sprint0.Player.State.Arrow;
using Sprint0.Sprites.Player.Stationary;
using Sprint0.Player.States.BlueArrow;
using Sprint0.Player.States.Flame;
using Sprint0.Player.States.Boomerang;

namespace Sprint0.Player.State.Idle
{
    public class PlayerFacingRightState : AbstractPlayerState
    {
        public PlayerFacingRightState(Player player) : base(player)
        {
            Sprite = new PlayerFacingRight();
            player.IsStationary = true;
        }

        public PlayerFacingRightState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerFacingRight();
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
            Player.State = new PlayerSwordRightState(this);
        }

        public override void DoSecondaryAttack()
        {
            switch (Player.SecondaryWeapon)
            {
                case Types.PlayerWeapon.ARROW:
                    Player.State = new PlayerArrowRightState(this);
                    break;
                case Types.PlayerWeapon.BLUEARROW:
                    Player.State = new PlayerBlueArrowRightState(this);
                    break;
                case Types.PlayerWeapon.BOMB:
                    Player.State = new PlayerBombRightState(this);
                    break;
                case Types.PlayerWeapon.BOOMERANG:
                    Player.State = new PlayerBoomerangRightState(this);
                    break;
                case Types.PlayerWeapon.FLAME:
                    Player.State = new PlayerFlameRightState(this);
                    break;
                default:
                    break;
            }
        }
    }
}
