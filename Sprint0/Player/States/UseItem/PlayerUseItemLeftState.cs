using Sprint0.Player.State.Idle;
using Sprint0.Player.State;
using Sprint0.Sprites.Player.Attack.UseItem;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Player.States.BlueArrow
{
    public class PlayerUseItemLeftState : AbstractPlayerState
    {
        public PlayerUseItemLeftState(Player player) : base(player)
        {
            Sprite = new PlayerUseItemLeftSprite();
            SpawnProjectile();
        }

        public PlayerUseItemLeftState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerUseItemLeftSprite();
            SpawnProjectile();
        }

        private void SpawnProjectile()
        {
            ProjectileManager.GetInstance().AddProjectile(Player.SecondaryWeapon, Player, Types.Direction.LEFT);
        }

        public override void Update()
        {
            base.Update();

            if (FramesPassed % UseFrames == 0)
            {
                Player.State = new PlayerFacingLeftState(this);
            }
        }
    }
}
