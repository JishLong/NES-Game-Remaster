using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.GameModes;
using static Sprint0.Utils;

namespace Sprint0.Characters
{
    public abstract class AbstractCharacterState : ICharacterState
    {
        protected AbstractCharacter Character;

        protected AbstractCharacterState(AbstractCharacter character) 
        {
            Character = character;
        }

        public abstract void Attack();

        public abstract void ChangeDirection();

        public virtual void Draw(SpriteBatch sb, Vector2 position, Color color)
        {
            Character.Sprite.Draw(sb, position, color, CharacterLayerDepth);
        }

        public abstract void Freeze(bool frozenForever);

        public Rectangle GetHitbox(Vector2 position)
        {
            return Character.Sprite.GetDrawbox(position);
        }

        public abstract void TransitionGameModes(IGameMode oldGameMode, IGameMode newGameMode, bool inCurrentRoom);

        public abstract void Unfreeze();
        
        public abstract void Update(GameTime gameTime);
    }
}
