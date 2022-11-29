using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.States.HandStates;
using Sprint0.GameModes;
using static Sprint0.Types;
using Color = Microsoft.Xna.Framework.Color;

namespace Sprint0.Characters.Enemies.States.HandStates
{
    public class HandFrozenState: AbstractCharacterState
    {
        private bool FrozenForever;
        private readonly Types.Direction ResumeMovementDirection;
        private readonly bool ClockWise;

        private double FrozenTimer;
        private readonly double FrozenDelay = 5000;  // Stay frozen for this many milliseconds.

        public HandFrozenState(AbstractCharacter character, Types.Direction direction, bool clockWise, bool frozenForever) : base(character)
        {
            ResumeMovementDirection = direction;
            FrozenForever = frozenForever;
            ClockWise = clockWise;

            FrozenTimer = 0;
        }
        public override void Attack()
        {
            // Does not attack.
        }

        public override void ChangeDirection()
        {
            // Can't change direction while frozen
        }

        public override void Draw(SpriteBatch sb, Vector2 position, Color color)
        {
            if ((Character as Hand).PlayerSprite != null) (Character as Hand).PlayerSprite.Draw(sb, position, color,
                Sprint0.Utils.WallLayerDepth + 0.02f);
            Character.Sprite.Draw(sb, position, color, Sprint0.Utils.WallLayerDepth + 0.01f);
        }

        public override void Freeze(bool frozenForever)
        {
            // If a hand is frozen from a boomerang, picking up a clock will keep it frozen forever
            // On the other hand, if a hand is frozen from a clock, we don't want the boomerang to "unfreeze" it
            if (frozenForever) FrozenForever = frozenForever;
        }

        public override void TransitionGameModes(IGameMode oldGameMode, IGameMode newGameMode, bool inCurrentRoom)
        {
            if (inCurrentRoom) Character.State = new HandGameModeTransitionState(Character, oldGameMode, newGameMode, ResumeMovementDirection, ClockWise);
            else Character.Sprite = newGameMode.GetHandSprite(this, ResumeMovementDirection, ClockWise);
        }

        public override void Unfreeze() 
        {
            Character.State = new HandMovingState(Character, ResumeMovementDirection, ClockWise);
        }

        public override void Update(GameTime gameTime)
        {
            if (!FrozenForever) FrozenTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if ((FrozenTimer - FrozenDelay) > 0) Unfreeze();

            Character.Sprite.Update();
        }
    }
}
