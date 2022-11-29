using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States.HandStates;
using Sprint0.GameModes;
using Sprint0.Sprites;
using Sprint0.Sprites.Characters.Enemies;
using Sprint0.Sprites.GoombaMode.Goomba;
using Sprint0.Sprites.Player.Stationary;

namespace Sprint0.Characters.Enemies
{
    public class Hand : AbstractCharacter
    {
        private int FramesPassed;
        public Types.Direction OriginalDirection;
        public bool ShouldBeKilled;
        public ISprite PlayerSprite;

        public Hand(Vector2 position, Types.Direction direction, bool clockwise)
        {
            OriginalDirection = direction;
            ShouldBeKilled = false;

            // State
            State = new HandMovingState(this, direction, clockwise);

            // The hand sprite is the same no matter its state, so we'll just instantiate it here
            Sprite = GameModeManager.GetInstance().GameMode.GetHandSprite(State, direction, clockwise);

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

        public void HoldPlayer(Types.GameMode gameMode) 
        {
            if (gameMode != Types.GameMode.GOOMBAMODE) PlayerSprite = new PlayerIdleDownSprite();
            else PlayerSprite = new GoombaIdleSprite();
        }
    }
}
