using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Commands.Blocks;
using Sprint0.Levels;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites;

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

    protected void DeathAction()
    {
        // Spawn a "death particle" upon death
        ProjectileManager.GetInstance().AddProjectile(Types.Projectile.DEATH_PARTICLE, this, Types.Direction.NO_DIRECTION);
        AudioManager.GetInstance().PlayOnce(Resources.EnemyDeath);
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
                DeathAction();
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
