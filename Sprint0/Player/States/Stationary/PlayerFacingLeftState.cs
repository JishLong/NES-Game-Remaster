using Sprint0.Sprites.Player.Stationary;
using Sprint0.Player.States.BlueArrow;

namespace Sprint0.Player.State.Idle
{
    public class PlayerFacingLeftState : AbstractPlayerState
    {
        public PlayerFacingLeftState(Player player) : base(player)
        {
            Sprite = new PlayerFacingLeft();
            player.IsStationary = true;
        }

        public PlayerFacingLeftState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerFacingLeft();
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
            Player.State = new PlayerSwordLeftState(this);
        }

        public override void DoSecondaryAttack()
        {
            Player.State = new PlayerUseItemLeftState(this);
        }
    }
}
