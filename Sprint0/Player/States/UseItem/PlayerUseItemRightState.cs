using Sprint0.Player.State.Idle;
using Sprint0.Player.State;
using Sprint0.Sprites.Player.Attack.UseItem;
using Microsoft.Xna.Framework;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Player.States.BlueArrow
{
    public class PlayerUseItemRightState : AbstractPlayerState
    {
        public PlayerUseItemRightState(Player player) : base(player)
        {
            Sprite = new PlayerUseItemRightSprite();
            SpawnProjectile();
        }

        public PlayerUseItemRightState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerUseItemRightSprite();
            SpawnProjectile();
        }

        private void SpawnProjectile()
        {
            ProjectileManager.GetInstance().AddProjectile(Player.SecondaryWeapon, Player, Types.Direction.RIGHT);
        }

        public override void Update()
        {
            base.Update();

            if (FramesPassed % UseFrames == 0)
            {
                Player.State = new PlayerFacingRightState(this);
            }
        }
    }
}
