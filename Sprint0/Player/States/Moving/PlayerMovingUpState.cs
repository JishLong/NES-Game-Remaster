using Sprint0.Sprites.Player.Movement;
using Sprint0.Player.States.BlueArrow;

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
            /* If the user is holding down multiple movement keys, we don't want the player to be constantly changing direction;
             * This would cause the sprites to appear frozen since new states would be instantiated every game frame
             */
            if (Player.IsChangingDirection) return;
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
            base.DoPrimaryAttack();
            Player.State = new PlayerSwordUpState(this);
        }

        public override void DoSecondaryAttack()
        {
            base.DoSecondaryAttack();
            Player.State = new PlayerUseItemUpState(this);
        }

        public override void StopAction()
        {
            base.StopAction();
            Player.State = new PlayerFacingUpState(this);
        }

        public override void Update()
        {
            base.Update();

            Player.Position += Utils.DirectionToVector(Types.Direction.UP) * Player.MovementSpeed;
        }
    }
}
