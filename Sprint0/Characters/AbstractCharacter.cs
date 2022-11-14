using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Levels;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites;
using System;

namespace Sprint0.Characters
{
    public abstract class AbstractCharacter : ICharacter
    {
        // State
        public ICharacterState State { get; set; }
        public Vector2 Position { get; set; }
        public int Damage { get; protected set; }

        // Combat related fields.
        protected int Health;
        private Types.Direction KnockbackDirection;
        private Vector2 Knockback = new(16 * Sprint0.Utils.GameScale, 16 * Sprint0.Utils.GameScale);
        private static readonly int InvincibilityFrames = 40;
        private static readonly int KnockBackFrames = InvincibilityFrames / 5;

        // Condition monitoring variables
        private bool IsTakingDamage;
        private int DamageFramesPassed;
        private bool JustSpawned;

        // We'll let the state classes reference this sprite so there isn't choppy animation when switching states
        public ISprite Sprite { get; set; }

        protected AbstractCharacter()
        {
            IsTakingDamage = false;
            DamageFramesPassed = 0;
            JustSpawned = true;
        }

        protected void DeathAction(Room room)
        {
            // Spawn a "death particle" upon death
            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.DEATH_PARTICLE, this, Types.Direction.NO_DIRECTION);
            AudioManager.GetInstance().PlayOnce(Resources.EnemyDeath);

            // Custom drop rates because the game's actual drop rates are too uncommon for just playing in the first dungeon
            int Drop = new Random().Next(100);
            if (Drop >= 25 && Drop < 50) room.AddItemToRoom(Types.Item.RUPEE, Position);
            else if (Drop >= 50 && Drop < 60) room.AddItemToRoom(Types.Item.VALUABLE_RUPEE, Position);
            else if (Drop >= 60 && Drop < 75) room.AddItemToRoom(Types.Item.HEART, Position);
            else if (Drop >= 75 && Drop < 85) room.AddItemToRoom(Types.Item.CLOCK, Position);
            else if (Drop >= 85 && Drop < 95) room.AddItemToRoom(Types.Item.BOMB, Position);
            else if (Drop >= 95 && Drop < 100) room.AddItemToRoom(Types.Item.FAIRY, Position);
        }

        public virtual void Draw(SpriteBatch sb)
        {
            Color CharacterColor = (IsTakingDamage) ? Color.Red : Color.White;
            if (State != null && !JustSpawned) State.Draw(sb, Position, CharacterColor);
        }

        public virtual void Freeze(bool frozenForever)
        {
            if (State != null) State.Freeze(frozenForever);
        }

        public virtual Rectangle GetHitbox()
        {
            return State.GetHitbox(Position);
        }

        public virtual void TakeDamage(Types.Direction damageSide, int damage, Room room)
        {
            if (!IsTakingDamage)
            {
                IsTakingDamage = true;
                Health -= damage;
                AudioManager.GetInstance().PlayOnce(Resources.EnemyTakeDamage);
                if (Health <= 0)
                {
                    DeathAction(room);
                    room.RemoveCharacterFromRoom(this);
                }
                else
                {
                    KnockbackDirection = Sprint0.Utils.GetOppositeDirection(damageSide);
                }
            }
        }

        public virtual void Unfreeze()
        {
            if (State != null) State.Unfreeze();
        }

        public virtual void Update(GameTime gameTime)
        {
            // Spawn a cloud particle upon character spawning in
            if (JustSpawned)
            {
                JustSpawned = false;
                ProjectileManager.GetInstance().AddProjectile(Types.Projectile.SPAWN_PARTICLE, this, Types.Direction.NO_DIRECTION);
            }

            if (IsTakingDamage)
            {
                // Take knockback
                if (DamageFramesPassed < KnockBackFrames)
                {
                    Position += Sprint0.Utils.DirectionToVector(KnockbackDirection) * Knockback / (KnockBackFrames);
                }

                // Check to see if the character should no longer be damaged
                DamageFramesPassed = (DamageFramesPassed + 1) % InvincibilityFrames;
                if (DamageFramesPassed == 0)
                {
                    IsTakingDamage = false;
                }
            }

            if (State != null) State.Update(gameTime);
        }
    }
}
