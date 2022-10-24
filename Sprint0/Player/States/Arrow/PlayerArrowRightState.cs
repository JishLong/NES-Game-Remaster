using Sprint0.Player.State.Idle;
using Sprint0.Sprites.Player.Attack.UseItem;
using Sprint0.Projectiles.Player_Projectiles;
using Microsoft.Xna.Framework;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Player.State.Arrow
{
    public class PlayerArrowRightState : AbstractPlayerState
    {
        public PlayerArrowRightState(Player player) : base(player)
        {
            Sprite = new PlayerUseItemRightSprite();

            SpawnArrow();
        }

        public PlayerArrowRightState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerUseItemRightSprite();

            SpawnArrow();
        }

        private void SpawnArrow() 
        {
            float ArrowX = Player.GetHitbox().Right;
            float ArrowY = Player.GetHitbox().Center.Y - Resources.ArrowProjVert.Height / 2;

            ProjectileManager.GetInstance().AddProjectile(
                Types.Projectile.ARROWPROJ, new Vector2(ArrowX, ArrowY), Types.Direction.RIGHT);
        }

        public override void Update()
        {
            base.Update();

            /* This "40" is a magic number and is just an arbitrary value I picked for how long link is in his mf stanced up
             * pose for;
             * 
             * Should we make a variable for this so it's not a magic number? Also, is there an actual value for this number that
             * is accurate to the game? 40 seemed to work somewhat well but like I said it's just arbitrary
             */
            if ((FramesPassed + 1) % 40 == 0)
            {
                Player.State = new PlayerFacingRightState(this);
            }
        }
    }
}
