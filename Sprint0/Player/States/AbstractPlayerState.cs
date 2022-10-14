using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace Sprint0.Player.State
{
    public abstract class AbstractPlayerState : IPlayerState
    {
        public Player Player { get; }
        public int DamageFrameCounter { get; set; }

        protected ISprite Sprite;

        // Used for control logic
        protected static bool IsChangingDirection, IsAttacking;
        protected int FramesPassed;

        public AbstractPlayerState(Player player) 
        {
            Player = player;
            DamageFrameCounter = 0;
            FramesPassed = 0;
        }

        // Copy constructor
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
            IsAttacking = false;
        }

        public virtual void DoPrimaryAttack() 
        {
            IsAttacking = true;
        }

        public virtual void DoSecondaryAttack() 
        {
            IsAttacking = true;
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

            IsChangingDirection = false;
            FramesPassed++;

            if (Player.Color == Color.Red) 
            {
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
