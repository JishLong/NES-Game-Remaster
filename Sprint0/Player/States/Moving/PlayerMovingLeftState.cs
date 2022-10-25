using Sprint0.Sprites.Player.Movement;
using Sprint0.Player.States.BlueArrow;

namespace Sprint0.Player.State.Idle
{
    public class PlayerMovingLeftState : AbstractPlayerState
    {
        public PlayerMovingLeftState(Player player) : base(player)
        {
            Sprite = new PlayerMovingLeft();
            player.IsStationary = false;
        }

        public PlayerMovingLeftState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerMovingLeft();
        }

        public override void ChangeDirection(Types.Direction direction)
        {
            /* If the user is holding down multiple movement keys, we don't want the player to be constantly changing direction;
             * This would cause the sprites to appear frozen since new states would be instantiated every game frame
             */
            if (IsChangingDirection) return;
            base.ChangeDirection(direction);

            switch (direction)
            {
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

        public override void StopAction()
        {
            base.StopAction();
            Player.State = new PlayerFacingLeftState(this);
        }

        public override void Update()
        {
            base.Update();

            // Grabs a directional vector and scales it according to the player's movement speed
            Player.Position += Utils.DirectionToVector(Types.Direction.LEFT) * Player.MovementSpeed;
        }
    }
}
