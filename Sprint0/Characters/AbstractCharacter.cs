using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Enemies.States;
using Sprint0.Levels;
using Sprint0.Player;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites;

namespace Sprint0.Characters;
public abstract class AbstractCharacter : ICharacter
{
    // State
    public ICharacterState State { get; set; }

    // Combat related fields.
    protected int Health;
    protected int Damage;

    // Damage cosmetics
    protected Color Color = Color.White;
    protected int DamageFrameCounter = 0;

    // Movement related fields.
    public Vector2 Position { get; set; }
    protected Vector2 Knockback = new(-16, 16);

    // Sprite related fields.
    protected ISprite Sprite;

    public virtual void TakeDamage(Types.Direction damageSide, int damage, Room room)
    {
        if (Color != Color.Red)
        {
            Health -= damage;
            if (Health <= 0)
            {
                DeathAction();
                room.RemoveCharacterFromRoom(this);
            }
            else 
            {
                Color = Color.Red;
                Position += Utils.DirectionToVector(damageSide) * Knockback;
            }    
        }        
    }

    private void DeathAction()
    {
        Rectangle r = Resources.CharacterDeathParticle;
        Rectangle ParticleHitbox = new Rectangle(r.X, r.Y, (int)(r.Width * Utils.GameScale), (int)(r.Height * Utils.GameScale));

        ProjectileManager.GetInstance().AddProjectile(
            Types.Projectile.DEATHPARTICLE, 
            Utils.CenterRectangles(GetHitbox(), ParticleHitbox), 
            Types.Direction.UP);
    }

    public virtual void Update(GameTime gameTime)
    {
        if (Color.Equals(Color.Red)) 
        {
            DamageFrameCounter++;
            if (DamageFrameCounter == 40) 
            {
                Color = Color.White;
                DamageFrameCounter = 0;
            } 
        }

        State.Update(gameTime);
    }

    public virtual void Draw(SpriteBatch sb)
    {
        State.Draw(sb, Position, Color);
    }

    public virtual Rectangle GetHitbox()
    {
        return State.GetHitbox(Position);
    }
}
