﻿using Sprint0.Sprites.Player.Stationary;
using Sprint0.Player.States.BlueArrow;

namespace Sprint0.Player.State.Idle
{
    public class PlayerFacingRightState : AbstractPlayerState
    {
        public PlayerFacingRightState(Player player) : base(player)
        {
            Sprite = new PlayerFacingRight();
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
            base.DoSecondaryAttack();
            Player.State = new PlayerUseItemRightState(this);
        }
    }
}
