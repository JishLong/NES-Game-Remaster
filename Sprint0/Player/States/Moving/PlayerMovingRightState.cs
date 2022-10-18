using Sprint0.Player.State.Arrow;
using Sprint0.Sprites.Player.Movement;
using Sprint0.Player.States.BlueArrow;
using Sprint0.Player.States.Flame;
using Sprint0.Player.States.Boomerang;

namespace Sprint0.Player.State.Idle
{
    public class PlayerMovingRightState : AbstractPlayerState
    {
        public PlayerMovingRightState(Player player) : base(player)
        {
            Sprite = new PlayerMovingRight();
            player.IsStationary = false;
        }

        public PlayerMovingRightState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerMovingRight();
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

        public override void StopAction()
        {
            base.StopAction();
            Player.State = new PlayerFacingRightState(this);
        }

        public override void Update()
        {
            base.Update();

            // Grabs a directional vector and scales it according to the player's movement speed
            Player.Position += Utils.DirectionToVector(Types.Direction.RIGHT) * Player.MovementSpeed;
        }
    }
}
