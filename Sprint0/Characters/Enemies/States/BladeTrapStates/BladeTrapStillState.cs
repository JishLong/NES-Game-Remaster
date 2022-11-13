using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Characters.Enemies.States.BladeTrapStates
{
    public class BladeTrapStillState : AbstractCharacterState
    {
        private Types.Direction StateDirection;
        private Vector2 DirectionVector;

        public BladeTrapStillState(AbstractCharacter character) : base(character)
        {

        }
        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void ChangeDirection()
        {
            throw new NotImplementedException();
        }

        public override void Freeze(bool frozenForever)
        {
            // Cannot be frozen
        }


        public override void Unfreeze() { }

        public override void Update(GameTime gameTime)
        {
            Character.Sprite.Update();
        }
    }
}
