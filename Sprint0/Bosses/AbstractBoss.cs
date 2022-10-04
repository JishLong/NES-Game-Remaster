using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Bosses.Interfaces;
using Sprint0.Sprites.Bosses;
using Sprint0.Sprites;

namespace Sprint0.Bosses
{
	public abstract class AbstractBoss : IBoss
	{
		// Combat related fields.
		public int Health { get; set; }
		public int Damage { get; set; }

		// Movement related fields.
		public Vector2 Position;
		public Vector2 Direction;
		public string DirectionName;
		public int MovementSpeed;
		public bool CanMove;

		// Sprite related fields.
		public ISprite sprite { get; set; }
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
	}
}