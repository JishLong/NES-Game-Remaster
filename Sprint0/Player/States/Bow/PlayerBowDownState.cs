using Sprint0.Player.State.Idle;
using Sprint0.Sprites.Player.Attack.UseItem;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Player_Projectiles;
using Microsoft.Xna.Framework;

namespace Sprint0.Player.State.Arrow
{
    public class PlayerBowDownState : AbstractPlayerState
    {
        public PlayerBowDownState(Player player) : base(player)
        {
            Sprite = new PlayerUseItemDownSprite();

            SpawnArrow();
        }

        public PlayerBowDownState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerUseItemDownSprite();

            SpawnArrow();
        }

        private void SpawnArrow()
        {
            float ArrowX = Player.GetHitbox().Center.X;
            float ArrowY = Player.GetHitbox().Bottom;

            ProjectileManager.GetInstance().AddProjectile(new ArrowProjectile(
            new Vector2(ArrowX, ArrowY), Types.Direction.DOWN));
        }

        public override void Update()
        {
            base.Update();

            if ((FramesPassed + 1) % 40 == 0)
            {
                Player.State = new PlayerFacingDownState(this);
            }
        }
    }
}
