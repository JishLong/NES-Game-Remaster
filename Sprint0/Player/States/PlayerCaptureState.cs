using Sprint0.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Player.Stationary;
using Sprint0.Commands.GameStates;
using Sprint0.Commands;
using Sprint0.Sprites.GoombaMode.Goomba;
using Sprint0.GameModes;

namespace Sprint0.Player.States
{
    public class PlayerCaptureState : AbstractPlayerState
    {
        private readonly ICommand GoToBeginningCommand;
        private int FramesPassed;
        protected static readonly int HandHoldFrames = 160;

        public PlayerCaptureState(Player player, ICommand goToBeginningCommand) : base(player)
        {
            Sprite = GameModeManager.GetInstance().GameMode.GetPlayerSprite(this, Player.FacingDirection);
            GoToBeginningCommand = goToBeginningCommand;
            Player.FacingDirection = Types.Direction.UP;
            
            FramesPassed = 0;
        }

        public override void Capture(ICommand goToBeginningCommand) 
        {
            // Already captured!
        }

        public override void Draw(SpriteBatch sb, Vector2 position)
        {
            // Nothing happens; hand effect must complete itself 
        }

        public override Rectangle GetHitbox()
        {
            return Rectangle.Empty;
        }

        public override void Update()
        {
            base.Update();

            FramesPassed++;

            if (FramesPassed % HandHoldFrames == 0)
            {
                GoToBeginningCommand.Execute();
                Player.State = new PlayerIdleState(Player);
            }
        }

        public override void Move(Types.Direction direction)
        {
            // Nothing happens; hand effect must complete itself
        }

        public override void StopAction()
        {
            // Nothing happens; hand effect must complete itself
        }

        public override void DoPrimaryAttack()
        {
            // Nothing happens; hand effect must complete itself
        }

        public override void DoSecondaryAttack()
        {
            // Nothing happens; hand effect must complete itself
        }

        public override void HoldItem(IItem item)
        {
            // Nothing happens; hand effect must complete itself
        }
    }
}
