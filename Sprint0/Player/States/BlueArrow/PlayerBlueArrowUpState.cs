using Sprint0.Player.State.Idle;
using Sprint0.Sprites.Player.Attack.UseItem;
using Microsoft.Xna.Framework;
using Sprint0.Player.State;
using Sprint0.Projectiles.Player;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Player.States.BlueArrow
{
    internal class PlayerBlueArrowUpState : AbstractPlayerState
    {
        public PlayerBlueArrowUpState(Player player) : base(player)
        {
            Sprite = new PlayerUseItemUpSprite();

            SpawnArrow();
        }

        public PlayerBlueArrowUpState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerUseItemUpSprite();

            SpawnArrow();
        }

        private void SpawnArrow()
        {
            // Magic numbers for position for now
            float ArrowX = Player.GetHitbox().Center.X - Resources.BlueArrowProjVert.Width * Utils.GameScale / 2;
            float ArrowY = Player.GetHitbox().Top - Resources.BlueArrowProjVert.Height * Utils.GameScale;

            ProjectileManager.GetInstance().AddProjectile(
                Types.Projectile.BLUEARROWPROJ, new Vector2(ArrowX, ArrowY), Types.Direction.UP);
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
                Player.State = new PlayerFacingUpState(this);
            }
        }
    }
}
