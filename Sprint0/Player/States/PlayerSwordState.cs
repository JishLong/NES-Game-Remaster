using Sprint0.Items;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites;
using Sprint0.Sprites.Player.Attack.SwordAttack;

namespace Sprint0.Player.State.Idle
{
    public class PlayerSwordState : AbstractPlayerState
    {
        private readonly static ISprite[] Sprites = {
            new PlayerSwordAttackUp(), new PlayerSwordAttackDown(), new PlayerSwordAttackLeft(), new PlayerSwordAttackRight()
        };

        private int FramesPassed;

        public PlayerSwordState(Player player) : base(player)
        {
            Player.IsStationary = false;
            Sprite = Sprites[(int)Player.FacingDirection];
            FramesPassed = 0;
            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.SWORD_MELEE, Player, Player.FacingDirection);
            AudioManager.GetInstance().PlayOnce(Resources.Sword);
        }

        public override void DoPrimaryAttack()
        {
            // Nothing happens
        }

        public override void DoSecondaryAttack()
        {
            // Nothing happens; sword attack must complete itself
        }

        public override void Move(Types.Direction direction)
        {
            // Nothing happens; sword attack must complete itself
        }

        public override void HoldItem(IItem item)
        {
            // Nothing happens; sword attack must complete itself
        }

        public override void StopAction()
        {
            // Nothing happens; sword attack must complete itself
        }

        public override void Update()
        {
            base.Update();

            FramesPassed++;
            if (FramesPassed % Sprite.GetAnimationTime() == 0)
            {
                Player.State = new PlayerIdleState(Player);
            }

            // If the player is at max health, shoot a sword projectile halfway into the attack
            else if (FramesPassed % Sprite.GetAnimationTime() == Sprite.GetAnimationTime() / 2
                && Player.Health == Player.MaxHealth)
            {
                ProjectileManager.GetInstance().AddProjectile(Types.Projectile.SWORD_PROJ, Player, Player.FacingDirection);
                AudioManager.GetInstance().PlayOnce(Resources.SwordProj);
            }
        }
    }
}
