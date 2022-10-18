using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Projectiles;
using Sprint0.Sprites;
using Sprint0.Characters.Bosses;
using Sprint0.Characters.Bosses.States;

namespace Sprint0.Characters.Bosses
{
    public abstract class AbstractBoss : IBoss
	{
		// State fields.
		public IBossState State { get; set; }

		// Combat related fields.
		protected int Health { get; set; }
        protected int Damage { get; set; }

        // Movement related fields.
        public  Vector2 Position;
        //protected Vector2 Direction;

        //protected int MovementSpeed;

		// Sprite related fields.
		protected ISprite Sprite { get; set; }

		public void TakeDamage(int damage)
		{
			Health -= damage;

			if (Health <= 0)
			{
				// not implemented
				Destroy();
			}
		}
		public abstract void Destroy();
		public abstract void Update(GameTime gameTime);
		public abstract void Draw(SpriteBatch sb);

		public Rectangle GetHitbox() 
		{
			return State.GetHitbox(Position);
		}
	}
}
