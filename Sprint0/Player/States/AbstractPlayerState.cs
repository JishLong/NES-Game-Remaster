using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace Sprint0.Player.State
{
    public abstract class AbstractPlayerState : IPlayerState
    {
        public Player Player { get; }
        public int DamageFrameCounter { get; set; }

        protected ISprite Sprite { get; set; }

        /* Used for logic in determining when to switch states
         * 
         * [IsChangingDirection]: whether the player is changing direction; set to false instantly so that the player can effectively
         * change direction only once per game frame
         * 
         * [IsAttacking]: whether the user isa initiating some input that would cause the player to attack
         * 
         * [FramesPassed]: the number of game frames that have passed since this state has been active
         */
        protected static bool IsChangingDirection, IsPrimaryAttacking;
        protected int FramesPassed;

        public AbstractPlayerState(Player player) 
        {
            Player = player;
            DamageFrameCounter = 0;
            FramesPassed = 0;
        }

        // Copy constructor used for switching states
        public AbstractPlayerState(IPlayerState state) 
        {
            Player = state.Player;
            DamageFrameCounter = state.DamageFrameCounter;
            FramesPassed = 0;
        }

        public virtual void ChangeDirection(Types.Direction direction) 
        {
            IsChangingDirection = true;
        }

        public virtual void StopAction() 
        {
            IsPrimaryAttacking = false;
        }

        public virtual void DoPrimaryAttack() 
        {
            IsPrimaryAttacking = true;
        }

        public virtual void DoSecondaryAttack() 
        {
            // Empty, but nice since it doesn't need to be declared in all the subclasses
        }

        public void TakeDamage() 
        {
            Player.Color = Color.Red;
        }

        public Rectangle GetHitbox() 
        {
            return Sprite.GetDrawbox(Player.Position);
        }

        public virtual void Update() 
        {
            Sprite.Update();

            // Update some of the logical variables
            IsChangingDirection = false;
            FramesPassed++;

            // If the player is damaged, check to see if they should no longer be damaged
            if (Player.Color == Color.Red) 
            {
                /* The "40" here is a magic number and is the number of frames the player is damaged for;
                 * I got it from the old player logic, not sure if we should make it into a variable so it's not a magic number?
                 */
                DamageFrameCounter = (DamageFrameCounter + 1) % 40;
                if (DamageFrameCounter == 0) 
                {
                    Player.Color = Color.White;
                }
            }
        }

        public void Draw(SpriteBatch sb, Vector2 position) 
        {
            Sprite.Draw(sb, position, Player.Color);
        }
    }
}
