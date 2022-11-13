using Microsoft.Xna.Framework;
using Sprint0.Items;
using Sprint0.Player.States;
using Sprint0.Player.States.BlueArrow;
using Sprint0.Sprites;
using Sprint0.Sprites.Player.Movement;

namespace Sprint0.Player.State.Idle
{
    public class PlayerMovingState : AbstractPlayerState
    {
        // Having single instances of these sprites makes movement look smoother if the player repeatedly taps one movement key
        private readonly static ISprite[] Sprites = { 
            new PlayerMovingUpSprite(), new PlayerMovingDownSprite(), new PlayerMovingLeftSprite(), new PlayerMovingRightSprite() 
        };

        private static readonly Vector2 MovementSpeed = new(4, 4);

        public PlayerMovingState(Player player) : base(player)
        {
            Player.IsStationary = false;
            Sprite = Sprites[(int)Player.FacingDirection];
        }

        public override void Move(Types.Direction direction)
        {
            Player.FacingDirection = direction;
            Sprite = Sprites[(int)direction];
        }

        public override void DoPrimaryAttack()
        {
            Player.State = new PlayerSwordState(Player);
        }

        public override void DoSecondaryAttack()
        {
            Player.State = new PlayerUseItemState(Player);
        }

        public override void StopAction()
        {
            Player.State = new PlayerIdleState(Player);
        }

        public override void Update()
        {
            base.Update();

            Player.Position += Utils.DirectionToVector(Player.FacingDirection) * MovementSpeed;
        }

        public override void HoldItem(IItem item)
        {
            Player.State = new PlayerHoldItemState(Player, item);
        }
    }
}
