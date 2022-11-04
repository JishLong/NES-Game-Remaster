using Microsoft.Xna.Framework;
using Sprint0.Characters.Bosses.States.AquamentusStates;
using Sprint0.Characters.Enemies;
using Sprint0.Characters.Utils;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Characters.Enemies;
using System;

namespace Sprint0.Characters.Bosses.AquamentusStates
{
    // [NOTE]: Aquamentus only has a left facing sprite for movement.
    public class AquamentusMovingLeftState : AbstractCharacterState
    {
        private readonly Aquamentus Aquamentus;
        private Vector2 DirectionVector = Sprint0.Utils.DirectionToVector(Types.Direction.LEFT);
        private readonly float MovementSpeed = 1f;

        private readonly Random RNG;
        public AquamentusMovingLeftState(Aquamentus aquamentus)
        {
            Aquamentus = aquamentus;
            Sprite = new AquamentusSprite();

            RNG = new Random();
        }
        public override void Attack()
        {
            Aquamentus.State = new AquamentusMovingLeftState(Aquamentus);
        }
        public override void Move()
        {
            Aquamentus.Position += DirectionVector * MovementSpeed;
        }
        public override void Freeze()
        {
            Aquamentus.State = new AquamentusFrozenState(Aquamentus);
        }
        public override void ChangeDirection()
        {
            // UpLeft for logic purposes.
            Types.Direction direction = CharacterUtils.RandOrthogDirection(Types.Direction.LEFT);
            switch (direction)
            {
                case Types.Direction.RIGHT:
                    Aquamentus.State = new AquamentusMovingRightState(Aquamentus);
                    break;
                case Types.Direction.UP:
                    Aquamentus.State = new AquamentusMovingUpState(Aquamentus);
                    break;
                case Types.Direction.DOWN:
                    Aquamentus.State = new AquamentusMovingDownState(Aquamentus);
                    break;
            }
        }
        public override void Update(GameTime gameTime)
        {
            Move();
            Sprite.Update();

            if (RNG.Next(0, 120) == 0)
            {
                ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOSS_PROJ, Aquamentus, Types.Direction.LEFT);
                ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOSS_PROJ, Aquamentus, Types.Direction.DOWNLEFT);
                ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOSS_PROJ, Aquamentus, Types.Direction.UPLEFT);
            }
        }
    }
}
