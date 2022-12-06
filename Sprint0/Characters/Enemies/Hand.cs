using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Enemies.States;
using Sprint0.Sprites;
using Sprint0.Sprites.Characters.Enemies;
using Sprint0.Sprites.Player.Idle;
using static Sprint0.Types;

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
            MovingState = new HandMovingState(this, clockwise);
            FrozenTemporarilyState = new FrozenTemporarilyState(this);
            FrozenForeverState = new FrozenForeverState(this);
            AttackState = null;

            MovingState.SetUp(direction);
            CurrentState = MovingState;

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
            MovementSpeed = new(1.0f / 3 * GameWindow.ResolutionScale, 1.0f / 3 * GameWindow.ResolutionScale);

            // Movement
            Position = position;
            FramesPassed = 0;
        }

        public override void Draw(SpriteBatch sb)
        {
            Color CharacterColor = (IsTakingDamage) ? Color.Red : Color.White;
            if (!JustSpawned) 
            {
                if (PlayerSprite != null) PlayerSprite.Draw(sb, Sprint0.Utils.LinkToCamera(Position), 
                    CharacterColor, Sprint0.Utils.WallLayerDepth + 0.02f);
                Sprite.Draw(sb, Sprint0.Utils.LinkToCamera(Position), CharacterColor, Sprint0.Utils.WallLayerDepth + 0.01f);
            }
        }

        public override void SetSprite(Types.Direction direction)
        {
            // Do nothing
        }

        public override void Update(GameTime gameTime)
        {
            FramesPassed++;
            if (FramesPassed >= 16 * 2 * GameWindow.ResolutionScale)
            {
                FramesPassed = 0;
                CurrentState.ChangeDirection();
            }

            base.Update(gameTime);
        }

        public void HoldPlayer() 
        {
            PlayerSprite = new PlayerIdleUpSprite();
        }
    }
}
