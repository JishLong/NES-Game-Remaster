using Microsoft.Xna.Framework;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Characters.Enemies.AquamentusStates
{
    public class AquamentusAttackingState : AbstractCharacterState
    {
        private readonly Types.Direction ResumeMovementDirection;

        private double AttackTimer;
        private readonly double AttackDelay = 500;  // Attack for this many milliseconds.

        public AquamentusAttackingState(AbstractCharacter character, Types.Direction direction) : base(character)
        {
            ResumeMovementDirection = direction;

            ProjectileManager PM = ProjectileManager.GetInstance();
            PM.AddProjectile(Types.Projectile.BOSS_PROJ, Character, Types.Direction.LEFT);
            PM.AddProjectile(Types.Projectile.BOSS_PROJ, Character, Types.Direction.DOWNLEFT);
            PM.AddProjectile(Types.Projectile.BOSS_PROJ, Character, Types.Direction.UPLEFT);

            AudioManager.GetInstance().PlayOnce(Resources.BossNoise);
        }

        public override void Attack()
        {
            // Already attacking.
        }

        public override void Freeze(bool frozenForever)
        {
            Character.State = new AquamentusFrozenState(Character, ResumeMovementDirection, frozenForever);
        }

        public override void ChangeDirection()
        {
            // Do nothing, cant change direction while attacking.
        }

        public override void Unfreeze()
        {
            // Already unfrozen!
        }

        public override void Update(GameTime gameTime)
        {
            AttackTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if ((AttackTimer - AttackDelay) > 0) Character.State = new AquamentusMovingState(Character, ResumeMovementDirection);

            Character.Sprite.Update();
        }
    }
}
