﻿using Sprint0.Player.State.Arrow;
using Sprint0.Sprites.Player.Movement;

namespace Sprint0.Player.State.Idle
{
    public class PlayerMovingDownState : AbstractPlayerState
    {
        public PlayerMovingDownState(Player player) : base(player)
        {
            Sprite = new PlayerMovingDown();
        }

        public PlayerMovingDownState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerMovingDown();
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
                case Types.Direction.UP:
                    Player.State = new PlayerMovingUpState(this);
                    break;
                default:
                    break;
            }
        }

        public override void DoPrimaryAttack()
        {
            Player.State = new PlayerSwordDownState(this);
        }

        public override void DoSecondaryAttack()
        {
            switch (Player.SecondaryWeapon)
            {
                case Types.PlayerWeapon.BOW:
                    Player.State = new PlayerBowDownState(this);
                    break;
                case Types.PlayerWeapon.STAFF:
                    //Player.State = new PlayerStaffDownState(this);
                    break;
                case Types.PlayerWeapon.BOMB:
                    //Player.State = new PlayerBombDownState(this);
                    break;
                case Types.PlayerWeapon.BOOMERANG:
                    //Player.State = new PlayerBoomerangDownState(this);
                    break;
                default:
                    break;
            }
        }

        public override void StopAction()
        {
            Player.State = new PlayerFacingDownState(this);
        }

        public override void Update()
        {
            base.Update();

            // Grabs a directional vector and scales it according to the player's movement speed
            Player.Position += Utils.DirectionToVector(Types.Direction.DOWN) * Player.MovementSpeed;
        }
    }
}