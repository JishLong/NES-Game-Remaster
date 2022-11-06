using Sprint0.Player.State.Idle;
using Sprint0.Player.State;
using Sprint0.Sprites.Player.Attack.UseItem;
using Microsoft.Xna.Framework;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Player.States.BlueArrow
{
    public class PlayerUseItemUpState : AbstractPlayerState
    {
        public PlayerUseItemUpState(Player player) : base(player)
        {
            Sprite = new PlayerUseItemUpSprite();
            SpawnProjectile();
        }

        public PlayerUseItemUpState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerUseItemUpSprite();
            SpawnProjectile();
        }

        private void SpawnProjectile()
        {
            ProjectileManager.GetInstance().AddProjectile(Player.SecondaryWeapon, Player, Types.Direction.UP);
        }

        public override void Update()
        {
            base.Update();

            if (FramesPassed % UseFrames == 0)
            {
                Player.State = new PlayerFacingUpState(this);
            }
        }
    }
}
