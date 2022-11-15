using Sprint0.Player.State.Idle;
using Sprint0.Player.State;
using Sprint0.Sprites.Player.Attack.UseItem;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites;
using Sprint0.Items;

namespace Sprint0.Player.States
{
    public class PlayerUseItemState : AbstractPlayerState
    {
        private readonly static ISprite[] Sprites = {
            new PlayerUseItemUpSprite(), new PlayerUseItemDownSprite(), new PlayerUseItemLeftSprite(), new PlayerUseItemRightSprite()
        };

        private int FramesPassed;
        private static readonly int UseFrames = 20;

        public PlayerUseItemState(Player player) : base(player)
        {
            Player.IsStationary = false;
            Sprite = Sprites[(int)Player.FacingDirection];
            FramesPassed = 0;
            ProjectileManager.GetInstance().AddProjectile(Player.SecondaryWeapon, Player, Player.FacingDirection);
            if (Player.SecondaryWeapon == Types.Projectile.BOMB_PROJ) Player.Inventory.DecrementItem(Types.Item.BOMB);
            else if (Player.SecondaryWeapon == Types.Projectile.ARROW_PROJ) Player.Inventory.DecrementItem(Types.Item.RUPEE);
        }

        public override void DoPrimaryAttack()
        {
            // Nothing happens; attack must complete itself
        }

        public override void DoSecondaryAttack()
        {
            // Nothing happens
        }

        public override void Move(Types.Direction direction)
        {
            // Nothing happens; attack must complete itself
        }

        public override void HoldItem(IItem item)
        {
            // Nothing happens; attack must complete itself
        }

        public override void StopAction()
        {
            // Nothing happens; attack must complete itself
        }

        public override void Update()
        {
            base.Update();

            FramesPassed++;
            if (FramesPassed % UseFrames == 0)
            {
                Player.State = new PlayerIdleState(Player);
            }
        }    
    }
}
