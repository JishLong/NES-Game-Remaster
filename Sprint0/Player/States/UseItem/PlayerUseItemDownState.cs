using Sprint0.Player.State.Idle;
using Sprint0.Player.State;
using Sprint0.Sprites.Player.Attack.UseItem;
using Microsoft.Xna.Framework;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Player.States.BlueArrow
{
    public class PlayerUseItemDownState : AbstractPlayerState
    {
        public PlayerUseItemDownState(Player player) : base(player)
        {
            Sprite = new PlayerUseItemDownSprite();
            SpawnProjectile();
        }

        public PlayerUseItemDownState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerUseItemDownSprite();
            SpawnProjectile();
        }

        private void SpawnProjectile()
        {
            ProjectileManager.GetInstance().AddProjectile(Player.SecondaryWeapon, Player, Types.Direction.DOWN);
        }

        public override void Update()
        {
            base.Update();

            if (FramesPassed % UseFrames == 0)
            {
                Player.State = new PlayerFacingDownState(this);
            }
        }
    }
}
