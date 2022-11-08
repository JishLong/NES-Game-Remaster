using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Commands.Levels;
using Sprint0.Sprites;
using static Sprint0.Utils;
using static Sprint0.Types;
using Sprint0.Commands.GameStates;
using Sprint0.Items;
using Sprint0.Player.States.BlueArrow;

namespace Sprint0.Player.State
{
    public abstract class AbstractPlayerState : IPlayerState
    {
        public Player Player { get; }
        protected ISprite Sprite { get; set; }

        private static readonly Vector2 Knockback = new(16 * Utils.GameScale, 16 * Utils.GameScale);
        private static readonly int InvincibilityFrames = 40;
        protected static readonly int UseFrames = 20;
        protected static readonly int ItemPickUpFrames = 40;

        // The number of frames that have passed since this state has been in use
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
            FramesPassed = 0;
        }

        public virtual void ChangeDirection(Types.Direction direction) 
        {
            Player.IsChangingDirection = true;
            Player.IsStationary = false;
            Player.FacingDirection = direction;          
        }

        public virtual void StopAction() 
        {
            Player.IsPrimaryAttacking = false;
            Player.IsStationary = true;
        }

        public virtual void DoPrimaryAttack() 
        {
            Player.IsPrimaryAttacking = true;
            Player.IsStationary = false;
        }

        public virtual void DoSecondaryAttack() 
        {
            Player.IsStationary = false;
        }

        public void PickUpItem(IItem item) 
        {
            Player.IsStationary = true;
            Player.FacingDirection = Direction.DOWN;
            Player.IsPrimaryAttacking = false;
            Player.State = new PlayerPickUpItemState(Player, item);
        }

        public void TakeDamage(int damage, Game1 game) 
        {
            if (!Player.IsTakingDamage) 
            {
                Player.IsTakingDamage = true;
                AudioManager.GetInstance().PlayOnce(Resources.PlayerTakeDamage);
                Player.Health -= damage;
                if (Player.Health <= 0) 
                {
                    AudioManager.GetInstance().PlayOnce(Resources.PlayerDeath);
                    new LoseGameCommand(game).Execute();
                }          
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
            Vector2 ReducedHitboxPosition = Utils.CenterRectangles(ActualHitbox, ReducedWidth, ReducedHeight);

            return new Rectangle((int)(ReducedHitboxPosition.X), (int)(ReducedHitboxPosition.Y), ReducedWidth, ReducedHeight);
        }

        public virtual void Update() 
        {
            Sprite.Update();
            Player.HUD.Update(Player);

            // Update some of the logical variables
            Player.IsChangingDirection = false;
            FramesPassed++;

            // If the player is damaged, check to see if they should no longer be damaged
            if (Player.IsTakingDamage) 
            {
                if (Player.DamageFramesPassed < InvincibilityFrames / 5) 
                {
                    Player.Position += Utils.DirectionToVector(Utils.GetOppositeDirection(Player.FacingDirection)) * Knockback / (InvincibilityFrames / 5);
                }
                Player.DamageFramesPassed = (Player.DamageFramesPassed + 1) % InvincibilityFrames;
                if (Player.DamageFramesPassed == 0) 
                {
                    Player.IsTakingDamage = false;
                }
            }

            // Low health sound effect (annoying and scary D: )
            if (Player.Health == 1 && ++Player.LowHealthFramesPassed % 20 == 0) 
            {
                AudioManager.GetInstance().PlayOnce(Resources.LowHealth);
                Player.LowHealthFramesPassed = 0;
            }
        }

        public virtual void Draw(SpriteBatch sb, Vector2 position) 
        {
            Color PlayerColor = (Player.IsTakingDamage) ? Color.Red : Color.White;
            Sprite.Draw(sb, position, PlayerColor, PlayerLayerDepth);
        }
    }
}
