using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace Sprint0.Player.State
{
    public abstract class AbstractPlayerState : IPlayerState
    {
        public Player Player { get; }
        protected static readonly Vector2 Knockback = new(-15, -15);

        protected ISprite Sprite { get; set; }

        /* Used for logic in determining when to switch states
         * 
         * [IsChangingDirection]: whether the player is changing direction; set to false instantly so that the player can effectively
         * change direction only once per game frame
         * 
         * [IsAttacking]: whether the user is initiating some input that would cause the player to attack
         * 
         * [FramesPassed]: the number of game frames that have passed since this state has been active
         */
        protected int DamageFrameCounter; 
        protected int FramesPassed;

        public AbstractPlayerState(Player player) 
        {
            Player = player;
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
            Player.IsChangingDirection = true;
            Player.FacingDirection = direction;
        }

        public virtual void StopAction() 
        {
            Player.IsPrimaryAttacking = false;
        }

        public virtual void SetToStationary()
        {
            Player.IsStationary = true;
        }
        public virtual void DoPrimaryAttack() 
        {
            Player.IsPrimaryAttacking = true;
        }

        public virtual void DoSecondaryAttack() 
        {
            // Empty, but nice since it doesn't need to be declared in all the subclasses
        }

        public void TakeDamage(int damage) 
        {
            if (!Player.IsTakingDamage) 
            {
                Player.IsTakingDamage = true;
                Player.Health -= damage;
                if (Player.Health <= 0) 
                {
                    // The player dies; perhaps a game over state?
                }
                Player.Position += Utils.DirectionToVector(Player.FacingDirection) * Knockback;
            }     
        }

        public Rectangle GetHitbox() 
        {
            /* It's a little nicer if the player's hitbox is slightly smaller than it cosmetically appears;
             * This makes it easier to run in between tight spaces of blocks
             */
            Rectangle ActualHitbox = new Rectangle((int)Player.Position.X, (int)Player.Position.Y,
                (int)(Resources.LinkDown.Width * Utils.GameScale), (int)(Resources.LinkDown.Height * Utils.GameScale));

            int ReducedWidth = ActualHitbox.Width * 2 / 3;
            int ReducedHeight = ActualHitbox.Height * 2 / 3;
            Vector2 ReducedHitboxPosition = Utils.CenterRectangles(ActualHitbox, new Rectangle(0, 0, ReducedWidth, ReducedHeight));

            return new Rectangle((int)(ReducedHitboxPosition.X), (int)(ReducedHitboxPosition.Y), ReducedWidth, ReducedHeight);
        }

        public virtual void Update() 
        {
            Sprite.Update();

            // Update some of the logical variables
            Player.IsChangingDirection = false;
            FramesPassed++;

            // If the player is damaged, check to see if they should no longer be damaged
            if (Player.IsTakingDamage) 
            {
                /* The "40" here is a magic number and is the number of frames the player is damaged for;
                 * I got it from the old player logic, not sure if we should make it into a variable so it's not a magic number?
                 */
                DamageFrameCounter = (DamageFrameCounter + 1) % 40;
                if (DamageFrameCounter == 0) 
                {
                    Player.IsTakingDamage = false;
                }
            }
        }

        public void Draw(SpriteBatch sb, Vector2 position) 
        {
            Sprite.Draw(sb, position, Player.Color);
        }
    }
}
