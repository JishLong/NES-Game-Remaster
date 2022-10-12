using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Bosses.Interfaces;
using Sprint0.Sprites.Projectiles;
using Sprint0.Sprites;


namespace Sprint0.Bosses
{
	public abstract class AbstractBoss : IBoss
	{
		// Combat related fields.
		protected int Health { get; set; }
        protected int Damage { get; set; }
		//protected IAttackBehavior BossAttackBehavior;

        // Movement related fields.
        protected Vector2 Position;
        protected Vector2 Direction;
		//public string DirectionName;
        protected int MovementSpeed;
        protected bool CanMove = true;

		// Sprite related fields.
		protected ISprite Sprite { get; set; }

		public void TakeDamage(int damage)
		{
			Health -= damage;

			if (Health <= 0)
			{
				Destroy();
			}
		}
		public void Freeze()
		{
			this.CanMove = false;
		}

		public void Unfreeze()
		{
			this.CanMove = true;
		}
		public abstract void Destroy();
		public abstract void Update(GameTime gameTime);
		public abstract void Draw(SpriteBatch sb);

		public Rectangle GetHitbox() 
		{
			return Sprite.GetDrawbox(Position);
		}
	}
}
