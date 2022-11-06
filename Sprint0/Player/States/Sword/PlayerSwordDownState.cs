using Microsoft.Xna.Framework;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites;
using Sprint0.Sprites.Player.Attack.SwordAttack;

namespace Sprint0.Player.State.Idle
{
    public class PlayerSwordDownState : AbstractPlayerState
    {
        public PlayerSwordDownState(Player player) : base(player)
        {
            Sprite = new PlayerSwordAttackDown();
            SpawnSwordMelee();
        }

        public PlayerSwordDownState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerSwordAttackDown();
            SpawnSwordMelee();    
        }

        private void SpawnSwordMelee() 
        {
            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.SWORD_MELEE, Player, Types.Direction.DOWN);
            AudioManager.GetInstance().PlayOnce(Resources.Sword);
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
            if (FramesPassed % Sprite.GetAnimationTime() == 0) 
            {
                Player.State = new PlayerFacingDownState(this);               
            }
            else if (FramesPassed % Sprite.GetAnimationTime() == Sprite.GetAnimationTime() / 2
                && Player.Health == Player.MaxHealth)
            {             
                ProjectileManager.GetInstance().AddProjectile(Types.Projectile.SWORD_PROJ, Player, Types.Direction.DOWN);
                AudioManager.GetInstance().PlayOnce(Resources.SwordProj);
            }
        }
    }
}
