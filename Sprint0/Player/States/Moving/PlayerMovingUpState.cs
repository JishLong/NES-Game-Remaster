using Sprint0.Sprites.Player.Movement;
using Sprint0.Player.State.Arrow;
using Sprint0.Player.States.BlueArrow;
using Sprint0.Player.States.Flame;
using Sprint0.Player.States.Boomerang;

namespace Sprint0.Player.State.Idle
{
    public class PlayerMovingUpState : AbstractPlayerState
    {
        public PlayerMovingUpState(Player player) : base(player)
        {
            Sprite = new PlayerMovingUp();
            player.IsStationary = false;
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
            if (IsChangingDirection) return;
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

        public override void StopAction()
        {
            base.StopAction();
            Player.State = new PlayerFacingUpState(this);
        }

        public override void Update()
        {
            base.Update();

            // Grabs a directional vector and scales it according to the player's movement speed
            Player.Position += Utils.DirectionToVector(Types.Direction.UP) * Player.MovementSpeed;
        }
    }
}
