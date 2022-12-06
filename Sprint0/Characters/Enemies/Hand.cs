using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States.HandStates;
using Sprint0.Sprites;
using Sprint0.Sprites.Characters.Enemies;
using Sprint0.Sprites.Player.Idle;

namespace Sprint0.Characters.Enemies
{
    public class Hand : AbstractCharacter
    {
        private int FramesPassed;
        public Types.Direction OriginalDirection;
        public bool ShouldBeKilled;
        public ISprite PlayerSprite;

        public Hand(Vector2 position, Types.Direction direction, bool clockwise) : base(Types.Character.HAND)
        {
            OriginalDirection = direction;
            ShouldBeKilled = false;

            // State
            State = new HandMovingState(this, direction, clockwise);

            // The hand sprite is the same no matter its state, so we'll just instantiate it here
            if (clockwise == true && direction == Types.Direction.DOWN) Sprite = new HandDownRightSprite();
            else if (clockwise == false && direction == Types.Direction.RIGHT) Sprite = new HandDownRightSprite();
            else if (clockwise == false && direction == Types.Direction.DOWN) Sprite = new HandDownLeftSprite();
            else if (clockwise == true && direction == Types.Direction.LEFT) Sprite = new HandDownLeftSprite();
            else if (clockwise == false && direction == Types.Direction.UP) Sprite = new HandUpRightSprite();
            else if (clockwise == true && direction == Types.Direction.RIGHT) Sprite = new HandUpRightSprite();
            else Sprite = new HandUpLeftSprite();

            // Combat
            Health = 2;
            Damage = 1;

            // Movement
            Position = position;
            FramesPassed = 0;
        }

        public override void Update(GameTime gameTime)
        {
            FramesPassed++;
            if (FramesPassed >= 16 * 2 * GameWindow.ResolutionScale)
            {
                FramesPassed = 0;
                State.ChangeDirection();
            }

            base.Update(gameTime);
        }

        public void HoldPlayer() 
        {
            PlayerSprite = new PlayerIdleUpSprite();
        }
    }
}
