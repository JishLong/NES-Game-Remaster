using Sprint0.Player.State.Idle;
using Sprint0.Player.State;
using Sprint0.Sprites.Player.Attack.UseItem;
using Microsoft.Xna.Framework;
using Sprint0.Projectiles.Player;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Player.States.Boomerang
{
    public class PlayerBoomerangLeftState : AbstractPlayerState
    {
        public PlayerBoomerangLeftState(Player player) : base(player)
        {
            Sprite = new PlayerUseItemLeftSprite();

            SpawnBoomerang();
        }

        public PlayerBoomerangLeftState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerUseItemLeftSprite();

            SpawnBoomerang();
        }

        private void SpawnBoomerang()
        {
            // Magic numbers for position for now
            float BoomerangX = Player.GetHitbox().Left - Resources.BoomerangProj.Width * Utils.GameScale;
            float BoomerangY = Player.GetHitbox().Center.Y - Resources.BoomerangProj.Height * Utils.GameScale / 2;

            ProjectileManager.GetInstance().AddProjectile(
                Types.Projectile.PLAYERBOOMERANGPROJ, new Vector2(BoomerangX, BoomerangY), Types.Direction.LEFT);
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
            if (FramesPassed % 40 == 0)
            {
                Player.State = new PlayerFacingLeftState(this);
            }
        }
    }
}
