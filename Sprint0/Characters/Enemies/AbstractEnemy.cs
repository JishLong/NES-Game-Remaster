using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Enemies.Interfaces;
using Sprint0.Characters.Enemies.States;
using Sprint0.Characters.Enemies.Utils;
using Sprint0.Enemies.Interfaces;
using Sprint0.Sprites;

namespace Sprint0.Characters.Enemies;
public abstract class AbstractEnemy : IEnemy
{
    // State
    public IEnemyState State { get; set; }

    // Combat related fields.
    protected int Health;  

    // Movement related fields.
    public Vector2 Position { get; set;}
    protected EnemyUtils.Direction Direction;
    protected int MovementSpeed;
    protected bool IsFrozen = false;

    // Sprite related fields.
    protected ISprite Sprite;

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
    public abstract void Update(GameTime gameTime);

    public abstract void Draw(SpriteBatch sb);
}
