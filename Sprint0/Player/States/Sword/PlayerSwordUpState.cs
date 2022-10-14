using Sprint0.Sprites;
using Sprint0.Sprites.Player.Attack.SwordAttack;

namespace Sprint0.Player.State.Idle
{
    public class PlayerSwordUpState : AbstractPlayerState
    {
        public PlayerSwordUpState(Player player) : base(player)
        {
            Sprite = new PlayerSwordAttackUp();
        }

        public PlayerSwordUpState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerSwordAttackUp();
        }

        public override void ChangeDirection(Types.Direction direction)
        {
            if (IsChangingDirection || FramesPassed % ((AnimatedSprite)Sprite).GetAnimationTime() != 0) return;
            base.ChangeDirection(direction);

            switch (direction)
            {
                case Types.Direction.RIGHT:
                    Player.State = new PlayerSwordRightState(this);
                    break;
                case Types.Direction.LEFT:
                    Player.State = new PlayerSwordLeftState(this);
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

            if (FramesPassed % ((AnimatedSprite)Sprite).GetAnimationTime() == 0 && !IsAttacking) 
            {
                Player.State = new PlayerFacingUpState(this);
            }
        }
    }
}
