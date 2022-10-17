using Sprint0.Player.State.Idle;
using Sprint0.Player.State;
using Sprint0.Projectiles.Player_Projectiles;
using Sprint0.Projectiles;
using Sprint0.Sprites.Player.Attack.UseItem;
using Microsoft.Xna.Framework;

namespace Sprint0.Player.States.Flame
{
    public class PlayerFlameLeftState : AbstractPlayerState
    {
        public PlayerFlameLeftState(Player player) : base(player)
        {
            Sprite = new PlayerUseItemLeftSprite();

            SpawnFlame();
        }

        public PlayerFlameLeftState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerUseItemLeftSprite();

            SpawnFlame();
        }

        private void SpawnFlame()
        {
            // Magic numbers for position for now
            float FlameX = Player.GetHitbox().Left - Resources.FlameProj.Width * 3;
            float FlameY = Player.GetHitbox().Center.Y - Resources.FlameProj.Height * 3 / 2;

            ProjectileManager.GetInstance().AddProjectile(new FlameProjectile(
            new Vector2(FlameX, FlameY), Types.Direction.LEFT));
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
