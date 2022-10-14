using Sprint0.Sprites.Player.Movement;
using Sprint0.Player.State.Bow;

namespace Sprint0.Player.State.Idle
{
    public class PlayerMovingLeftState : AbstractPlayerState
    {
        public PlayerMovingLeftState(Player player) : base(player)
        {
            Sprite = new PlayerMovingLeft();
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

        public override void StopAction()
        {
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
