using Microsoft.Xna.Framework;
using Sprint0.Assets;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Characters.Enemies.States
{
    public class AquamentusAttackState : AbstractCharacterState
    {
        private Types.Direction ResumeMovementDirection;

        private double AttackTimer;
        private readonly double AttackDelay = 500;  // Attack for this many milliseconds.

        public AquamentusAttackState(AbstractCharacter character) : base(character) { }

        public override void Attack()
        {
            // Already attacking
        }

        public override void ChangeDirection()
        {
            // Can't change direction while attacking
        }

        public override void Freeze(bool frozenForever)
        {
            if (frozenForever && Character.FrozenForeverState != null)
            {
                Character.FrozenForeverState.SetUp(ResumeMovementDirection);
                Character.CurrentState = Character.FrozenForeverState;
            }
            else if (!frozenForever && Character.FrozenTemporarilyState != null)
            {
                Character.FrozenTemporarilyState.SetUp(ResumeMovementDirection);
                Character.CurrentState = Character.FrozenTemporarilyState;
            }
        }

        public override void SetUp(Types.Direction direction)
        {
            Character.SetSprite(direction);
            ResumeMovementDirection = direction;
            AttackTimer = 0;

            ProjectileManager PM = ProjectileManager.GetInstance();
            PM.AddProjectile(Types.Projectile.BOSS_PROJ, Character, Types.Direction.LEFT);
            PM.AddProjectile(Types.Projectile.BOSS_PROJ, Character, Types.Direction.DOWNLEFT);
            PM.AddProjectile(Types.Projectile.BOSS_PROJ, Character, Types.Direction.UPLEFT);

            AudioManager.GetInstance().PlayOnce(AudioMappings.GetInstance().BossRoar);
        }

        public override void Unfreeze()
        {
            // Already unfrozen!
        }

        public override void Update(GameTime gameTime)
        {
            AttackTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if ((AttackTimer - AttackDelay) > 0 && Character.MovingState != null) 
            {
                Character.MovingState.SetUp(ResumeMovementDirection);
                Character.CurrentState = Character.MovingState;
            }
                
            Character.Sprite.Update();
        }
    }
}
