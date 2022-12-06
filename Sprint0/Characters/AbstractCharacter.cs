using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.Entities;
using Sprint0.GameModes;
using Sprint0.Levels;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites;
using System;

namespace Sprint0.Characters
{
    public abstract class AbstractCharacter : ICharacter
    {
        // State
        public ICharacterState CurrentState { get; set; }
        public ICharacterState MovingState { get; set; }
        public ICharacterState FrozenTemporarilyState { get; set; }
        public ICharacterState FrozenForeverState { get; set; }
        public ICharacterState AttackState { get; set; }
        public Vector2 Position { get; set; }

        private readonly Types.Character CharacterType;

        public int Damage { get; protected set; }
        public Vector2 MovementSpeed { get; protected set; }

        // Combat related fields.
        protected int Health;
        private Types.Direction KnockbackDirection;
        private Vector2 Knockback = new(16 * GameWindow.ResolutionScale, 16 * GameWindow.ResolutionScale);
        private static readonly int InvincibilityFrames = 40;
        private static readonly int KnockBackFrames = InvincibilityFrames / 5;

        // Condition monitoring variables
        protected bool IsTakingDamage;
        private int DamageFramesPassed;
        protected bool JustSpawned;

        // We'll let the state classes reference this sprite so there isn't choppy animation when switching states
        public ISprite Sprite { get; set; }

        // For the entity system
        public IEntity Parent { get; set; }
        public string Name { get; set; }
        protected AbstractCharacter(Types.Character characterType)
        {
            CharacterType = characterType;
            IsTakingDamage = false;
            DamageFramesPassed = 0;
            JustSpawned = true;

            Name = "unnamed";
        }

        protected void DeathAction(Room room)
        {
            // Spawn a "death particle" upon death
            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.DEATH_PARTICLE, this, Types.Direction.NO_DIRECTION);
            AudioManager.GetInstance().PlayOnce(AudioMappings.GetInstance().EnemyDeath);

            // Custom drop rates because the game's actual drop rates are too uncommon for just playing in the first dungeon
            int Drop = new Random().Next(100);
            if (Drop >= 25 && Drop < 50) room.AddItemToRoom(Types.Item.RUPEE, Position);
            else if (Drop >= 50 && Drop < 60) room.AddItemToRoom(Types.Item.VALUABLERUPEE, Position);
            else if (Drop >= 60 && Drop < 75) room.AddItemToRoom(Types.Item.HEART, Position);
            else if (Drop >= 75 && Drop < 85) room.AddItemToRoom(Types.Item.CLOCK, Position);
            else if (Drop >= 85 && Drop < 95) room.AddItemToRoom(Types.Item.BOMB, Position);
            else if (Drop >= 95 && Drop < 100) room.AddItemToRoom(Types.Item.FAIRY, Position);
        }

        public virtual void Draw(SpriteBatch sb)
        {
            Color CharacterColor = (IsTakingDamage) ? Color.Red : Color.White;
            if (CurrentState != null && !JustSpawned) CurrentState.Draw(sb, Sprint0.Utils.LinkToCamera(Position), CharacterColor);
        }

        public virtual void Freeze(bool frozenForever)
        {
            if (CurrentState != null) CurrentState.Freeze(frozenForever);
        }

        public abstract void SetSprite(Types.Direction direction = Types.Direction.NO_DIRECTION);

        public Types.Character GetCharacterType() => CharacterType;

        public virtual Rectangle GetHitbox()
        {
            return CurrentState.GetHitbox(Position);
        }

        public virtual void TakeDamage(Types.Direction damageSide, int damage, Room room)
        {
            if (!IsTakingDamage)
            {
                IsTakingDamage = true;
                Health -= damage;
                AudioManager.GetInstance().PlayOnce(AudioMappings.GetInstance().EnemyHurt);
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
            if (CurrentState != null) CurrentState.Unfreeze();
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

            if (CurrentState != null) CurrentState.Update(gameTime);
        }
    }
}
