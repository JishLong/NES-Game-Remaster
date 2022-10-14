using Sprint0.Sprites;
using Sprint0.Sprites.Player.Attack.SwordAttack;

namespace Sprint0.Player.State.Idle
{
    public class PlayerSwordRightState : AbstractPlayerState
    {
        public PlayerSwordRightState(Player player) : base(player)
        {
            Sprite = new PlayerSwordAttackRight();
        }

        public PlayerSwordRightState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerSwordAttackRight();
        }

        public override void ChangeDirection(Types.Direction direction)
        {
            /* If the user is holding down multiple movement keys, we don't want the player to be constantly changing direction;
             * This would cause the sprites to appear frozen since new states would be instantiated every game frame
             */
            if (IsChangingDirection || FramesPassed % ((AnimatedSprite)Sprite).GetAnimationTime() != 0) return;
            base.ChangeDirection(direction);

            switch (direction)
            {
                case Types.Direction.LEFT:
                    Player.State = new PlayerSwordLeftState(this);
                    break;
                case Types.Direction.UP:
                    Player.State = new PlayerSwordUpState(this);
                    break;
                case Types.Direction.DOWN:
                    Player.State = new PlayerSwordDownState(this);
                    break;
                default:
                    break;
            }
        }

        public override void Update()
        {
            base.Update();

            /* We don't want the player's sword attack animation to be abruptly cut off, so we switch the state only after a
             * full sword animation has played through
             * 
             * NOTE: potential coupling/abstraction break issue here - we're casting an interface to an extra abstract class,
             * might be something to fix in the future but works okay for now
             */
            if (FramesPassed % ((AnimatedSprite)Sprite).GetAnimationTime() == 0 && !IsPrimaryAttacking) 
            {
                Player.State = new PlayerFacingRightState(this);
            } 
        }
    }
}
