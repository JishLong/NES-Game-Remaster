using Sprint0.Sprites.Player.Stationary;
using Sprint0.Sprites;
using Sprint0.Player.States;
using Sprint0.Items;
using Sprint0.Player.States.BlueArrow;

namespace Sprint0.Player.State.Idle
{
    public class PlayerIdleState : AbstractPlayerState
    {
        private readonly static ISprite[] Sprites = { 
            new PlayerIdleUpSprite(), new PlayerIdleDownSprite(), new PlayerIdleLeftSprite(), new PlayerIdleRightSprite() 
        };

        // This is the state that new players start off in
        public PlayerIdleState(Player player, bool setUpSettings = false) : base(player, setUpSettings)
        {
            Player.IsStationary = true;
            Sprite = Sprites[(int)Player.FacingDirection];
        }

        public override void DoPrimaryAttack()
        {
            Player.State = new PlayerSwordState(Player);
        }

        public override void DoSecondaryAttack()
        {
            Player.State = new PlayerUseItemState(Player);
        }

        public override void Move(Types.Direction direction)
        {
            Player.FacingDirection = direction;
            Player.State = new PlayerMovingState(Player);
        }

        public override void HoldItem(IItem item)
        {
            Player.State = new PlayerHoldItemState(Player, item);
        }

        public override void StopAction()
        {
            // Nothing new happens
        }    
    }
}
