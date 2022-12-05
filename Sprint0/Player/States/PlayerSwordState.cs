using Sprint0.Assets;
using Sprint0.GameModes;
using Sprint0.Items;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites;
using Sprint0.Sprites.Player.Sword;
using System;

namespace Sprint0.Player.States
{
    public class PlayerSwordState : AbstractPlayerState
    {
        private readonly ISprite[] Sprites = { new PlayerSwordUpSprite(), new PlayerSwordDownSprite(), new PlayerSwordLeftSprite(),
            new PlayerSwordRightSprite() };
        private readonly static int GoombaLaserFireRate = 1;

        private int FramesPassed;

        public PlayerSwordState(Player player) : base(player)
        {
            Player.IsStationary = false;
            Sprite = Sprites[(int)Player.FacingDirection];
            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.SWORD_MELEE, Player, Player.FacingDirection);
            AudioManager.GetInstance().PlayOnce(AudioMappings.GetInstance().SwordSwing);
            
            FramesPassed = 0;           
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
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.GOOMBAMODE) Player.State = new PlayerIdleState(Player);
        }

        public override void Update()
        {
            base.Update();

            FramesPassed++;

            if (GameModeManager.GetInstance().GameMode.Type != Types.GameMode.GOOMBAMODE)
            {
                if (FramesPassed % Sprite.GetAnimationTime() == 0)
                {
                    Player.State = new PlayerIdleState(Player);
                }

                // If the player is at max health, shoot a sword projectile halfway into the attack
                else if (FramesPassed % Sprite.GetAnimationTime() == Sprite.GetAnimationTime() / 2
                    && Player.Health == Player.MaxHealth)
                {
                    ProjectileManager.GetInstance().AddProjectile(Types.Projectile.SWORD_PROJ, Player, Player.FacingDirection);
                }
            }
            else if (FramesPassed % GoombaLaserFireRate == 0)
            {
                ProjectileManager.GetInstance().AddProjectile(Types.Projectile.GOOMBA_LASER_PROJ, Player, Player.FacingDirection);
            }
        }
    }
}
