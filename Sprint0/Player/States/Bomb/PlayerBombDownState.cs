using Sprint0.Player.State.Idle;
using Sprint0.Sprites.Player.Attack.UseItem;
using Sprint0.Projectiles.Player_Projectiles;
using Microsoft.Xna.Framework;
using Sprint0.Items;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Player.State.Arrow
{
    public class PlayerBombDownState : AbstractPlayerState
    {
        public PlayerBombDownState(Player player) : base(player)
        {
            Sprite = new PlayerUseItemDownSprite();

            SpawnBomb();
        }

        public PlayerBombDownState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerUseItemDownSprite();

            SpawnBomb();
        }

        private void SpawnBomb()
        {
            // Magic numbers for position for now
            float BombX = Player.GetHitbox().Center.X - Resources.BombProj.Width * Utils.GameScale / 2;
            float BombY = Player.GetHitbox().Bottom;

            ProjectileManager.GetInstance().AddProjectile(
                Types.Projectile.BOMBPROJ, new Vector2(BombX, BombY), Types.Direction.DOWN, null);
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
                Player.State = new PlayerFacingDownState(this);
            }
        }
    }
}
