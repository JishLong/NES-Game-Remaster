using Sprint0.Player.State.Idle;
using Sprint0.Sprites.Player.Attack.UseItem;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Player_Projectiles;
using Microsoft.Xna.Framework;

namespace Sprint0.Player.State.Arrow
{
    public class PlayerBowRightState : AbstractPlayerState
    {
        public PlayerBowRightState(Player player) : base(player)
        {
            Sprite = new PlayerUseItemRightSprite();

            SpawnArrow();
        }

        public PlayerBowRightState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerUseItemRightSprite();

            SpawnArrow();
        }

        private void SpawnArrow() 
        {
            float ArrowX = Player.GetHitbox().Right;
            float ArrowY = Player.GetHitbox().Center.Y;

            ProjectileManager.GetInstance().AddProjectile(new ArrowProjectile(
            new Vector2(ArrowX, ArrowY), Types.Direction.RIGHT));
        }

        public override void Update()
        {
            base.Update();

            if ((FramesPassed + 1) % 40 == 0)
            {
                Player.State = new PlayerFacingRightState(this);
            }
        }
    }
}
