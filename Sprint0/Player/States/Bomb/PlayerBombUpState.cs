using Sprint0.Player.State.Idle;
using Sprint0.Sprites.Player.Attack.UseItem;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Player_Projectiles;
using Microsoft.Xna.Framework;

namespace Sprint0.Player.State.Arrow
{
    public class PlayerBombUpState : AbstractPlayerState
    {
        public PlayerBombUpState(Player player) : base(player)
        {
            Sprite = new PlayerUseItemUpSprite();

            SpawnBomb();
        }

        public PlayerBombUpState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerUseItemUpSprite();

            SpawnBomb();
        }

        private void SpawnBomb()
        {
            // Magic numbers for position for now
            float BombX = Player.GetHitbox().Center.X - Resources.BombProj.Width * 3 / 2;
            float BombY = Player.GetHitbox().Top - Resources.BombProj.Height * 3;

            ProjectileManager.GetInstance().AddProjectile(new BombProjectile(new Vector2(BombX, BombY)));
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
                Player.State = new PlayerFacingUpState(this);
            }
        }
    }
}
