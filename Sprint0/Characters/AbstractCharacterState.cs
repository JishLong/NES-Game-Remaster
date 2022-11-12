using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Sprint0.Utils;
using Sprint0.Sprites;

namespace Sprint0.Characters
{
    public abstract class AbstractCharacterState : ICharacterState
    {
        protected AbstractCharacter Character;
        protected ISprite Sprite;      

        protected AbstractCharacterState(AbstractCharacter character) 
        {
            Character = character;
        }

        public abstract void Attack();

        public abstract void ChangeDirection();

        public void Draw(SpriteBatch sb, Vector2 position, Color color)
        {
            Sprite.Draw(sb, position, color, CharacterLayerDepth);
        }

        public abstract void Freeze(bool frozenForever);

        public Rectangle GetHitbox(Vector2 position)
        {
            return Sprite.GetDrawbox(position);
        }

        public abstract void Move();

        public abstract void Unfreeze();
        
        public abstract void Update(GameTime gameTime);
    }
}
