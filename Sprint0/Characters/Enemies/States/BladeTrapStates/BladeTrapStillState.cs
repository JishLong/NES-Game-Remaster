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
        private BladeTrap BladeTrap;
        private Types.Direction StateDirection;
        private Vector2 DirectionVector;

        public BladeTrapStillState(BladeTrap bladeTrap)
        {
            BladeTrap = bladeTrap;
            Sprite = new BladeTrapSprite();
        }
        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void ChangeDirection()
        {
            throw new NotImplementedException();
        }

        public override void Freeze()
        {
            // Cannot be frozen
        }

        public override void Move()
        {
            // Doesn't move
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update();
        }
    }
}
