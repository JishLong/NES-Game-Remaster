using Sprint0.Player.State.Idle;
using Sprint0.Player.State;
using Sprint0.Sprites.Player.Attack.UseItem;
using Sprint0.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Items.Items;

namespace Sprint0.Player.States.BlueArrow
{
    public class PlayerHoldItemState : AbstractPlayerState
    {
        private int FramesPassed;
        private readonly IItem Item;
        protected static readonly int HoldItemFrames = 40;

        public PlayerHoldItemState(Player player, IItem item) : base(player)
        {
            Sprite = new PlayerPickUpItemSprite();
            FramesPassed = 0;
            Item = item;
        }

        public override void Draw(SpriteBatch sb, Vector2 position) 
        {
            base.Draw(sb, position);

            Item.Position = Utils.LineUpEdges(GetHitbox(), Item.GetHitbox().Width, Item.GetHitbox().Height, Types.Direction.UP);
            Item.Draw(sb);
        }

        public override void Update()
        {
            base.Update();       
            
            Item.Update();

            FramesPassed++;
            if (FramesPassed == 2 && Item is Bow) AudioManager.GetInstance().PlaySelfishSound(Resources.NewItem);

            if (FramesPassed % HoldItemFrames == 0)
            {
                Player.State = new PlayerIdleState(Player);
            }
        }

        public override void Move(Types.Direction direction)
        {
            // Nothing happens; pickup effect must complete itself
        }

        public override void StopAction()
        {
            // Nothing happens; pickup effect must complete itself
        }

        public override void DoPrimaryAttack()
        {
            // Nothing happens; pickup effect must complete itself
        }

        public override void DoSecondaryAttack()
        {
            // Nothing happens; pickup effect must complete itself
        }

        public override void HoldItem(IItem item)
        {
            // Nothing happens
        }
    }
}
