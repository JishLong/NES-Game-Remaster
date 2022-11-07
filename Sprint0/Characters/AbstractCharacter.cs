using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Commands.Blocks;
using Sprint0.Levels;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites;
using System;

namespace Sprint0.Characters;
public abstract class AbstractCharacter : ICharacter
{
    // State
    public ICharacterState State { get; set; }

    // Combat related fields.
    protected int Health;
    public int Damage { get; protected set; }
    private Types.Direction KnockbackDirection;

    // Damage cosmetics
    protected Color Color = Color.White;
    protected int DamageFrameCounter = 0;
    protected bool JustSpawned = true;

    // Movement related fields.
    public Vector2 Position { get; set; }
    protected Vector2 Knockback = new(16 * Sprint0.Utils.GameScale, 16 * Sprint0.Utils.GameScale);  

    // Sprite related fields.
    protected ISprite Sprite;

    protected void DeathAction(Room room)
    {
        // Spawn a "death particle" upon death
        ProjectileManager.GetInstance().AddProjectile(Types.Projectile.DEATH_PARTICLE, this, Types.Direction.NO_DIRECTION);
        AudioManager.GetInstance().PlayOnce(Resources.EnemyDeath);

        // Custom drop rates because the game's actual drop rates are too uncommon for just playing in the first dungeon
        int Drop = new Random().Next(100);
        if (Drop >= 25 && Drop < 50) room.AddItemToRoom(Types.Item.RUPEE, Position);
        else if (Drop >= 50 && Drop < 75) room.AddItemToRoom(Types.Item.HEART, Position);
        else if (Drop >= 70 && Drop < 80) room.AddItemToRoom(Types.Item.CLOCK, Position);
        else if (Drop >= 80 && Drop < 90) room.AddItemToRoom(Types.Item.FAIRY, Position);
        else if (Drop >= 90 && Drop < 100) room.AddItemToRoom(Types.Item.BOMB, Position);
    }

    public virtual void Draw(SpriteBatch sb)
    {
        if (!JustSpawned) State.Draw(sb, Position, Color);
    }

    public void Freeze() 
    {
        State.Freeze();
    }

    public virtual Rectangle GetHitbox()
    {
        return State.GetHitbox(Position);
    }

    public virtual void TakeDamage(Types.Direction damageSide, int damage, Room room)
    {
        if (Color != Color.Red)
        {
            Health -= damage;
            AudioManager.GetInstance().PlayOnce(Resources.EnemyTakeDamage);
            if (Health <= 0)
            {
                DeathAction(room);
                room.RemoveCharacterFromRoom(this);
            }
            else
            {
                Color = Color.Red;
                KnockbackDirection = Sprint0.Utils.GetOppositeDirection(damageSide);
            }
        }
    }

    public virtual void Update(GameTime gameTime)
    {
        if (JustSpawned) 
        {
            JustSpawned = false;
            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.SPAWN_PARTICLE, this, Types.Direction.NO_DIRECTION);
        }
        if (Color.Equals(Color.Red)) 
        {
            DamageFrameCounter++;
            if (DamageFrameCounter < 40 / 5)
            {
                Position += Sprint0.Utils.DirectionToVector(KnockbackDirection) * Knockback / (40 / 5);
            }
            if (DamageFrameCounter >= 40) 
            {
                Color = Color.White;
                DamageFrameCounter = 0;
            } 
        }

        State.Update(gameTime);
    } 
}
