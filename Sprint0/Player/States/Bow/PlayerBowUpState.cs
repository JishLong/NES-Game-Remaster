using Sprint0.Player.State.Idle;
using Sprint0.Sprites.Player.Attack.UseItem;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Player_Projectiles;
using Microsoft.Xna.Framework;

namespace Sprint0.Player.State.Arrow
{
    public class PlayerBowUpState : AbstractPlayerState
    {
        public PlayerBowUpState(Player player) : base(player)
        {
            Sprite = new PlayerUseItemUpSprite();

            SpawnArrow();
        }

        public PlayerBowUpState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerUseItemUpSprite();

            SpawnArrow();
        }

        private void SpawnArrow()
        {
            float ArrowX = Player.GetHitbox().Center.X;
            float ArrowY = Player.GetHitbox().Top;

            ProjectileManager.GetInstance().AddProjectile(new ArrowProjectile(
            new Vector2(ArrowX, ArrowY), Types.Direction.UP));
        }

        public override void Update()
        {
            base.Update();

            if ((FramesPassed + 1) % 40 == 0)
            {
                Player.State = new PlayerFacingUpState(this);
            }
        }
    }
}
