using Microsoft.Xna.Framework;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites;
using Sprint0.Sprites.Player.Attack.SwordAttack;

namespace Sprint0.Player.State.Idle
{
    public class PlayerSwordRightState : AbstractPlayerState
    {
        public PlayerSwordRightState(Player player) : base(player)
        {
            Sprite = new PlayerSwordAttackRight();
            SpawnSwordMelee();
        }

        public PlayerSwordRightState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerSwordAttackRight();
            SpawnSwordMelee();
        }

        private void SpawnSwordMelee()
        {
            float SwordX = Player.Position.X + Player.GetHitbox().Width;
            float SwordY = Player.Position.Y;

            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.SWORDMELEE,
                new Vector2(SwordX, SwordY), Types.Direction.LEFT, null);
        }

        public override void Update()
        {
            base.Update();

            /* We don't want the player's sword attack animation to be abruptly cut off, so we switch the state only after a
             * full sword animation has played through
             * 
             * NOTE: potential coupling/abstraction break issue here - we're casting an interface to an extra abstract class,
             * might be something to fix in the future but works okay for now
             */
            if (FramesPassed % ((AbstractAnimatedSprite)Sprite).GetAnimationTime() == 0) 
            {
                Player.State = new PlayerFacingRightState(this);
                if (Player.Health == Player.MaxHealth)
                {
                    float SwordX = Player.Position.X + Player.GetHitbox().Width;
                    float SwordY = Player.Position.Y + Player.GetHitbox().Height / 2 - Resources.SwordProjHorz.Height * Utils.GameScale / 2;
                    ProjectileManager.GetInstance().AddProjectile(Types.Projectile.SWORDPROJ, new Vector2(SwordX, SwordY), Types.Direction.RIGHT, null);
                }
            } 
        }
    }
}
